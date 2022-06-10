using System;
class Hallo2
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        string dat1;
        Console.WriteLine("Wat is je geboortedag? (1 t/m 31)");
        dat1 = Console.ReadLine();
        int dat01 = Int32.Parse(dat1);

        string dat2;
        Console.WriteLine("Wat is je geboortemaand? (1 t/m 12)");
        dat2 = Console.ReadLine();
        int dat02 = Int32.Parse(dat2);

        string dat3;
        Console.WriteLine("Wat is je geboortejaar?");
        dat3 = Console.ReadLine();
        int dat03 = Int32.Parse(dat3);

        DateTime dt2 = new DateTime(dat03, dat02, dat01);
        var EndDate = DateTime.Now;
        var StartDate = dt2;

        var dagen = (EndDate.Date - StartDate.Date).Days;
        Console.WriteLine("Je bent " + dagen + " dagen oud.");

        var Kdag = dagen % 1000;
        Console.WriteLine("Je volgende verKdagdag is over " + (1000 - Kdag) + " dagen.");
        var NKdag = ((dagen + (1000 - Kdag)) / 1000);
        if ((NKdag % 10) == 1)
            Console.WriteLine("Dat is je " + NKdag + "ste verKdagdag.");
        else
            Console.WriteLine("Dat is je " + NKdag + "de verKdagdag.");
        Console.ReadKey();

    }
}