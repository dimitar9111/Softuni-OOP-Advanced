using NUnit.Framework;
using System.Linq;
using System.Reflection;

public class DatabaseTests
{
    [Test]
    public void ConstructorValidInitializationTest()
    {
        var values = new int[] { 1, 4, 3, 4, 6, 3, 4 };

        var db = new Database(values);
        var fieldInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.FieldType == typeof(int[]));
        var innerField = ((int[])fieldInfo.GetValue(db))
            .Take(values.Length);

        Assert.That(innerField, Is.EqualTo(values));
    }

    [Test]
    public void ConstructorInvalidiInitializationTest()
    {
        var values = new int[17];

        Assert.That(() => new Database(values), Throws.InvalidOperationException);
    }

    [Test]
    public void AddMethodThrowsExceptionWhenArrayIsFull()
    {
        var values = new int[16];
        var db = new Database(values);

        Assert.That(() => db.Add(1), Throws.InvalidOperationException);
    }

    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    [TestCase(0)]
    [TestCase(5)]
    public void AddMethodFunctionTest(int value)
    {
        var db = new Database();

        db.Add(value);
        var fieldInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.FieldType == typeof(int));
        var currentIndex = ((int)fieldInfo.GetValue(db));

        Assert.That(currentIndex, Is.EqualTo(1));
    }

    [Test]
    public void RemoveMethodFunctionTest()
    {
        var values = new int[16];
        var db = new Database(values);

        db.Remove();
        var fieldInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.FieldType == typeof(int));
        var currentIndex = ((int)fieldInfo.GetValue(db));

        Assert.That(currentIndex, Is.EqualTo(15));
    }

    [Test]
    public void TryingToRemoveFromEmtyDatabase()
    {
        var db = new Database();

        Assert.That(() => db.Remove(), Throws.InvalidOperationException);
    }


    [TestCase(16)]
    [TestCase(0)]
    public void FetchMethodTest(int length)
    {
        var values = new int[length];
        var db = new Database(values);

        var resultDB = db.Fetch();

        Assert.That(resultDB.Length, Is.EqualTo(length));
    }
}
