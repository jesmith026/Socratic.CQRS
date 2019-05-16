using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Socratic.CQRS.Abstractions;

namespace Socratic.CQRS.DependencyInjection
{
    public static class Registration
    {
        public static void UseCqrs(this IServiceCollection services, Assembly assembly)
        {
            var handlerTypes = assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandlerInterface))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (var type in handlerTypes)
            {
                AddHandler(services, type);
            }
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;
            
            var typeDef = type.GetGenericTypeDefinition();

            return typeDef == typeof(IRequestHandler<,>);
        }

        public static void AddHandler(IServiceCollection services, Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            var pipeline = attributes
                // .Select(ToDecorator)
                .ToList();
        }

        // private static Type ToDecorator(object attribute, Type[] types)
        // {
        //     var type = attribute.GetType();

        //     switch(attribute)
        //     {
        //         case AuditAttribute
        //     }
        // }
    }
}