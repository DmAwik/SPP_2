using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Fakers
{
     public interface IFaker
    {
        T Create<T>();
    }

    public class Faker : IFaker
    {
        private Stack<Type> stack;
        private List<IGenerator> generators;
        private Random random;
        public T Create<T>()
        {
            return (T)GenerateValue(new GeneratorContext(random, typeof(T), this));
        }
        public Faker()
        {
            stack = new Stack<Type>();
            generators = new PluginLoader().Plugins();
            generators.Add(new ListGenerator());
            random = new Random(3228);
        }


        private object Create(Type type)
        {
            object Object = null;
            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic).OrderByDescending(ctor => ctor.GetParameters().Length).ToList();
            if (constructors.Count != 0 && Object == null)
            {
                foreach (var constructor in constructors)
                {
                    var constructorParams = constructor.GetParameters();
                    List<object> constructorValues = new List<object>();
                    foreach (var constructorParam in constructorParams)
                    {
                        constructorValues.Add(GenerateValue(new GeneratorContext(random, constructorParam.ParameterType, this)));
                    }
                    try
                    {
                        Object = constructor.Invoke(constructorValues.ToArray());
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            else
            {
                Object = Activator.CreateInstance(type);
            }

            var fields = type.GetFields();
            foreach (var field in fields)
            {
                if (Equals(field.GetValue(Object), GetDefaultValue(field.FieldType)))
                {
                    field.SetValue(Object, GenerateValue(new GeneratorContext(random, field.FieldType, this)));
                }
            }
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (Equals(property.GetValue(Object), GetDefaultValue(property.PropertyType)))
                {
                    property.SetValue(Object, GenerateValue(new GeneratorContext(random, property.PropertyType, this)));
                }
            }
            return Object;
        }

        internal object GenerateValue(GeneratorContext context)
        {
            object value = null;
            foreach (IGenerator generator in generators)
            {
                if (generator.CanGenerate(context.CurrentType))
                {
                    value = generator.Generate(context);
                    break;
                }
            }
            if (value == null && !stack.Contains(context.CurrentType))
            {
                stack.Push(context.CurrentType);
                value = Create(context.CurrentType);
                stack.Pop();
            }
            return value;
        }

        private static object GetDefaultValue(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            else
                return null;
        }
    }
}
