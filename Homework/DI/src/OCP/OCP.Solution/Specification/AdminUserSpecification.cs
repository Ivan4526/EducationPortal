using OCP.Solution.Domain;

namespace OCP.Solution.Specification
{
    public class AdminUserSpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user) => user.Role == Roles.Admin;
    }
}