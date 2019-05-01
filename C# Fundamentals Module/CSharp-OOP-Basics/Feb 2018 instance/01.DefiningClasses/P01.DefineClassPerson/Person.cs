﻿public class Person
{
    private string name;
    private int age;

    public Person()
    {
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}