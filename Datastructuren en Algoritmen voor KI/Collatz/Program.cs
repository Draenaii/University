using System;
using System.Collections.Generic;
namespace CollatzBb
{

    internal class Collatz
    {
        static void Main()
        {
            string quantity = Console.ReadLine();
            string[] arr = quantity.Split();
            int k = int.Parse(arr[0]);

            List<int> numberList = new List<int>();
            for (int i = 0; i != k; i++)
            {
                string coll = Console.ReadLine();
                string[] collarr = coll.Split();
                numberList.Add(int.Parse(collarr[0]));
            }
            Console.Clear();

            foreach (int x in numberList)
            Console.WriteLine(Lengte(x));
        }

        static int Lengte(long n)
        {
            int x = 0;
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n = n / 2;
                    x++;
                }
                else
                {
                    n = (n * 3) + 1;
                    x++;
                }
            }
            return x;
        }
    }
}