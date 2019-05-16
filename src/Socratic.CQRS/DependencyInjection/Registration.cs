using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Socratic.CQRS.Abstractions;
using Socratic.CQRS.Abstractions.Attributes;
using Socratic.CQRS.Abstractions.Decorators;
using Socratic.CQRS.Exceptions;

namespace Socratic.CQRS.DependencyInjection
{
    public static class Registration
    {
        public static void UseCqrs(this IServiceCollection services, Assembly assembly, Action<CqrsConfig> configFunc = null)
        {
            services.AddSingleton<IBroker, Broker>();

            var config = new CqrsConfig();
            configFunc(config);
            
            var handlerTypes = assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandlerInterface))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (var type in handlerTypes)
            {
                AddHandler(services, type, config);
            }
        }        

        public static void AddHandler(IServiceCollection services, Type type, CqrsConfig config)
        {
            var attributes = type.GetCustomAttributes(false);

            var pipeline = attributes
                .Where(x => x is CqrsAttribute)
                .Select(x => ToDecorator(x, config))
                .Concat(new[] { type })
                .Reverse()
                .ToList();

            var interfaceType = type.GetInterfaces().Single(IsHandlerInterface);
            Func<IServiceProvider, object> factory = BuildPipeline(pipeline, interfaceType);

            services.AddTransient(interfaceType, factory);
        }

        private static Func<IServiceProvider, object> BuildPipeline(List<Type> pipeline, Type interfaceType)
        {
            var ctors = pipeline
                .Select(x => 
                {
                    var type = x.IsGenericType ? x.MakeGenericType(interfaceType.GenericTypeArguments) : x;
                    return type.GetConstructors().Single();
                })
                .ToList();
            
            Func<IServiceProvider, object> func = (provider) => 
            {
                object current = null;

                foreach (ConstructorInfo ctor in ctors)
                {
                    var paramInfos = ctor.GetParameters().ToList();
                    var parameters = GetParameters(paramInfos, current, provider);
                    current = ctor.Invoke(parameters);
                }

                return current;
            };

            return func;
        }

        private static object[] GetParameters(List<ParameterInfo> paramInfo, object current, IServiceProvider provider)
        {
            var result = new object[paramInfo.Count];

            for (var index = 0; index < paramInfo.Count; index++)
            {
                result[index] = GetParameter(paramInfo[index], current, provider);
            }

            return result;
        }

        private static object GetParameter(ParameterInfo paramInfo, object current, IServiceProvider provider)
        {
            var paramType = paramInfo.ParameterType;

            if (IsHandlerInterface(paramType))
                return current;

            var service = provider.GetService(paramType);

            if (service != null)
                return service;
            
            throw new ArgumentException($"Type {paramType} not found");
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;
            
            var typeDef = type.GetGenericTypeDefinition();

            return typeDef == typeof(IRequestHandler<,>);
        }

        private static Type ToDecorator(object attribute, CqrsConfig config)
        {
            switch(attribute)
            {
                case AuditAttribute _: 
                    return typeof(AuditDecorator<,>);            
                //reconcile future built-in attribute-decorator relationships here...    
            }

            var type = attribute.GetType();
            config.DecoratorMapping.TryGetValue(type, out var result);
            
            if (result == null)
                throw new UnregisteredAttributeException(type);

            return result;
        }
    }
}