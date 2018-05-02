using System;

namespace ProblemA
{
    class ProblemA
    {
        static void Main(string[] args)
        {
            string inputStones;
            while ((inputStones = Console.ReadLine()) != null)
            {
                int stones = int.Parse(inputStones);
                int stonesLeft = stones;
                int AliceStones = 0, BobStones = 0;
                for (int i = 1; i <= stones; i += 2)
                {
                    if (1 <= i && i <= (stones) && stonesLeft > 1)
                    {
                        AliceStones = AliceStones + 2;
                        stonesLeft -= 2;
                    }
                    else if (1 <= i && i <= (stones) && stonesLeft > 1)
                    {
                        BobStones = BobStones + 2;
                        stonesLeft -= 2;
                    }

                }

                    if (stonesLeft % 2 == 1)
                    {
                        Console.WriteLine("Alice");
                    }
                    else
                    {
                        Console.WriteLine("Bob");
                    }
                }
            }
        }
    }
