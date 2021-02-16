using System;

namespace ISP.Problem
{
    public interface IJob
    {
        string Name { get; }

        void Execute();

        void OnStaring();

        void OnFailed(Exception e);

        void OnFinished();
    }
}