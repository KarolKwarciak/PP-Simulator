namespace Simulator;

internal class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init
        {
            string trimmedName = value?.Trim() ?? "Unknown";
            if (trimmedName.Length < 3)
            {
                trimmedName = trimmedName.PadRight(3, '#');
            }
            else if (trimmedName.Length > 25)
            {
                trimmedName = trimmedName.Substring(0, 25).TrimEnd();
            }

            if (trimmedName.Length > 0 && char.IsLower(trimmedName[0]))
            {
                trimmedName = char.ToUpper(trimmedName[0]) + trimmedName[1..];
            }

            _name = trimmedName;
        }
    }

    public int Level
    {
        get => _level;
        init
        {
            _level = (value >= 1 && value <= 10) ? value : (value < 1 ? 1 : 10);
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void SayHi() => Console.WriteLine($"Hi, my name is {Name}, my level is {Level}");

    public string Info => $"{Name} - {Level}";

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        var directionArray = DirectionParser.Parse(directions);
        Go(directionArray);
    }
}
