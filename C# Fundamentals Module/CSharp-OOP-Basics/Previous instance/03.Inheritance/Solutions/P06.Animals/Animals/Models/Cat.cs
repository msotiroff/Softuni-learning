namespace Animals.Models
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        protected override string ProduceSound()
        {
            return "MiauMiau";
        }
    }
}
