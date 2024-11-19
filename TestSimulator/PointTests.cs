using System;
using Simulator;
using Xunit;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(3, 2, "(3, 2)")]
    [InlineData(7, 15, "(7, 15)")]
    [InlineData(-3, -4, "(-3, -4)")]
    [InlineData(200, 100, "(200, 100)")]
    public void ToString_ShouldReturnCorrectFormat(int x, int y, string expected)
    {
        var point = new Point(x, y);

        var result = point.ToString();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(6, 7, Direction.Left, 5, 7)]
    [InlineData(6, 7, Direction.Right, 7, 7)]
    [InlineData(6, 7, Direction.Up, 6, 8)]
    [InlineData(6, 7, Direction.Down, 6, 6)]
    [InlineData(2, 3, Direction.Left, 1, 3)]
    [InlineData(2, 3, Direction.Down, 2, 2)]
    [InlineData(15, 14, Direction.Right, 16, 14)]
    [InlineData(15, 14, Direction.Up, 15, 15)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);

        var nextPoint = point.Next(direction);

        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(6, 6, Direction.Left, 5, 7)]
    [InlineData(6, 6, Direction.Right, 7, 5)]
    [InlineData(6, 6, Direction.Up, 7, 7)]
    [InlineData(6, 6, Direction.Down, 5, 5)]
    [InlineData(3, 4, Direction.Left, 2, 5)]
    [InlineData(3, 4, Direction.Down, 2, 3)]
    [InlineData(14, 13, Direction.Right, 15, 12)]
    [InlineData(14, 13, Direction.Up, 15, 14)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);

        var nextPoint = point.NextDiagonal(direction);

        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
