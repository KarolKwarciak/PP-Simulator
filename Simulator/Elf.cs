public class Elf : Creature
{
    private int agility;

    public Elf() : this("Unknown", 1, 0) { }

    public Elf(string name, int level, int agility)
        : base(name, level)
    {
        Agility = agility;
    }

    public int Agility
    {
        get { return agility; }
        private set { agility = Validator.Limiter(value, 0, 10); }
    }

    public override string Info => $"E## [{Agility}]";

    public override int Power => 8 * Level + 2 * Agility;

    public override string Greeting()
    {
        Console.WriteLine($"Hi, I'm {Name}, an elf at level {Level} with agility {Agility}.");
    }

    public void Sing()
    {
        if (++singCount % 3 == 0)
        {
            Agility++;
        }
    }

    private int singCount = 0;

    public override string ToString() // Add this method
    {
        return $"ELF: {Name} [{Level}][{Agility}]"; // Adjust to desired format
    }
}
