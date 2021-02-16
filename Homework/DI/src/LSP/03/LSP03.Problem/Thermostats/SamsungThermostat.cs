namespace LSP03.Problem.Thermostats
{
    public class SamsungThermostat : Thermostat
    {
        public override void Heat()
        {
            this.CurrentTemperature += 5;
        }
    }
}