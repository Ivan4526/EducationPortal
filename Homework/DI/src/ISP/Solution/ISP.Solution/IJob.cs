using System;

namespace ISP.Solution
{
    public interface IJob
    {
        string Name { get; }

        void Execute();
    }

    public interface IJobStarting
    {
        void OnStarting();
    }

    public interface IJobFailed
    {
        void OnFailed(Exception e);
    }

    public interface IJobFinished
    {
        void OnFinished();
    }

}