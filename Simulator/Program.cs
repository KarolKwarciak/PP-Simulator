using System;

namespace Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Lab4a();
            Lab4b();
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
    }
}
