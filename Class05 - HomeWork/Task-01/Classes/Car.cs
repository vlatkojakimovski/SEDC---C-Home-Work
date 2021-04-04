

using Task_01.Class;

namespace Task_01.Classes
{
    class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver driver { get; set; } = new Driver();


        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public int CalculateSpeed()
        {
            return Speed * driver.Skill;
        }
    }
}
