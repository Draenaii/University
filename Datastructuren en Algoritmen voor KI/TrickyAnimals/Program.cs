using System.Collections.Generic;
using System;
using System.Text;

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

public class Node
{
    public string kie;
    public Node afstam;
    public char method;

    public Node(char a, string b, Node c)
    {
        kie = b;
        afstam = c;
        method = a;
    }
}

public class TrickyAnimals
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine().Trim());
        string[] orders = new string[n];

        for (int i = 0; i < orders.Length; i++)
        {
            string order = Console.ReadLine().Trim().Split()[0];
            orders[i] = order;
        }

        for (int i = 0; i < orders.Length; i++)
        {
            Node root = new Node(char.MinValue, orders[i], null);
            Queue<Node> gezien = new Queue<Node>();
            Dictionary<string, Node> bezocht = new Dictionary<string, Node>();

            bezocht.Add(root.kie, root);
            gezien.Enqueue(root);

            Tricky(root, gezien, bezocht);
        }
    }

    static string axbvolgorde(Dictionary<string, Node> bezocht, string goed)
    {
        int i = 0;
        StringBuilder axbmethodes = new StringBuilder();
        Node x = bezocht[goed];
        while (x.afstam != null)
        {
            i++;
            axbmethodes.Insert(0, x.method);
            x = x.afstam;
        }
        return i + " " + axbmethodes;
    }

    static void Tricky(Node root, Queue<Node> gezien, Dictionary<string, Node> bezocht)
    {
        string volgorde = "DaKi";

        char[] kieChars = new char[root.kie.Length];
        for (int i = 0; i < kieChars.Length; i++)
        {
            kieChars[i] = root.kie[i];
        }

        //HybridQuicksort van Zagerij opdracht om de juiste volgorde te krijgen. Gelijk goed bewijs dat ie met meer dan alleen Snede objecten kan omgaan.
        HybridQuicksort.Sort(kieChars, 0, kieChars.Length - 1, 10);
        //Array.Sort(kieChars);

        string goed = string.Join("", kieChars);

        // Als de Queue nog niet leeg is door blijven gaan.
        while (gezien.Count > 0)
        {
            Node patient = gezien.Dequeue();
            if (patient.kie == goed)
            {
                volgorde = axbvolgorde(bezocht, goed);
                break;
            }

            //int c = patient.kie.Length;
            int c1 = patient.kie.Length - 1;
            int c2 = patient.kie.Length - 2;

            // Function for A
            StringBuilder akie = new StringBuilder();

            // Verwissel eerste twee elementen
            akie.Append(patient.kie[1]);
            akie.Append(patient.kie[0]);

            /*for (int i = 2; i < c2; i++)
                akie.Append(patient.kie[i]);*/
            akie.Append(patient.kie.Substring(2, c2));

            Node A = new Node('a', akie.ToString(), patient);
            if (!bezocht.ContainsKey(A.kie))
            {
                bezocht.Add(A.kie, A);
                gezien.Enqueue(A);
            }

            // Function for X
            StringBuilder xkie = new StringBuilder();

            // Roteert de elementen vanaf 2 tot een na laatste
            xkie.Append(patient.kie[0]);
            xkie.Append(patient.kie[c2]);
            for (int i = 1; i < c2; i++)
            {
                xkie.Append(patient.kie[i]);
            }
            xkie.Append(patient.kie[c1]);

            Node X = new Node('x', xkie.ToString(), patient);
            if (!bezocht.ContainsKey(X.kie))
            {
                bezocht.Add(X.kie, X);
                gezien.Enqueue(X);
            }

            // Function for B
            StringBuilder bkie = new StringBuilder();

            // Verwissel laatste twee elementen
            bkie.Append(patient.kie.Substring(0, c2));
            /*for (int i = 0; i < c2; i++)
                bkie.Append(patient.kie[i]);*/

            bkie.Append(patient.kie[c1]);
            bkie.Append(patient.kie[c2]);

            Node B = new Node('b', bkie.ToString(), patient);
            if (!bezocht.ContainsKey(B.kie))
            {
                bezocht.Add(B.kie, B);
                gezien.Enqueue(B);
            }
            int x = 5;
        }

        Console.WriteLine(volgorde);
    }
}