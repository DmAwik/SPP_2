using System;
using System.Collections.Generic;
using System.Text;

namespace Fakers
{
    public interface IGenerator
    {
        object Generate(GeneratorContext context);
        bool CanGenerate(Type type);
    }

    public class GeneratorContext
    {
        public Random Random { get; }
        public Type CurrentType { get; }
        public Faker Faker { get; }

        public GeneratorContext(Random random, Type currentType, Faker faker)
        {
            Random = random;
            CurrentType = currentType;
            Faker = faker;
        }
    }
}
