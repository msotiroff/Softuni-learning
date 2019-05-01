namespace Animals.Models
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        protected override string ProduceSound()
        {
            return "BauBau";
        }
    }
}
