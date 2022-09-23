using System;
using System.Linq;
using System.Collections.Generic;

class Bestelbus
{
    public static void Main()
    {
        string pakrit = Console.ReadLine();
        pakrit = pakrit.Trim();
        string[] arr = pakrit.Split();
        long qpakjes = long.Parse(arr[0]);
        long ritjes = long.Parse(arr[1]);

        List<long> pakjesList = new List<long>();
        while (qpakjes != pakjesList.Count)
        {
            string pakje = Console.ReadLine();
            pakje = pakje.Trim();
            string[] regel = pakje.Split();
            for (long j = 0; j < regel.Length; j++)
            {
                pakjesList.Add(long.Parse(regel[j]));
            }

        }
        long[] pakjesArray = pakjesList.ToArray();

        Console.WriteLine(zoekOmvang(pakjesArray, ritjes, pakjesArray.Length));
    }

    static long Mogelijk(long[] pakjes, long ritjes,
                            long l, long maxomvang)
    {
        long omvang1 = 0;
        long qritjes = 1;
        for (long a = 0; a < l; a++)
        {
            omvang1 += pakjes[a];
            if (maxomvang < omvang1)
            {
                qritjes++;
                omvang1 = pakjes[a];
            }

            if (ritjes < qritjes)
            {
                return 0;
            }
        }
        return 1;
    }

    static long zoekOmvang(long[] pakjes, long ritjes, long l)
    {

        long grootsteomvang = 0;

        if (ritjes == 1)
        {
            long sum = 0;
            for (long b = 0; b < pakjes.Length; b++)
            {
                sum += pakjes[b];
            }
            return sum;
        }

        for (long j = 0; j < l; j++)
        {
            grootsteomvang += pakjes[j];
        }

        long min = pakjes[0];
        for (long k = 1; k < l; k++)
        {
            min = Math.Max(min, pakjes[k]);
        }

        long max = grootsteomvang;
        long eindOmvang = 0;

        while (min <= max)
        {
            long midden = min + (max-min)/2;

            if (Mogelijk(pakjes, ritjes, l, midden) == 1)
            {
                max = midden - 1;
                eindOmvang = midden; 
            }

            else
            {
                min = midden + 1;
            }
                
        }
        return eindOmvang;
    }
}