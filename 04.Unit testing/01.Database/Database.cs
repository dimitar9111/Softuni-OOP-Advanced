using System;

public class Database
{
    private const int ArrayInitialSize = 16;

    private int[] numbers;
    private int currentIndex;

    public Database()
    {
        this.numbers = new int[ArrayInitialSize];
        this.currentIndex = 0;
    }

    public Database(params int[] inputNumbers)
        : this()
    {
        this.numbers = InitializeArray(inputNumbers);
    }

    private int[] InitializeArray(int[] inputNumbers)
    {
        if (inputNumbers.Length > ArrayInitialSize)
        {
            throw new InvalidOperationException("Array size must be less than 16!");
        }

        Array.Copy(inputNumbers, this.numbers, inputNumbers.Length);
        this.currentIndex = inputNumbers.Length;

        return this.numbers;
    }

    public void Add(int number)
    {
        if (this.currentIndex >= ArrayInitialSize)
        {
            throw new InvalidOperationException("The array is full");
        }

        this.numbers[currentIndex] = number;
        currentIndex++;
    }

    public void Remove()
    {
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException("The array is empty");
        }

        currentIndex--;
        this.numbers[currentIndex] = 0;
    }

    public int[] Fetch()
    {
        var resultArray = new int[this.currentIndex];
        Array.Copy(this.numbers, resultArray, currentIndex);

        return resultArray;
    }
}
