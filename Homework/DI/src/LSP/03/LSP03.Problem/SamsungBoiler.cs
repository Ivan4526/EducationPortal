using LSP03.Problem.Thermostats;

namespace LSP03.Problem
{
    public class SamsungBoiler : Boiler
    {
        public SamsungBoiler()
        {
            this.Thermostat = new SamsungThermostat();
        }

        public override string Manufacturer { get; } = "Samsung";

        public override double GetWaterTemperature() => this.Thermostat.CurrentTemperature;
    }
}