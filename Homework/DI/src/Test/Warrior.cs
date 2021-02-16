public class Warrior
{
    public int Health { get; internal set; } = 100;

    public virtual void Hit(Warrior anotherWarrior)
    {
        // avoid negative
        if (anotherWarrior.Health < 10)
        {
            anotherWarrior.Health = 0;
            return;
        }

        anotherWarrior.Health -= 10;
    }
}

public class SuperWarrior : Warrior
{
    public bool HasSuperPower { get; set; }

    public override void Hit(Warrior anotherWarrior)
    {
        anotherWarrior.Health -= this.HasSuperPower ? 50 : 10;
    }
}