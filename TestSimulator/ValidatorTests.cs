using Simulator;
using Xunit;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(7, 2, 12, 7)]
    [InlineData(3, 4, 14, 4)]
    [InlineData(16, 4, 14, 14)]
    [InlineData(6, 6, 11, 6)]
    [InlineData(13, 9, 13, 13)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("test", 4, 8, '_', "Test")]
    [InlineData("too long value", 6, 11, '*', "Too long va")]
    [InlineData("short", 9, 13, '-', "Short----")]
    [InlineData("  whitespace  ", 6, 10, '_', "Whitespace")]
    [InlineData("a                            troll name", 5, 15, '#', "A####")]
    [InlineData("Mice           are great", 4, 13, '#', "Mice")]
    [InlineData("  ", 3, 25, '#', "###")]
    [InlineData("Puss in Boots – a clever and brave cat.", 4, 24, '#', "Puss in Boots – a clever")]
    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_ShouldHandleEmptyString()
    {
        string value = "";
        int min = 6;
        int max = 11;
        char placeholder = '_';

        var result = Validator.Shortener(value, min, max, placeholder);

        Assert.Equal("______", result);
    }

    [Fact]
    public void Shortener_ShouldConvertFirstCharacterToUppercase()
    {
        string value = "lowercase";
        int min = 6;
        int max = 14;
        char placeholder = '_';

        var result = Validator.Shortener(value, min, max, placeholder);

        Assert.Equal("Lowercase", result);
    }
}
