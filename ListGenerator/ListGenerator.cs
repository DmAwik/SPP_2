﻿using Fakers;
using System;
using System.Collections;
using System.Linq;

namespace ListGenerator
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
            Type itemtype = list.GetType().GetGenericArguments().Single();
            int listlength = context.Random.Next(1, 10);
            GeneratorContext newcontext = new GeneratorContext(context.Random, itemtype, context.Faker);
            for (int i = 0; i < listlength; i++)
            {
                //list.Add(context.Faker.GenerateValue(newcontext));
            }
            return list;
        }
    }
}
