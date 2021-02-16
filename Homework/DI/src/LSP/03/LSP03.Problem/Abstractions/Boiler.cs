namespace LSP03.Problem
{
    public abstract class Boiler
    {
        protected Thermostat Thermostat;

        public double DesiredTemperature { get; set; }

        public abstract string Manufacturer { get; }

        public abstract double GetWaterTemperature();

        public void HeatWater()
        {
            while (this.GetWaterTemperature() < this.DesiredTemperature)
            {
                this.Thermostat.Heat();
            }
        }
    }
}