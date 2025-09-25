// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("ForEvens(): " + ForEvens());
        Console.WriteLine("IfBigNumCheck(): " + IfBigNumCheck(ForEvens()));
        Console.WriteLine("TernaryBigNumCheck(): " + TernaryBigNumCheck(ForEvens()));

        Console.WriteLine("WhileEvens(): " + WhileEvens());
        Console.WriteLine("IfBigNumCheck(): " + IfBigNumCheck(WhileEvens()));
        Console.WriteLine("TernaryBigNumCheck(): " + TernaryBigNumCheck(WhileEvens()));

        Console.WriteLine("ForEachEvens(): " + ForEachEvens());
        Console.WriteLine("IfBigNumCheck(): " + IfBigNumCheck(ForEachEvens()));
        Console.WriteLine("TernaryBigNumCheck(): " + TernaryBigNumCheck(ForEachEvens()));

        Console.WriteLine("GetLetterGradeIf(int score): score is 73 = " + IfGetLetterGrade(73));
        Console.WriteLine("GetLetterGradeSwitch(int score): score is 73 = " + SwitchGetLetterGrade(73));

        //Console.WriteLine("IntList() test: " + string.Join(", ", IntList(1, 100)));
    }

    // I really really really wanna write overloads for these...
    static int ForEvens()
    {
        int ret = 0;
        for (int i = 1; i <= 100; i++)
            if (i % 2 == 0)
                ret += i;
        return ret;
    }
    static int WhileEvens()
    {
        int ret = 0;
        int i = 1;
        do
        {
            if (i % 2 == 0)
                ret += i;
            i++;
        } while (i <= 100);
        return ret;
    }
    static int ForEachEvens()
    {
        int ret = 0;
        // I aint typing all that...
        List<int> ints = IntList(1, 100);
        foreach (int i in ints)
            if (i % 2 == 0)
                ret += i;

        return ret;
    }

    static char IfGetLetterGrade(int score)
    {
        if (score >= 90 && score <= 100)
            return 'A';
        else if (score >= 80 && score <= 89)
            return 'B';
        else if (score >= 70 && score <= 79)
            return 'C';
        else if (score >= 60 && score <= 69)
            return 'D';
        else
            return 'F';
    }
    static char SwitchGetLetterGrade(int score)
    {
        switch (score)
        {
            case >= 90:
                return 'A';
            case >= 80:
                return 'B';
            case >= 70:
                return 'C';
            case >= 60:
                return 'D';
            default:
                return 'F';
        }
    }

    static List<int> IntList(int min, int max)
    {
        List<int> ints = new List<int>();
        for (int i = min; i <= max; i++)
        {
            ints.Add(i);
        }

        return ints;
    }
    static string IfBigNumCheck(int num)
    {
        if (num > 2000)
            return "That's a big number!";
        else return "";
    }
    static string TernaryBigNumCheck(int num) => num > 2000 ? "That's a big number!" : "";
}
