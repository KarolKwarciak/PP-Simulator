﻿using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    public virtual char Symbol => 'C';
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    private string name = "Unknown";
    private int level = 1;


    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public abstract int Power { get; }
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public abstract string Info { get; }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public Creature() { }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (level < 10) { level++; }
    }

    public void MapAndPosition(Map map, Point position)
    {
        if (!map.Exist(position))
        {
            throw new ArgumentException("This location doesn't exist on this map!");
        }
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }
        if (Map != null)
        {
            throw new InvalidOperationException($"You cannot transfer this creature to a different map because it is already placed on one!");
        }


        Position = position;
        Map = map;
        map.Add(this, position);
    }

    public void Go(Direction direction)
    {
        if (Map == null)
        {
            throw new InvalidOperationException("This creature cannot move because it is not currently on the map!");
        }
        var newPosition = Map.Next(Position, direction);

        Map.Move(this, Position, newPosition);

        Position = newPosition;
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        throw new NotImplementedException();
    }
}