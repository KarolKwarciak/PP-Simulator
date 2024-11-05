namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public string Name
    {
        get => name;
        init
        {
            name = string.IsNullOrEmpty(value) ? "Unknown" : value.Trim();
            name = name.Length >= 3 ? name : name + new string('#', 3 - name.Length);
            name = name.Length > 25 ? name[..25] : name;
            name = char.ToUpper(name[0]) + name[1..];
        }
    }

    public int Level
    {
        get => level;
        init => level = value is < 1 ? 1 : value > 10 ? 10 : value;
    }

    public abstract void SayHi();

    public abstract int Power { get; }

    public void Upgrade() => level = level < 10 ? level + 1 : level;
}
