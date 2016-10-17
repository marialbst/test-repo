using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftuniWaterSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            long waterAvailable = long.Parse(Console.ReadLine());
            List<double> bottles = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            long bottlesCapacity = long.Parse(Console.ReadLine());

            double waterInBottles = bottles.Sum();
            double initial = waterAvailable;
            double neededWater = bottlesCapacity * bottles.Count - waterInBottles;
            //проверявам дали водата, която имам е достатъчна, за да остане
            if (waterAvailable >= neededWater)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine("Water left: {0}l.", waterAvailable - neededWater);
            }
            else //ако не е - започвам да пълня
            {
                long counter = 0;
                Console.WriteLine("We need more water!");
                //за нечетно к-во
                if (waterAvailable % 2 != 0)
                {
                    FillBottlesForOddQuantity(bottles, bottlesCapacity, ref initial, ref counter);
                }
                else //за четно количество
                {
                    FillBottlesForEvenQuantity(bottles, bottlesCapacity, ref initial, ref counter);
                }

                Console.WriteLine();
                Console.WriteLine("We need {0} more liters!", neededWater - waterAvailable);
            }
        }

        private static void FillBottlesForEvenQuantity(List<double> bottles, long bottlesCapacity, ref double initial, ref long counter)
        {
            for (int i = 0; i > bottles.Count; i++)
            {
                double needed = bottlesCapacity - bottles[i];

                if (initial < needed)
                {
                    break;
                }
                else
                {
                    bottles[i] += needed;
                    initial -= needed;
                    counter++;
                }

            }
            Console.WriteLine("Bottles left: {0}", bottles.Count - counter);
            Console.Write("With indexes: ");
            for (long i = 0; i < bottles.Count - counter; i++)
            {
                if (i == bottles.Count - counter - 1)
                {
                    Console.Write("{0}", i);
                }
                else
                {
                    Console.Write("{0}, ", i);
                }
            }
        }

        private static void FillBottlesForOddQuantity(List<double> bottles, long bottlesCapacity, ref double initial, ref long counter)
        {
            for (int i = bottles.Count - 1; i >= 0; i--)
            {
                double needed = bottlesCapacity - bottles[i];

                if (initial < needed)
                {
                    break;
                }
                else
                {
                    bottles[i] += needed;
                    initial -= needed;
                    counter++;
                }
            }


            Console.WriteLine("Bottles left: {0}", bottles.Count - counter);
            Console.Write("With indexes: ");

            for (long i = (bottles.Count - counter - 1); i >= 0; i--)
            {
                if (i == 0)
                {
                    Console.Write("{0}", i);
                }
                else
                {
                    Console.Write("{0}, ", i);
                }
            }
        }
    }
}
