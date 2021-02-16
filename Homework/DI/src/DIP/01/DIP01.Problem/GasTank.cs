using System;

namespace DIP01.Problem
{
    public class GasTank
    {
        private const double MaxAmount = 100;

        public double GasAmount { get; set; }

        internal void GetGas()
        {
            this.GasAmount -= 1;
        }

        public void FillUp(double amount)
        {
            this.GasAmount = Math.Min(this.GasAmount + amount, MaxAmount);
        }
    }
}