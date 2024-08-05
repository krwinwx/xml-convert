using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Car
    {
        private int id;
        private string brand;
        private string number_plate;

        /// <summary>
        /// Получает или задает id автомобиля.
        /// </summary>
        /// <returns>id автомобиля</returns>
        public int Id { get => id; set => id = value; }
        
        /// <summary>
        /// Получает или задает марку (модель) автомобиля.
        /// </summary>
        /// <returns>Марка (модель) автомобиля в формате строки <see cref="string"/></returns>
        public string Brand { get => brand; set => brand = value; }

        /// <summary>
        /// Получает или задает государственный регистрационный знак (номер) автомобиля.
        /// </summary>
        /// <returns>Государственный регистрационный знак (номер) автомобиля в формате строки <see cref="string"/></returns>
        public string Number_plate { get => number_plate; set => number_plate = value; }

        public Car() { }
        public Car(string brand, string numberPlate)
        {
            Brand = brand;
            Number_plate = numberPlate;
        }

        public override string ToString()
        {
            return $"{brand} {number_plate}";
        }
    }
}
