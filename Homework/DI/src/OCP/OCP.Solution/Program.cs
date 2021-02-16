using OCP.Solution.Domain;
using OCP.Solution.Specification;

namespace OCP.Solution
{
    internal class Program
    {
        private static void Main()
        {
            var userManager = new UserManager();

            // BA: - We need to get all admins
            // You: - No problem
            var admins = userManager.GetUsers(new AdminUserSpecification());

            // BA: - We need to get all premium users as well
            // You: - Easy
            var premiumUsers = userManager.GetUsers(new PremiumUserSpecification());

            // BA: - We need to get all premium users and admins together
            // You: - Here we go!
            var adminsAndPremiumUsers = userManager.GetUsers(new AdminUserSpecification().Or(new PremiumUserSpecification()));

            // BA: - We need a custom filter that allows end user to filter users in a way he likes
            // You: - Ok.
            var spec = new SpecificationBuilder<User>()
                .FilterBy(u => u.Role == Roles.Admin && !u.IsPremiumUser || !u.Subscription.IsActive)
                .Build();

            var customQuery = userManager.GetUsers(spec);
        }
    }
}
