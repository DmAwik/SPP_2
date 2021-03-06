using System;
using System.Collections;
using System.Linq;

namespace Fakers
{
    class ListGenerator : IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.GetInterfaces().Contains(typeof(IList));
        }

        public object Generate(GeneratorContext context)
        {
            IList list = (IList)Activator.CreateInstance(context.CurrentType);
            Type type = list.GetType().GetGenericArguments().Single();
            int listlength = context.Random.Next(1, 10);
            GeneratorContext newcontext = new GeneratorContext(context.Random, type, context.Faker);
            for (int i = 0; i < listlength; i++)
            {
                try
                {
                    list.Add(context.Faker.GenerateValue(newcontext));
                }
                catch
                {
                    break;
                }
            }
            return list;
        }
    }
}
