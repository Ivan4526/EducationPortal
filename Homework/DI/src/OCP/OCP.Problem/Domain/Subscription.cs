using System;

namespace OCP.Problem.Domain
{
    public class Subscription
    {
        public bool IsActive { get; set; }

        public DateTime ActivationDate { get; set; }
    }
}