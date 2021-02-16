using System;

namespace ISP.Problem
{
    public class JobManager
    {
        public void Execute<T>(T job)
            where T : IJob
        {
            job.OnStaring();

            try
            {
                job.Execute();
            }
            catch (Exception e)
            {
                job.OnFailed(e);
            }

            job.OnFinished();
        }
    }
}