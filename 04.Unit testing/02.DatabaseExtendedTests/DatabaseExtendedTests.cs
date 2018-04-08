using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class DatabaseExtendedTests
{
    [Test]
    public void ConstructorInitializationTest()
    {
        var usersToAdd = new Person[]
        {
                new Person(1,"Georgi"),
                new Person(2,"Dimitar"),
                new Person(3,"Ivan"),
                new Person(4,"Petar"),
        };

        var db = new Database(usersToAdd);
        var fielInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.FieldType == typeof(List<Person>));
        var userField = (List<Person>)fielInfo.GetValue(db);

        Assert.That(userField.Count, Is.EqualTo(usersToAdd.Length));
    }

    [Test]
    public void AddUserMethodSameIdExceptionTest()
    {
        var usersToAdd = new Person[]
        {
                new Person(1,"Georgi"),
                new Person(2,"Dimitar"),
                new Person(3,"Ivan"),
        };

        var db = new Database(usersToAdd);
        var invalidUser = new Person(1, "Petar");

        Assert.That(() => db.AddUser(invalidUser), Throws.InvalidOperationException);
    }

    [Test]
    public void AddUserMethodSameUsernameExceptionTest()
    {
        var usersToAdd = new Person[]
        {
                new Person(1,"Georgi"),
                new Person(2,"Dimitar"),
                new Person(3,"Ivan"),
        };

        var db = new Database(usersToAdd);
        var invalidUser = new Person(11, "Georgi");

        Assert.That(() => db.AddUser(invalidUser), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByUsernameMethodEmptyUsernameExceptionTest()
    {
        var db = new Database(new Person(43, "Ivan"));

        Assert.That(() => db.FindByUsername(string.Empty), Throws.ArgumentNullException);
    }

    [Test]
    public void FindByIdMethodNegativeIDExceptionTest()
    {
        var db = new Database(new Person(43, "Ivan"));

        Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
    }

    [Test]
    public void FindByUsernameNotFoundExceptionTest()
    {
        var db = new Database(new Person(43, "Ivan"));

        Assert.That(() => db.FindByUsername("Georgi"), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByIdNotFoundExceptionTest()
    {
        var db = new Database(new Person(43, "Ivan"));

        Assert.That(() => db.FindById(1), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByUserNameTest()
    {
        var user = new Person(43, "Ivan");
        var db = new Database(user);

        var foundedUser = db.FindByUsername(user.Username);

        Assert.That(foundedUser, Is.EqualTo(user));
    }

    [Test]
    public void FindByIDTest()
    {
        var user = new Person(43, "Ivan");
        var db = new Database(user);

        var foundedUser = db.FindById(user.Id);

        Assert.That(foundedUser, Is.EqualTo(user));
    }

    [Test]
    public void RemoveMethodOnEmptydatabaseTest()
    {
        var db = new Database();

        Assert.That(() => db.Remove(), Throws.InvalidOperationException);
    }

    [Test]
    public void RemoveMethodTest()
    {
        var db = new Database(new Person(43, "Ivan"));

        db.Remove();
        var fielInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.FieldType == typeof(List<Person>));
        var userField = (List<Person>)fielInfo.GetValue(db);

        Assert.That(userField.Count, Is.EqualTo(0));
    }
}
