using Simulator.maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    private readonly Rectangle granica;
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("Wrong size!");
        Size = size;    
        granica = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point p) => granica.Contains(p);

    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        return new Point((moved.X + Size) % Size, (moved.Y + Size) % Size);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        return new Point((moved.X + Size) % Size, (moved.Y + Size) % Size);
    }
}