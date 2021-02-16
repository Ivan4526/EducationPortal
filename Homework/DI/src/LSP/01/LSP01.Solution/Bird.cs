using System;

namespace LSP01.Solution
{
    // Design correct abstractions

    public abstract class Bird
    {
    }

    public abstract class WalkableBird : Bird
    {
        public abstract void Walk();
    }

    public abstract class FlyableBird : WalkableBird
    {
        public abstract void Fly();
    }

    public class Duck : FlyableBird
    {
        public override void Fly() => Console.WriteLine("Duck flies, quack-quack!");

        public override void Walk() => Console.WriteLine("Duck walks");
    }

    public class Colibri : FlyableBird
    {
        public override void Fly() => Console.WriteLine("Colibri flies very fast");

        public override void Walk() => Console.WriteLine("Colibri walks jumping");
    }

    public class Ostrich : WalkableBird
    {
        public override void Walk() => Console.WriteLine("Ostrich walks very fast");
    }

    public class Penguin : WalkableBird
    {
        public override void Walk() => Console.WriteLine("Penguins walk funny");
    }
}