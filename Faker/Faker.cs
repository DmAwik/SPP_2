using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Faker
{
    public interface IFaker
    {
        T Create<T>();
    }

    public class Faker : IFaker
    {
        private Stack<Type> dodgestack;
        private List<IGenerator> generators;
        private Random random;
    }
}
