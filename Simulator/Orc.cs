public class Orc : Creature
{
    private int rage;
    private int huntCount = 0;

    public int Rage
    {
        get => rage;
        private set => rage = Validator.Limiter(value, 0, 10);
    }

    public Orc(string name, int level, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }

    public override string Info => $"{Rage}";

    public override int Power => 7 * Level + 3 * Rage;

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, an orc at level {Level} with rage {Rage}.");
    }

    public void Hunt()
    {
        huntCount++;
        Console.WriteLine($"{Name} is hunting.");

        if (huntCount % 2 == 0)
        {
            Rage++;
            Console.WriteLine($"Rage increased to {Rage}.");
        }
    }

    public override string ToString() // Add this method
    {
        return $"ORC: {Name} [{Level}][{Rage}]"; // Adjust to desired format
    }
}
