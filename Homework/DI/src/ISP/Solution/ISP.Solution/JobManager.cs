using System;
using ISP.Solution;

namespace ISP.Problem
{
    public class JobManager
    {
        public void Execute<T>(T job)
            where T : IJob
        {
            (job as IJobStarting)?.OnStarting();

            try
            {
                job.Execute();
            }
            catch (Exception e)
            {
                (job as IJobFailed)?.OnFailed(e);

                return; // TODO: design IJob to be able to proceed to OnFinished (OCP)
            }

            (job as IJobFinished)?.OnFinished();
        }
    }
}