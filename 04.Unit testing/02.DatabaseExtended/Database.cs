using System;
using System.Collections.Generic;
using System.Linq;

public class Database
{
    private List<Person> users;

    public Database()
    {
        this.users = new List<Person>();
    }

    public Database(params Person[] users)
        : this()
    {
        foreach (var user in users)
        {
            AddUser(user);
        }
    }

    public void AddUser(Person user)
    {
        var userByUsername = this.users
            .FirstOrDefault(u => u.Username == user.Username);
        if (userByUsername != null)
        {
            throw new InvalidOperationException("Username already taken!");
        }

        var userById = this.users
            .FirstOrDefault(u => u.Id == user.Id);
        if (userById != null)
        {
            throw new InvalidOperationException("ID already exists!");
        }

        this.users.Add(user);
    }

    public void Remove()
    {
        if (!users.Any())
        {
            throw new InvalidOperationException("There is no users to remove!");
        }
        var lastUser = this.users.Last();
        this.users.Remove(lastUser);
    }

    public Person FindByUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentNullException("username", "Username cannot be empty!");
        }

        var user = this.users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            throw new InvalidOperationException("There is no person with that username");
        }

        return user;
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("id", "ID cannot be negative!");
        }

        var user = this.users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            throw new InvalidOperationException("There is no person with that id");
        }

        return user;
    }
}
