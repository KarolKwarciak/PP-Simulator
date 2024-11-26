using Simulator.Maps;
using System.Drawing;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {

        Lab7();

    }

    static void Lab7()
    {
        var squareMap = new SmallSquareMap(5);
        var elf = new Elf("Elf", 3, 2);

        elf.MapAndPosition(squareMap, new Point(1,0));

        Console.WriteLine($"Elf position on the square map: {elf.Position}");

        Console.WriteLine(elf.Go(Direction.Up));
        Console.WriteLine(elf.Go(Direction.Right));

        Console.WriteLine($"Elf new position after all moves on the square map: {elf.Position}");

        var squareMapPositionCreatures = squareMap.At(2,1);
        Console.WriteLine($"Number of creatures at point (2,1) on the square map: {squareMapPositionCreatures?.Count ?? 0}");

        var squareMapPositionCreatures2 = squareMap.At(1,0);
        Console.WriteLine($"Number of creatures at point (1,0) on the square map: {squareMapPositionCreatures2?.Count ?? 0}");

        var squareMapPositionCreatures3 = squareMap.At(3,2);
        Console.WriteLine($"Number of creatures at point (3,2) on the square map: {squareMapPositionCreatures3?.Count ?? 0}");


        Console.WriteLine();
        Console.WriteLine();

        var torusMap = new SmallTorusMap(5, 5);
        var orc = new Orc("Orc", 2, 2);

        orc.MapAndPosition(torusMap, new Point(2,2));

        Console.WriteLine($"Orc position on the torus map: {orc.Position}");

        Console.WriteLine(orc.Go(Direction.Left));
        Console.WriteLine(orc.Go(Direction.Down));
        Console.WriteLine(orc.Go(Direction.Up));
        Console.WriteLine(orc.Go(Direction.Up));

        Console.WriteLine($"Orc new position after all moves on the torus map: {orc.Position}");
        var torusMapPositionCreatures = torusMap.At(1,1);
        Console.WriteLine($"Number of creatures at point (1,1) on the torus map: {torusMapPositionCreatures?.Count ?? 0}");

        var torusMapPositionCreatures2 = torusMap.At(1,3);
        Console.WriteLine($"Number of creatures at point (1,3) on the torus map: {torusMapPositionCreatures2?.Count ?? 0}");

        var torusMapPositionCreatures3 = torusMap.At(2,2);
        Console.WriteLine($"Number of creatures at point (2,2) on the torus map: {torusMapPositionCreatures3?.Count ?? 0}");
    }

}