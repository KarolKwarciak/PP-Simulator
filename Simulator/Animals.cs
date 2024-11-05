public class Animals
{
    public required string Description { get; set; }
    public int Size { get; set; }

    public override string ToString()
    {
        return $"ANIMALS: {Description.ToUpper()} <{Size}>";
    }
}