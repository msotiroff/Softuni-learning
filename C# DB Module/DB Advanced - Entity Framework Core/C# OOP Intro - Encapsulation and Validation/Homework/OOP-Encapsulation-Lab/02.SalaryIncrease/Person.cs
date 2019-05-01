class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public double Salary
    {
        get
        {
            return this.salary;
        }

        set
        {
            this.salary = value;
        }
    }


    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public void IncreaseSalary(double bonusAsRelativeValue)
    {
        if (this.age >= 30)
        {
            this.salary += this.salary * bonusAsRelativeValue / 100;
        }
        else
        {
            this.salary += (this.salary * bonusAsRelativeValue / 100) / 2;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.salary:f2} leva";
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
        }
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
        }
    }
}
