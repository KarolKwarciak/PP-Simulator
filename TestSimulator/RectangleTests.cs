using Simulator;
using Xunit;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(4, 6, 2, 2, 2, 2, 4, 6)]
    [InlineData(2, 6, 5, 2, 2, 2, 5, 6)]
    [InlineData(-5, -5, 5, 5, -5, -5, 5, 5)]
    [InlineData(1, 1, 8, 8, 1, 1, 8, 8)]
    [InlineData(7, 7, 2, 2, 2, 2, 7, 7)]
    public void Constructor_ShouldSetCorrectCoordinates(int x1, int y1, int x2, int y2, int expectedX1, int expectedY1, int expectedX2, int expectedY2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);

        Assert.Equal(expectedX1, rectangle.X1);
        Assert.Equal(expectedY1, rectangle.Y1);
        Assert.Equal(expectedX2, rectangle.X2);
        Assert.Equal(expectedY2, rectangle.Y2);
    }

    [Theory]
    [InlineData(1, 1, 1, 7)]
    [InlineData(1, 1, 7, 1)]
    [InlineData(2, 2, 2, 6)]
    [InlineData(7, 7, 7, 7)]
    [InlineData(-6, -6, -3, -6)]
    public void Constructor_InvalidRectangle_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(2, 2, 4, 6, 3, 4, true)]
    [InlineData(2, 2, 4, 6, 5, 7, false)]
    [InlineData(2, 2, 4, 6, 2, 6, true)]
    [InlineData(2, 2, 4, 6, 4, 2, true)]
    [InlineData(0, 0, 5, 5, 3, 3, true)]
    [InlineData(0, 0, 5, 5, 0, 0, true)]
    [InlineData(0, 0, 5, 5, 5, 5, true)]
    [InlineData(0, 0, 5, 5, -1, -1, false)]
    [InlineData(0, 0, 5, 5, 6, 3, false)]
    [InlineData(0, 0, 5, 5, 3, 6, false)]
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);

        var result = rectangle.Contains(point);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 5, 5, "(0, 0):(5, 5)")]
    [InlineData(3, 3, 1, 1, "(1, 1):(3, 3)")]
    [InlineData(-5, -3, 3, 5, "(-5, -3):(3, 5)")]
    public void ToString_ShouldReturnCorrectFormat(int x1, int y1, int x2, int y2, string expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);

        var result = rectangle.ToString();

        Assert.Equal(expected, result);
    }
}
