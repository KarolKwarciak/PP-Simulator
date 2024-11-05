namespace Simulator;

public class Elf : Creature
{
    private int agilityCount = 0;
    private int _agility;

    public Elf() : base("Unknown", 1)
    {
        _agility = 1; 
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public int Agility
    {
        get => _agility;
        private set => _agility = Math.Clamp(value, 0, 10);
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, an elf at level {Level} with agility {Agility}.");

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        agilityCount++;
        if (agilityCount % 3 == 0 && Agility < 10)
        {
            Agility++;
            Console.WriteLine($"{Name}'s agility increased to {Agility}!");
        }
    }

    public override int Power => 8 * Level + 2 * Agility;
}
