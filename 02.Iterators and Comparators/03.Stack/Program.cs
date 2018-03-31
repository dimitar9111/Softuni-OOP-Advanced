using System;

public class Program
{
    public static void Main()
    {
        Stack<int> myStack = new Stack<int>();
        var input = string.Empty; ;

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "Push":
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        myStack.Push(int.Parse(tokens[i]));
                    }
                    break;
                case "Pop":
                    try
                    {
                        myStack.Pop();
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
