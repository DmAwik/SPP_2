using System;
using Fakers;

namespace BoolGenerator
{
    public class BoolGenerator : IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }

        public object Generate(GeneratorContext context)
        {
            return true;
        }
    }
}
