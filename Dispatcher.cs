using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Dispatcher
    {
        private string dispatcher_name;
        private string dispatcher_unp;
        
        /// <summary>
        /// Получает или задает наименование диспетчера.
        /// </summary>
        /// <returns>Наименование диспетчера в формате строки <see cref="string"/></returns>
        public string Dispatcher_name
        {
            get => dispatcher_name;
            set => dispatcher_name = value;
        }

        /// <summary>
        /// Получает или задает УНП диспетчера.
        /// </summary>
        /// <returns>УНП диспетчера в формате строки <see cref="string"/></returns>
        public string Dispatcher_unp
        {
            get => dispatcher_unp;
            set
            {
                dispatcher_unp = value;
            }
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Dispatcher"/> с параметрами.
        /// </summary>
        /// <param name="dispatch_name">Имя диспетчера</param>
        /// <param name="dispatch_unp">УНП диспетчера</param>
        public Dispatcher() { }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Dispatcher"/> с параметрами.
        /// </summary>
        /// <param name="dispatch_name">Имя диспетчера</param>
        /// <param name="dispatch_unp">УНП диспетчера</param>
        public Dispatcher(string dispatch_unp, string dispatch_name)
        {
            Dispatcher_unp = dispatch_unp;
            Dispatcher_name = dispatch_name;
        }

        public override string ToString()
        {
            return $"{Dispatcher_unp} {Dispatcher_name}";
        }
    }
}
