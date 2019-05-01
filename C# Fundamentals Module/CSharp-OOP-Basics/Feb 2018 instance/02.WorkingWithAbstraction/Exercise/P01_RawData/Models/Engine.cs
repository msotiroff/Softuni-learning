namespace P01_RawData.Models
{
    public class Engine
    {
        public int Speed { get; private set; }

        public int Power { get; private set; }

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }
}