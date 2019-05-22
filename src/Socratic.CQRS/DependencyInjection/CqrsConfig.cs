using System;
using System.Collections.Generic;

namespace Socratic.CQRS.DependencyInjection
{
    public class CqrsConfig
    {
        internal readonly IDictionary<Type, Type> DecoratorMapping = new Dictionary<Type, Type>();

        public CqrsConfig() {}

        public void MapDecorator(Type attributeType, Type decoratorType)
        {
            if (DecoratorMapping.ContainsKey(attributeType))
                throw new ArgumentException($"Attribute {attributeType.Name} already has a registered decorator.");
            
            DecoratorMapping.Add(attributeType, decoratorType);
        }
    }
}