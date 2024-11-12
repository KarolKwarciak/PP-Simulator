using System;

namespace Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Lab5a();
        }

        static void Lab4a()
        {
            Console.WriteLine("HUNT TEST\n");
            var orc = new Orc("Gorbag", 1, 7);
            orc.SayHi();
            for (int i = 0; i < 10; i++)
            {
                orc.Hunt();
                orc.SayHi();
            }

            Console.WriteLine("\nSING TEST\n");
            var elf = new Elf("Legolas", 1, 2);
            elf.SayHi();
            for (int i = 0; i < 10; i++)
            {
                elf.Sing();
                elf.SayHi();
            }

            Console.WriteLine("\nPOWER TEST\n");
            Creature[] creatures = {
                orc,
                elf,
                new Orc("Morgash", 3, 8),
                new Elf("Elandor", 5, 3)
            };
            foreach (Creature creature in creatures)
            {
                Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
            }
        }

        static void Lab4b()
        {
            object[] myObjects = {
                new Animals() { Description = "dogs", Size = 3 },
                new Birds() { Description = "eagles", Size = 10 },
                new Elf("Elandor", 10, 0),
                new Orc("Morgash", 6, 4)
            };

            Console.WriteLine("\nMy objects:");
            foreach (var o in myObjects)
            {
                Console.WriteLine(o);
            }
        }
        static void Lab5a()
        {
            try
            {
                var rect1 = new Rectangle(5, 6, 2, 2);
                Console.WriteLine(rect1);
                var rect2 = new Rectangle(2, 6, 5, 2);
                Console.WriteLine(rect2);
                try
                {
                    var rect3 = new Rectangle(2, 2, 2, 6);
                    Console.WriteLine(rect3);
                }
                catch (ArgumentException expectation)
                {
                    Console.WriteLine($"{expectation.Message}");
                }
                var p1 = new Point(2, 2);
                var p2 = new Point(5, 6);
                var rect4 = new Rectangle(p1, p2);
                Console.WriteLine(rect4);

                var pointInside = new Point(3, 3);
                var pointOutside = new Point(1, 1);
                var pointOnEdge = new Point(2, 6);
                var pointOnEdge2 = new Point(5, 2);
                Console.WriteLine($"Point {pointInside} inside the rectangle? {rect4.Contains(pointInside)}");
                Console.WriteLine($"Point {pointOutside} inside the rectangle? {rect4.Contains(pointOutside)}");
                Console.WriteLine($"Point {pointOnEdge} inside the rectangle? {rect4.Contains(pointOnEdge)}");
                Console.WriteLine($"Point {pointOnEdge2} inside the rectangle? {rect4.Contains(pointOnEdge2)}");
            }
            catch (Exception expectation)
            {
                Console.WriteLine($"{expectation.Message}");
            }
        }
    }
}
