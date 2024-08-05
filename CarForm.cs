using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace WindowsFormsApp1
{
    public partial class CarForm : Form
    {
        private readonly DB db = null;
        List<Car> allCars = new List<Car>();
        Car selected = null;
        public CarForm(DB db)
        {
            InitializeComponent();

            this.db = db;
            allCars = db.GetAllCars();
            foreach (Car car in allCars)
                NumberPlateCB.Items.Add(car.Number_plate);

            BrandCB.Items.AddRange(allCars.Select(car => car.Brand).Distinct().ToArray());
            BrandCB.DropDownHeight = BrandCB.ItemHeight * 10;
            OkButton.Click -= Update;
            OkButton.Click += AddCar_Click;

        }

        public CarForm(DB db, Car c)
        {
            InitializeComponent();

            this.db = db;
            selected = c;
            BrandCB.Text = c.Brand;
            NumberPlateCB.Text = c.Number_plate;
            OkButton.Click -= AddCar_Click;
            OkButton.Click += Update;
            allCars = db.GetAllCars();
            foreach (Car car in allCars)
                NumberPlateCB.Items.Add(car.Number_plate);

            BrandCB.Items.AddRange(allCars.Select(car => car.Brand).Distinct().ToArray());
            BrandCB.DropDownHeight = BrandCB.ItemHeight * 10;
        }

        private void Update(object sender, EventArgs e)
        {
            try
            {
                string brand = BrandCB.Text.ToString().Trim();
                string num = NumberPlateCB.Text.ToString().Trim();
                if (CheckNumberPlate(num))
                {
                    Car d = new Car(brand, num);
                    bool isExist = db.CheckExist(d);
                    if (isExist == true)
                    {
                        MessageBox.Show($"Авто {d} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        selected.Brand = brand;
                        selected.Number_plate = num;
                        bool res = db.Update(selected);
                        if (res)
                        {
                            MessageBox.Show($"Данные изменены. Авто {selected} успешно добавлено в базу данных", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат гос. рег. знака. Гос. регю знак должен иметь следующий вид: 0000АА1. Первые 4 цифры принадлежат диапозону от 0 до 9, две буквы являются заглавными буквами латинского алфавита, последняя цифра принадлежит диапозону от 0 до 7.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCar_Click(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(BrandCB.Text) != true && string.IsNullOrEmpty(NumberPlateCB.Text) != true)
            {
                try
                {
                    string brand = BrandCB.Text.ToString().Trim();
                    string number_plate = NumberPlateCB.Text.ToString().Trim();
                    if (CheckNumberPlate(number_plate))
                    {
                        Car c = new Car(brand, number_plate);
                        bool isExist = db.CheckExist(c);
                        if (isExist == true)
                        {
                            MessageBox.Show($"Авто {c} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            bool res = db.Insert(c);
                            if (res)
                            {
                                MessageBox.Show($"Авто {c} было успешно добавлен в базу данных", "Новое Авто добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BrandCB.Items.Add(c.Brand);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат гос. рег. знака. Гос. регю знак должен иметь следующий вид: 0000АА1. Первые 4 цифры принадлежат диапозону от 0 до 9, две буквы являются заглавными буквами латинского алфавита, последняя цифра принадлежит диапозону от 0 до 7.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Чтобы добавить новую запись в таблицу Авто, необходимо заполнить следующие поля:{Environment.NewLine}- Модель авто;{Environment.NewLine}- Гос. рег. знак (государственный регистрационный знак авто = \"номера\"", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BrandCB_SelectedValueChanged(object sender, EventArgs e)
        {
            string text = NumberPlateCB.Text;
            NumberPlateCB.Items.Clear();
            string brand = BrandCB.SelectedItem.ToString().Trim();
            List<Car> carsByBrand = allCars.FindAll(car => car.Brand == brand);
            if (carsByBrand != null && carsByBrand.Count > 0)
            {
                NumberPlateCB.Items.AddRange(carsByBrand.Select(car => car.Number_plate).ToArray());
            }

            NumberPlateCB.DropDownHeight = NumberPlateCB.ItemHeight * 10;
            NumberPlateCB.Text = text;
        }

        private bool CheckNumberPlate(string number)
        {
            if (Regex.IsMatch(number, @"^\d{4}[A-Z]{2}[1-7]$"))
            {
                return true;
            }
            else return false;
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
