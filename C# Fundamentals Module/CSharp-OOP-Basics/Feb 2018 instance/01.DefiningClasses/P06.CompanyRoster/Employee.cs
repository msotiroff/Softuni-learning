
class Employee
{
    // name, salary, position, department, email and age

    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = "n/a";
        this.Age = -1;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age)
        : this (name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
        : this (name, salary, position, department)
    {
        this.Email = email;
    }
    
    public Employee(string name, decimal salary, string position, string department, int age) 
        : this(name, salary, position, department)
    {
        this.age = age;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    public string Email
    {
        get { return email; }
        set { email = value; }
    }


    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }


    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.salary:f2} {this.email} {this.age}";
    }
}