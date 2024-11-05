namespace Simulator;

public class Orc : Creature
{
    private int huntCount = 0;
    private int _rage;

    public Orc() : base("Unknown", 1)
    {
        _rage = 1; 
    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public int Rage
    {
        get => _rage;
        private set => _rage = Math.Clamp(value, 0, 10);
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, an orc at level {Level} with rage {Rage}.");

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        huntCount++;
        if (huntCount % 2 == 0 && Rage < 10)
        {
            Rage++;
            Console.WriteLine($"{Name}'s rage increased to {Rage}!");
        }
    }

    public override int Power => 7 * Level + 3 * Rage;
}
