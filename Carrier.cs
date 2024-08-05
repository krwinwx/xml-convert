using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public class Carrier
    {
        private string carrier_unp;
        private string carrier_name;
        private bool ur_ip = true;
        /// <summary>
        /// Получает или задает УНП перевозчика.
        /// </summary>
        /// <returns>УНП перевозчика в формате строки <see cref="string"/></returns>
        public string Carrier_unp
        {
            get => carrier_unp;
            set
            {
                if (value.Length != 9 || !value.All(char.IsDigit))
                    throw new ArgumentException("УНП диспетчера должно состоять из 9 цифр.", nameof(value));

                carrier_unp = value;
            }
        }

        /// <summary>
        /// Получает или задает наименование перевозчика.
        /// </summary>
        /// <returns>Наименование перевозчика в формате строки <see cref="string"/></returns>
        public string Carrier_name
        {
            get => carrier_name;
            set
            {
                carrier_name = value;
            }
        }

        /// <summary>
        /// Получает или задает свойство, отвечающее на принадлежность перевозчика к юр. лицам/ инд. предпринимателям (ИП).
        /// </summary>
        /// <returns>Вернет <see langword="true"/>, если перевозчик является юр. лицом, <see langword="false"/> - ИП</returns>
        public bool Ur_ip { get => ur_ip; set => ur_ip = value; }

        public Carrier() { }

        public Carrier(string unp, string name, bool isUr) 
        { 
            carrier_unp = unp;
            carrier_name = name;
            ur_ip = isUr;
        }

        public Carrier(string carrier_unp, string carrier_name)
        {
            this.carrier_unp = carrier_unp;
            this.carrier_name = carrier_name;
        }

        public override string ToString()
        {
            string urIp = Ur_ip == true ? "Юр. лицо" : "ИП";
            return $"{Carrier_unp} {Carrier_name} ({urIp})";
        }
    }
}
