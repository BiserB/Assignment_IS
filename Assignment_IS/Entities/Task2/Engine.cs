namespace Assignment_IS.Entities.Task2
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public int Speed { get; private set; }

        public int Power { get; private set; }
    }
}
