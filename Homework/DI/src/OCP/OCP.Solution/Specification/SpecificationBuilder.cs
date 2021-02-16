using System;

namespace OCP.Solution.Specification
{
    public class SpecificationBuilder<T>
    {
        public SpecificationBuilder<T> FilterBy(Predicate<T> filter)
        {
            return this;
        }

        public ISpecification<T> Build()
        {
            throw new NotImplementedException();
        }
    }
}