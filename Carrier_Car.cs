using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Carrier_Car
    {
        private int id;
        private Carrier carr;
        private Car car;

        public int Id { get => id; set => id = value; }
        public Carrier Carrier { get => carr; set => carr = value; }
        public Car Car { get => car; set => car = value; }

        public Carrier_Car() { }
        public Carrier_Car(Carrier c, Car car)
        {
            Carrier = c;
            Car = car;
        }

        public override string ToString()
        {
            return $"Перевозчик: {Carrier}, Авто: {Car}";
        }

        public static string GetName()
        {
            return "Carrier_Car";
        }
    }
}
