using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static OfficeOpenXml.ExcelErrorValue;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс, предоставляющий работу с XML-документами TaxiCompanyReportXML от ИМНС.
    /// </summary>
    public class Trips
    {
        private int id;
        private Dispatcher dispatcher;
        private Carrier carrier;
        private IMNS imns;
        private Car car;

        public Trips() { }
        public Trips(IMNS i, Dispatcher d, Carrier c, Car car)
        {
            IMNS = i;
            Dispatcher = d;
            Carrier = c;
            Car = car;
        }

        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Получает или задает экземпляр класса <see cref="WindowsFormsApp1.Dispatcher"/>.
        /// </summary>
        /// <returns>Экземплр класса <see cref="WindowsFormsApp1.Dispatcher"/></returns>
        public Dispatcher Dispatcher { get => dispatcher; set => dispatcher = value; }

        /// <summary>
        /// Получает или задает экземпляр класса <see cref="WindowsFormsApp1.Carrier"/>.
        /// </summary>
        /// <returns>Экземплр класса <see cref="WindowsFormsApp1.Carrier"/></returns>
        public Carrier Carrier { get => carrier; set => carrier = value; }

        /// <summary>
        /// Получает или задает экземпляр класса <see cref="WindowsFormsApp1.IMNS"/>.
        /// </summary>
        /// <returns>Экземплр класса <see cref="WindowsFormsApp1.IMNS"/></returns>
        public IMNS IMNS { get => imns; set => imns = value; }

        /// <summary>
        /// Получает или задает экземпляр класса <see cref="WindowsFormsApp1.Car"/>.
        /// </summary>
        /// <returns>Экземплр класса <see cref="WindowsFormsApp1.Car"/></returns>
        public Car Car { get => car; set => car = value; }

        /// <summary>
        /// Получает или задает дату начала смены перевозчика.
        /// </summary>
        /// <returns>Дата начала смены перевозчика в формате строки <see cref="string"/></returns>
        public string Date_shift { get; set; } = "";

        /// <summary>
        /// Получает или задает количество заказов, выполненных перевозчиком за смену.
        /// </summary>
        /// <returns>Количество заказов перевозчика за смену в формате целового числа <see cref="int"/></returns>
        public int Order_total { get; set; }

        /// <summary>
        /// Получает или задает количество заказов, выполненных перевозчиком за смену с использованием электронной информационной системы (ЭИС).
        /// </summary>
        /// <returns>Количество заказов, выполненных перевозчиком за смену с использованием ЭИС в формате строки <see cref="int"/></returns>
        public int Es_order_count { get; set; }

        /// <summary>
        /// Получает или задает наименование электронной информационной системы (ЭИС).
        /// </summary>
        /// <returns>Наименование ЭИС в формате строки <see cref="string"/></returns>
        public string Es_name { get; set; } = "";


        /// <summary>
        /// Получает и формирует список экземпляров класса <see cref="Trips"/> из XML-документа по пути path.
        /// </summary>
        /// <param name="path">Путь к XML-документу</param>
        /// <returns>Список <see cref="List{T}"/> экземпляров класса <see cref="Trips"/></returns>
        public static List<Trips> LoadFromFile(string path)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);

                int kodIMNS = Convert.ToInt32(GetAttributeValue(xmlDoc, "kodIMNS"));
                string imnsName = GetNodeValue(xmlDoc, "TaxiCompanyReport_v1_f002");
                string dispatch_unp = GetAttributeValue(xmlDoc, "UNP");
                string dispatch_name = GetNodeValue(xmlDoc, "TaxiCompanyReport_v1_f003");

                Trips report = new Trips();

                List<Trips> result = new List<Trips>();
                foreach (XmlNode node in xmlDoc.SelectNodes("//TaxiCompanyReport_v1_row"))
                {
                    IMNS imns = new IMNS(kodIMNS, RemoveDoubleQuotes(imnsName));
                    report.IMNS = imns;
                    //report.IMNS.Imns_code = kodIMNS;
                    //report.IMNS.Imns_name = RemoveDoubleQuotes(imnsName);

                    Dispatcher disp = new Dispatcher(dispatch_unp, RemoveDoubleQuotes(dispatch_name));
                    report.Dispatcher = disp;
                    //report.Dispatcher.Dispatcher_unp = dispatch_unp;
                    //report.Dispatcher.Dispatcher_name = RemoveDoubleQuotes(dispatch_name);
                    
                    string carrier_unp = node.SelectSingleNode("TaxiCompanyReport_v1_row_f01")?.InnerText;
                    string carrier_name = RemoveDoubleQuotes(node.SelectSingleNode("TaxiCompanyReport_v1_row_f02")?.InnerText);
                    Carrier carr = new Carrier(carrier_unp, carrier_name);
                    //report.Carrier.Carrier_unp = node.SelectSingleNode("TaxiCompanyReport_v1_row_f01")?.InnerText;
                    //report.Carrier.Carrier_name = RemoveDoubleQuotes(node.SelectSingleNode("TaxiCompanyReport_v1_row_f02")?.InnerText);
                    if (string.IsNullOrEmpty(carrier_name))
                    {
                        carr.Carrier_name = node.SelectSingleNode("TaxiCompanyReport_v1_row_f03")?.InnerText;
                        carr.Ur_ip = false;
                    }
                    report.Carrier = carr;

                    string number_plate = node.SelectSingleNode("TaxiCompanyReport_v1_row_f04")?.InnerText;
                    string brand = node.SelectSingleNode("TaxiCompanyReport_v1_row_f05")?.InnerText;
                    Car car = new Car(brand, number_plate);
                    report.Car = car;
                    //report.Car.Number_plate = node.SelectSingleNode("TaxiCompanyReport_v1_row_f04")?.InnerText;
                    //report.Car.Brand = node.SelectSingleNode("TaxiCompanyReport_v1_row_f05")?.InnerText;
                    
                    report.Date_shift = RemoveTimeZone(node.SelectSingleNode("TaxiCompanyReport_v1_row_f07")?.InnerText);
                    report.Order_total = Convert.ToInt32(node.SelectSingleNode("TaxiCompanyReport_v1_row_f08")?.InnerText);
                    report.Es_order_count = Convert.ToInt32(node.SelectSingleNode("TaxiCompanyReport_v1_row_f09")?.InnerText);
                    report.Es_name = node.SelectSingleNode("TaxiCompanyReport_v1_row_f10")?.InnerText;

                    result.Add(report);
                    report = new Trips();
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Файл не соответствует XSD-схеме: {ex.Message}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Получает значение узла по его имени.
        /// </summary>
        /// <param name="xmlDoc">Объект класса <see cref="XmlDocument"/></param>
        /// <param name="nodeName">Название узла</param>
        /// <returns>Значение узла в формате строки <see cref="string"/>.</returns>
        public static string GetNodeValue(XmlDocument xmlDoc, string nodeName)
        {
            string nodeValue = null;

            XmlNode node = xmlDoc.SelectSingleNode("//" + nodeName);
            if (node != null)
            {
                nodeValue = node.InnerText;
            }

            return nodeValue;
        }

        /// <summary>
        /// Получает значение атрибута по его имени.
        /// </summary>
        /// <param name="xmlDoc">Объект класса <see cref="XmlDocument"/></param>
        /// <param name="nodeName">Название атрибута</param>
        /// <returns>Значение атрибута в формате строки <see cref="string"/>.</returns>
        public static string GetAttributeValue(XmlDocument xmlDoc, string attributeName)
        {
            string attributeValue = null;

            XmlNode root = xmlDoc.DocumentElement;
            if (root.Attributes != null)
            {
                foreach (XmlAttribute attribute in root.Attributes)
                {
                    if (attribute.Name == attributeName)
                    {
                        attributeValue = attribute.Value;
                        break;
                    }
                }
            }

            return attributeValue;
        }

        /// <summary>
        /// Удаляет двойные кавычки в строке.
        /// </summary>
        /// <param name="input">Входная строка <see cref="string"/></param>
        /// <returns>Строка без двойных кавычек</returns>
        public static string RemoveDoubleQuotes(string input)
        {
            if (input != null)
            {
                return input.Replace("\"", "");
            }

            return "";
        }

        /// <summary>
        /// Форматирует дату, убирая часовой пояс, и приводит к формату дд-мм-гггг.
        /// </summary>
        /// <param name="date">Входная строка <see cref="string"/> с датой</param>
        /// <returns>Дата в формате дд-мм-гггг</returns>

        public static string RemoveTimeZone(string date)
        {
            if (date != null || date != "")
            {
                Regex regex = new Regex(@"\+\d{2}:\d{2}$");
                string dateWithoutTimeZone = regex.Replace(date, "");
                string[] parts = dateWithoutTimeZone.Split('-');
                string formattedDate = $"{parts[2]}-{parts[1]}-{parts[0]}";

                return formattedDate;
            }

            return "";
        }

        public override bool Equals(object obj)
        {
            Trips trip = obj as Trips;
            if (trip != null)
            {
                if (this.Date_shift == trip.Date_shift && this.Dispatcher == trip.Dispatcher && this.IMNS == trip.IMNS && this.Carrier == trip.Carrier && this.Car == trip.Car)
                {
                    if (this.Order_total == trip.Order_total && this.Es_order_count == trip.Es_order_count && this.Es_name == trip.Es_name)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        public override string ToString()
        {
            return $"{Date_shift} {IMNS.Imns_name} {Dispatcher.Dispatcher_name} {Carrier.Carrier_name} {Car}";
        }
    }
}
