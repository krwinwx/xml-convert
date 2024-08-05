using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class IMNS_Dispatcher
    {
        private int id;
        private IMNS imns;
        private Dispatcher dispatcher;

        public int Id { get => id; set => id = value; }
        public IMNS Imns { get => imns; set => imns = value; }
        public Dispatcher Dispatcher { get => dispatcher; set => dispatcher = value; }

        public IMNS_Dispatcher() { }
        public IMNS_Dispatcher(IMNS imns, Dispatcher disp)
        {
            this.imns = imns;   
            this.dispatcher = disp;
        }

        public override string ToString()
        {
            return $"ИМНС: {Imns}, Диспетчер: {Dispatcher}";
        }
    }
}
