using System;
using Fakers;

namespace IntGenerator
{
    class IntGenerator : IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }

        public object Generate(GeneratorContext context)
        {
            return context.Random.Next(1, 100);
        }
    }
}
