using ISP.Problem;

namespace ISP.Solution
{
    internal class Program
    {
        private static void Main()
        {
            var jobManager = new JobManager();

            var job = new PrintJob();

            jobManager.Execute(job);
        }
    }
}
