namespace OCP.Solution.Specification
{
    public interface IOrSpecification<in T, in U> : ISpecification<T>
    {
        bool OrSatisfyedBy(U item);
    }
}