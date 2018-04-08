using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ListIteratorTests
{
    private string[] collection;
    private ListIterator listIterator;

    [SetUp]
    public void CollectionInit()
    {
        this.collection = new string[] { "one", "two", "three" };
        this.listIterator = new ListIterator(this.collection);
    }

    [Test]
    public void ConstructorInitializationTest()
    {
        var fieldInfo = typeof(ListIterator)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.FieldType == typeof(IList<string>));

        var indexField = (IList<string>)fieldInfo.GetValue(this.listIterator);

        Assert.That(indexField.Count, Is.EqualTo(collection.Length));
    }

    [Test]
    public void MoveMethodTest()
    {
        this.listIterator.Move();
        var fieldInfo = typeof(ListIterator)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.FieldType == typeof(int));
        var indexField = (int)fieldInfo.GetValue(this.listIterator);

        Assert.That(indexField, Is.EqualTo(1));
    }

    [Test]
    public void MoveMethodReturnsFalse()
    {
        this.listIterator.Move();
        this.listIterator.Move();
        var result = this.listIterator.Move();

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void HasNextMethodFalseTest()
    {
        this.listIterator.Move();
        this.listIterator.Move();
        var result = this.listIterator.HasNext();

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void HasNextMethodTrueTest()
    {
        var result = this.listIterator.HasNext();

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void PrintMethodWithEmptyCollectionTest()
    {
        var emptyListIterator = new ListIterator();

        Assert.That(() => emptyListIterator.Print(), Throws.InvalidOperationException);
    }

    [Test]
    public void PrintMethodTest()
    {
        var element = this.listIterator.Print();

        Assert.That(element, Is.EqualTo(this.collection[0]));
    }
}

