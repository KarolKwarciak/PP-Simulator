using Simulator.Maps;
using Simulator;
using System;
using Xunit;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int size = 8;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)] 
    [InlineData(21)] 
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(6, 7, 10, true)]  
    [InlineData(12, 5, 10, false)]
    [InlineData(9, 9, 10, true)]  
    [InlineData(10, 10, 10, false)] 
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(7, 9, Direction.Up, 7, 10)]   
    [InlineData(7, 10, Direction.Down, 7, 9)]  
    [InlineData(8, 8, Direction.Left, 7, 8)]   
    [InlineData(9, 7, Direction.Right, 10, 7)] 
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(15);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 6, Direction.Up, 5, 6)]     
    [InlineData(5, 5, Direction.Down, 5, 4)]   
    [InlineData(6, 6, Direction.Left, 6, 6)]   
    [InlineData(6, 6, Direction.Right, 6, 6)]  
    public void Next_ShouldReturnTheSamePoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(6);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(8, 8, Direction.Up, 9, 9)]     
    [InlineData(9, 9, Direction.Down, 8, 8)]  
    [InlineData(9, 10, Direction.Left, 8, 11)] 
    [InlineData(10, 9, Direction.Right, 11, 8)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(15);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 6, Direction.Up, 5, 6)]     
    [InlineData(6, 7, Direction.Down, 5, 6)]   
    [InlineData(5, 5, Direction.Left, 4, 6)]   
    [InlineData(6, 6, Direction.Right, 6, 6)]  
    public void NextDiagonal_ShouldReturnTheSamePoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(7);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
