namespace DIP01.Problem
{
    public class Car
    {
        private readonly Engine engine;
        internal readonly GasTank GasTank = new GasTank();

        public Car()
        {
            this.engine = new Engine(this);
        }

        public void StartEngine()
        {
            this.engine.Start();
        }
    }
}