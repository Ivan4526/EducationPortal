using OCP.Solution.Domain;

namespace OCP.Solution.Specification
{
    public class PremiumUserSpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user) => user.IsPremiumUser && user.Subscription.IsActive;
    }
}