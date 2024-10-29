namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    private bool _isNameSet = false;
    private bool _isLevelSet = false;

    public string Name
    {
        get => _name;
        set
        {
            if (_isNameSet) return; 

            value = value.Trim();

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            else if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();

                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            _name = value;
            _isNameSet = true;
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (_isLevelSet) return; 

            if (value < 1) value = 1;
            else if (value > 10) value = 10;

            _level = value;
            _isLevelSet = true;
        }
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
        _isLevelSet = false;
    }

    public Creature() { }

    public string Info => $"{Name} <{Level}>";

    public void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name}, Level {Level}");
    }

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }
}
