public abstract class Creature
{
    private string name = "Unknown";

    public string Name
    {
        get => name;
        set => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level { get; private set; }

    protected Creature(string name, int level)
    {
        Name = name;
        Level = Validator.Limiter(level, 1, 10);
    }

    public abstract string Info { get; }
    public abstract int Power { get; }
    public abstract void SayHi();
}
