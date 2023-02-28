using System;
using System.Text;
using System.Collections.Generic;

class MijnStack
{
    public StackElement top;
    public StackElement pointer;

    public MijnStack()
    {
        top = null;
        pointer = top;
    }
    public StackElement Pop()
    {
        if (top == null)
            return null;

        StackElement n = top;
        top = top.prev;
        return n;
    }

    public void Push(char i)
    {
        StackElement n = new StackElement(i);
        n.prev = top;
        top = n;
    }

    public bool IsEmpty()
    {
        if (top == null)
            return true;
        else
            return false;
    }

    public class StackElement
    {
        public char waarde;
        public StackElement prev = null;

        public StackElement(char character)
        {
            waarde = character;
        }

    }
}

class ToetsenSpion
{
    static void Main()
    {
        List<StringBuilder> wwLijst = new List<StringBuilder>();
        int n = int.Parse(Console.ReadLine().Split(' ')[0]);
        for (int i = 0; i < n; i++)
        {
            StringBuilder x = new StringBuilder();
            StringBuilder ww = wwMaker(Console.ReadLine().Split(' ')[0], x);
            wwLijst.Add(ww);
        }
        foreach (StringBuilder ww in wwLijst)
        {
            Console.WriteLine(ww);
        }
    }

    static StringBuilder wwMaker(string wwString, StringBuilder x)
    {
        MijnStack wwStack = wwStackMaker(wwString);
        for (MijnStack.StackElement element = wwStack.top; element != null; element = element.prev)
        {
            x.Append(element.waarde);
        }
        return x;
    }

    static MijnStack wwStackMaker(string wwString)
    {
        MijnStack passwordStack1 = new MijnStack();
        MijnStack passwordStack2 = new MijnStack();
        foreach (char i in wwString)
        {
            switch (i)
            {
                case '<':
                    if (passwordStack1.IsEmpty())
                    {
                        break;
                    }
                    else
                    {
                        MijnStack.StackElement x = passwordStack1.Pop();
                        passwordStack2.Push(x.waarde);
                    }
                    break;
                case '>':
                    if (passwordStack2.IsEmpty())
                    {
                        break;
                    }
                    else
                    {
                        MijnStack.StackElement y = passwordStack2.Pop();
                        passwordStack1.Push(y.waarde);
                    }
                    break;
                case '-':
                    passwordStack1.Pop();
                    break;
                default:
                    passwordStack1.Push(i);
                    break;
            }
        }

        MijnStack passwordStack1Reverse = new MijnStack();
        while (passwordStack2.IsEmpty() == false)
        {
            MijnStack.StackElement y = passwordStack2.Pop();
            passwordStack1.Push(y.waarde);
        }

        while (passwordStack1.IsEmpty() == false)
        {
            MijnStack.StackElement y = passwordStack1.Pop();
            passwordStack1Reverse.Push(y.waarde);
        }
        return passwordStack1Reverse;
    }
}