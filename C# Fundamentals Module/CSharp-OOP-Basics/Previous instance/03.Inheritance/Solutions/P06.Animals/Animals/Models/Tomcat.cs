using System;

namespace Animals.Models
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) 
            : base(name, age, "Male")
        {
        }
        
        protected override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}
