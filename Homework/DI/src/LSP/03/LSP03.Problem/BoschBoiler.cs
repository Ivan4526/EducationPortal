using LSP03.Problem.Thermostats;

namespace LSP03.Problem
{
    public class BoschBoiler : Boiler
    {
        public BoschBoiler()
        {
            this.Thermostat = new BoschThermostat();
        }

        public override string Manufacturer { get; } = "Bosch";

        public override double GetWaterTemperature() => this.Thermostat.CurrentTemperature;
    }
}