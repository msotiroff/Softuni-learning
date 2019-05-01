using System;

public class Child : Person
{
    public Child(string name, int age)
        : base(name, age)
    {
        this.Age = age;
    }

    public override int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            else if (value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }

            base.age = value;
        }
    }
}