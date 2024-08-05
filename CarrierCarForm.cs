using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CarrierCarForm : Form
    {
        private readonly DB db;
        private List<Carrier> carriers = new List<Carrier>();
        private List<Car> cars = new List<Car>();
        private List<Carrier_Car> allCarrierCar = new List<Carrier_Car>();
        Carrier_Car selected;
        public CarrierCarForm(DB db)
        {
            InitializeComponent();

            this.db = db;
            OkButton.Click += OkButton_Click;
            carriers = this.db.GetAllCarriers();
            cars = this.db.GetAllCars();
            allCarrierCar = this.db.GetAllCarrierCar();

            foreach(var c in carriers)
                CarrierCB.Items.Add(c.Carrier_name);
            CarrierCB.DropDownHeight = CarrierCB.ItemHeight * 10;
            
            foreach(var c in cars)
                CarBrandCB.Items.Add(c.Brand);
            CarBrandCB.DropDownHeight = CarBrandCB.ItemHeight * 10;
            OkButton.Click -= Update;
            OkButton.Click += OkButton_Click;
        }

        public CarrierCarForm(DB db, Carrier_Car x)
        {
            InitializeComponent();

            this.db = db;
            selected = x;
            OkButton.Click += Update;
            OkButton.Click -= OkButton_Click;
            carriers = this.db.GetAllCarriers();
            cars = this.db.GetAllCars();
            allCarrierCar = this.db.GetAllCarrierCar();

            foreach(var c in carriers)
                CarrierCB.Items.Add(c.Carrier_name);
            CarrierCB.DropDownHeight = CarrierCB.ItemHeight * 10;
            
            foreach(var c in cars)
                CarBrandCB.Items.Add(c.Brand);
            CarBrandCB.DropDownHeight = CarBrandCB.ItemHeight * 10;

            CarrierCB.SelectedItem = selected.Carrier.Carrier_name;
            CarrierCB.Text = selected.Carrier.Carrier_name;
            CarBrandCB.SelectedItem = selected.Car.Brand;
            CarBrandCB.Text = selected.Car.Brand;
            CarNumberCB.SelectedItem = selected.Car.Number_plate;
            CarNumberCB.Text = selected.Car.Number_plate;
        }

        private void Update(object sender, EventArgs e)
        {
            try
            {
                string carBrand = CarBrandCB.SelectedItem.ToString().Trim();
                string carNum = CarNumberCB.SelectedItem.ToString().Trim();

                Car car = cars.First(x => x.Brand == carBrand && x.Number_plate == carNum);
                Carrier carr = carriers.First(x => x.Carrier_name == CarrierCB.Text.Trim());

                if (carr != null && car != null)
                {
                    Carrier_Car newRelation = new Carrier_Car(carr, car);
                    Carrier_Car isExist = allCarrierCar.Find(x => x.Car.Number_plate == car.Number_plate && x.Carrier.Carrier_unp == carr.Carrier_unp);
                    if (isExist != null)
                    {
                        MessageBox.Show($"Отношение {newRelation} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        newRelation.Id = selected.Id;
                        bool res = db.Update(newRelation);
                        if (res)
                        {
                            MessageBox.Show($"Отношение {newRelation} было успешно изменено", $"Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            allCarrierCar.Add(newRelation);
                            allCarrierCar.Remove(selected);
                        }
                        else
                        {
                            MessageBox.Show($"Не удалось изменить отношение {newRelation}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(CarBrandCB.Text) != true && string.IsNullOrEmpty(CarrierCB.Text) != true && string.IsNullOrEmpty(CarNumberCB.Text) != true)
            {
                try
                {
                    string carBrand = CarBrandCB.SelectedItem.ToString().Trim();
                    string carNum = CarNumberCB.SelectedItem.ToString().Trim();

                    Car car = cars.First(x => x.Brand == carBrand && x.Number_plate == carNum);
                    Carrier carr = carriers.First(x => x.Carrier_name == CarrierCB.Text.Trim());

                    if (carr != null && car != null)
                    {
                        Carrier_Car newRelation = new Carrier_Car(carr, car);
                        Carrier_Car isExist = allCarrierCar.Find(x => x.Car.Number_plate == car.Number_plate && x.Carrier.Carrier_unp == carr.Carrier_unp);
                        if (isExist == null)
                        {
                            bool res = db.Insert(newRelation);
                            if (res)
                            {
                                MessageBox.Show($"Отношение {newRelation} было успешно добавлено в базу данных", $"Новое отношение \"{DB.GetRussianTableName(Carrier_Car.GetName())}\" добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                allCarrierCar.Add(newRelation);
                            }
                            else
                            {
                                MessageBox.Show($"Не удалось добавить новое отношение {newRelation} в базу данных", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Отношение {newRelation} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Чтобы добавить новое отношение \"{DB.GetRussianTableName(Carrier_Car.GetName())}\", необходимо заполнить следующие поля:{Environment.NewLine}- Наим. (наименование) перевозчика;{Environment.NewLine}- Модель авто;{Environment.NewLine}- Гос. рег. знак (номера) авто.", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CarBrandCB_SelectedValueChanged(object sender, EventArgs e)
        {
            string brand = CarBrandCB.SelectedItem.ToString().Trim();
            List<Car> carsByBrand = cars.FindAll(x => x.Brand == brand);
            if (carsByBrand.Count > 0)
            {
                foreach (Car car in carsByBrand) 
                {
                    CarNumberCB.Items.Add(car.Number_plate);
                }
            }
            else
            {
                MessageBox.Show($"Авто под маркой {brand} не найдены.", $"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
