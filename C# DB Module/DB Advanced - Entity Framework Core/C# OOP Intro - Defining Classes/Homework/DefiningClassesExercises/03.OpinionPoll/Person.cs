class Person
{
    public string Name { get; set; } = "No name";
    public int Age { get; set; } = 1;
    
    public Person()
    {        
    }

    public Person(int age)
    {
        this.Age = age;
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
