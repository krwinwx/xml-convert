using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class IMNS
    {
        private int imns_code;
        private string imns_name;

        /// <summary>
        /// Получает или задает код ИМНС.
        /// </summary>
        /// <returns>Код ИМНС в формате строки <see cref="string"/></returns>
        public int Imns_code { get => imns_code; set => imns_code = value; }

        /// <summary>
        /// Получает или задает наименование ИМНС.
        /// </summary>
        /// <returns>Наименование ИМНС в формате строки <see cref="string"/></returns>
        public string Imns_name { get => imns_name; set => imns_name = value; }

        public IMNS() { }
        public IMNS(int code, string name) 
        { 
            Imns_code = code;
            Imns_name = name;
        }

        public override string ToString()
        {
            return $"{Imns_code} {Imns_name}";
        }
    }
}
