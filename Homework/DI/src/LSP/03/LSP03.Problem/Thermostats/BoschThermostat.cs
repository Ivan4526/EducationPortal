namespace LSP03.Problem.Thermostats
{
    public class BoschThermostat : Thermostat
    {
        public override void Heat()
        {
            this.CurrentTemperature += 1;
        }
    }
}