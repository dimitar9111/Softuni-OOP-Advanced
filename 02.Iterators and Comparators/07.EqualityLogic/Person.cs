using System;
using System.Linq;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public override bool Equals(object obj)
    {
        var objectAsPerson = obj as Person;
        var comparison = this.Name == objectAsPerson.Name && this.Age == objectAsPerson.Age;

        return comparison;
    }

    public override int GetHashCode()
    {
        var hashCode = this.Name.Length * 10000;
        foreach (var letter in this.Name)
        {
            hashCode += letter;
        }

        hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
        hashCode += this.Age * 10000000;

        return hashCode;
    }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }
}