using System;
public class Snede : IComparable<Snede>
{
    public string direction;
    public long cost;

    public Snede(string x, long y) // Snede object met eigenschap direction ("v" of "h") en cost
    {
        direction = x;
        cost = y;
    }

    public int CompareTo(Snede sn)
    {
        if (this.cost < sn.cost) { return 1; }
        if (this.cost > sn.cost) { return -1; }
        return 0;
    }
}

public static class HybridQuicksort
{
    public static void SelectionSort<T>(T[] array, long start, long end) where T : IComparable<T>
    {
        for (long i = start; i < end - 1; i++)
        {
            long minindex = i;
            long j = i + 1;
            while (j < end)
            {
                if (array[start].CompareTo(array[minindex]) < 0) { minindex = j; }
                j++;
            }
            if (array[minindex].CompareTo(array[i]) < 0)
            {
                //(array[i], array[minindex]) = (array[minindex], array[i]);
                T temp = array[i];
                array[i] = array[minindex];
                array[minindex] = temp;
            }
        }
    }

    public static void Sort<T>(T[] array, long start, long end, int k) where T : IComparable<T>
    {
        if (end - start + 1 <= k)
            SelectionSort(array, start, end);

        long left = start;
        long right = end;
        T pivot = array[start];
        while (left <= right)
        {
            while (array[left].CompareTo(pivot) < 0) { left++; }
            while (array[right].CompareTo(pivot) > 0) { right--; }
            if (left <= right)
            {
                //(array[left], array[right]) = (array[right], array[left]);
                T temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }
        if (start < right) { Sort(array, start, right, k); }
        if (left < end) { Sort(array, left, end, k); }
    }
}
class Zagerij
{
    static void Main()
    {
        string[] hbk = Console.ReadLine().Trim().Split();
        long h = long.Parse(hbk[0]); long b = long.Parse(hbk[1]); int k = int.Parse(hbk[2]);

        Snede[] allesneden = new Snede[((h - 1) + (b - 1))];
        long c = 0;
        if (h == 1 && b == 1)
        {
            Console.WriteLine("0 0");
            return;
        }

        for (int i = 0; i < h - 1; i++)
        {
            string[] hkostenstr = Console.ReadLine().Trim().Split();
            Snede x = new Snede("h", long.Parse(hkostenstr[0]));
            allesneden[c] = x;
            c++;
        }

        for (int i = 0; i < b - 1; i++)
        {
            string[] bkostenstr = Console.ReadLine().Trim().Split();
            Snede x = new Snede("v", long.Parse(bkostenstr[0]));
            allesneden[c] = x;
            c++;
        }

        Console.WriteLine(Zagen(allesneden, k));

    }

    static string Zagen(Snede[] allesneden, int k)
    {
        HybridQuicksort.Sort(allesneden, 0, allesneden.Length - 1, k);

        long kostencount = 0;
        long verticalesneden = 0;
        long horizontalesneden = 0;

        foreach (Snede snede in allesneden)
        {
            if (snede.direction == "h")
            {
                kostencount = kostencount + (snede.cost * (verticalesneden + 1));
                horizontalesneden++;
            }
            if (snede.direction == "v")
            {
                kostencount = kostencount + (snede.cost * (horizontalesneden + 1));
                verticalesneden++;
            }
        }
        long snedencount = ((horizontalesneden + 1) * (verticalesneden + 1)) - 1;
        return kostencount.ToString() + " " + snedencount.ToString();
    }

}