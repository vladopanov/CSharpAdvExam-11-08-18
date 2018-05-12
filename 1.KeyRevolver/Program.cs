using System;
using System.Linq;

namespace _1.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            byte bulletPrice = byte.Parse(Console.ReadLine());
            ushort gunBarrellSize = ushort.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(' ').Select(x => byte.Parse(x)).ToList();
            var locks = Console.ReadLine().Split(' ').Select(x => byte.Parse(x)).ToList();
            int intelligenceValue = int.Parse(Console.ReadLine());

            int shots = 0;
            ushort bulletsLeftInBarrel = gunBarrellSize;
            for (int i = 0; i < locks.Count;) {
                if (bullets[bullets.Count - 1] <= locks[i])
                {
                    Console.WriteLine("Bang!");
                    locks.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletsLeftInBarrel -= 1;
                bullets.RemoveAt(bullets.Count - 1);
                shots += 1;

                if (bulletsLeftInBarrel <= 0 & bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsLeftInBarrel = gunBarrellSize;
                }

                if (locks.Count <= 0)
                {
                    int bulletsCost = shots * bulletPrice;
                    int moneyEarned = intelligenceValue - bulletsCost;
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${ moneyEarned}");
                    break;
                }
                if (bullets.Count <= 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}
