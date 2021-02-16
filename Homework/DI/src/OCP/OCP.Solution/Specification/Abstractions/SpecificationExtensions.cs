using System;

namespace OCP.Solution.Specification
{
    public static class SpecificationExtensions
    {
        public static IOrSpecification<T, U> Or<T,U>(this ISpecification<T> spec, ISpecification<U> another)
        {
            throw new NotImplementedException();
        }
    }
}