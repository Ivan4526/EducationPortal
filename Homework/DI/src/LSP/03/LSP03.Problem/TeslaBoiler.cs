namespace LSP03.Problem
{
    public class TeslaBoiler : Boiler
    {
        private double currentTemperature;

        public override string Manufacturer { get; } = "Tesla";

        public override double GetWaterTemperature() => this.currentTemperature;

        public new void HeatWater()
        {
            this.currentTemperature = this.DesiredTemperature;
        }
    }
}