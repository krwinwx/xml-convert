using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Dispatcher_Carrier
    {
        private int id;
        private Dispatcher disp;
        private Carrier carr;

        public int Id { get => id; set => id = value; }
        public Dispatcher Dispatcher { get => disp; set => disp = value; }
        public Carrier Carrier { get => carr; set => carr = value; }

        public Dispatcher_Carrier() { }
        public Dispatcher_Carrier(Dispatcher d, Carrier c)
        {
            Dispatcher = d;
            Carrier = c;
        }

        public override string ToString()
        {
            return $"Диспетчер: {Dispatcher}, Перевозчик: {Carrier}";
        }

        public static string GetName()
        {
            return "Dispatcher_Carrier";
        }
    }
}
