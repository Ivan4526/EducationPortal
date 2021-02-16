namespace LSP03.Problem
{
    public abstract class Thermostat
    {
        public double CurrentTemperature { get; protected set; }

        public abstract void Heat();
    }
}