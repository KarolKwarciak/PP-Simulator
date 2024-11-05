public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override string ToString()
    {
        return $"BIRDS: {Description.ToUpper()} (fly{(CanFly ? "+" : "-")}) <{Size}>";
    }
}
