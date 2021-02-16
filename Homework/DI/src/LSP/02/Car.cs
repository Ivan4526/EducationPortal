public class Car
{
    protected bool isEngineStarted;

    protected int MaxSpeed = 100;

    public int Speed { get; protected set; }

    public virtual void StartEngine() => this.isEngineStarted = true;

    public virtual void StopEngine() => this.isEngineStarted = false;

    public virtual void Accelerate()
    {
        if (!this.isEngineStarted) return;

        this.Speed += 10; // kmh

        if (this.Speed > this.MaxSpeed)
        {
            this.Speed = this.MaxSpeed;
        }
    }
}

public class SuperCar : Car
{
    public SuperCar()
    {
        // LSP violation
        this.isEngineStarted = true;
        this.MaxSpeed = 350;
    }

    public override void Accelerate()
    {
        this.Speed += 100; // kmh

        if (this.Speed > this.MaxSpeed)
        {
            // LSP violation
            throw new CarBlownUpException("Surpriiissseee!!! Didn't we tell you not to accelerate to a max speed? :)");
        }
    }
}