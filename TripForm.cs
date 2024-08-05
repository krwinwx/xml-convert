using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace WindowsFormsApp1
{
    public partial class TripForm : Form
    {
        private readonly DB db = null;
        private List<IMNS> allImns = new List<IMNS>();
        private List<Dispatcher> allDisp = new List<Dispatcher>();
        private List<Carrier> allCarrier = new List<Carrier>();
        private List<Car> allCars = new List<Car>();
        private List<Trips> allTrips = new List<Trips>();

        private List<IMNS_Dispatcher> imnsDisp = new List<IMNS_Dispatcher>();
        private List<Dispatcher_Carrier> dispCarrier = new List<Dispatcher_Carrier>();
        private List<Carrier_Car> carrierCar = new List<Carrier_Car>();
        Trips selected;
        public TripForm(DB database)
        {
            InitializeComponent();

            db = database;
            allImns = db.GetAllIMNS();
            imnsDisp = db.GetAllIMNSDispatcher();
            dispCarrier = db.GetAllDispatcherCarrier();
            carrierCar = db.GetAllCarrierCar();

            DateShift.Text = DateTime.Today.ToString();
            foreach (IMNS im in allImns) 
                ImnsCB.Items.Add(im.Imns_name);

            allDisp = db.GetAllDispatchers();
            foreach (Dispatcher disp in allDisp)
                DispCB.Items.Add(disp.Dispatcher_name);

            DispCB.DropDownHeight = DispCB.ItemHeight * 10;

            allCarrier = db.GetAllCarriers();
            foreach (Carrier carrier in allCarrier)
                CarrierCB.Items.Add(carrier.Carrier_name);

            CarrierCB.DropDownHeight = DispCB.ItemHeight * 10;

            allCars = db.GetAllCars();
            CarBrandCB.Items.AddRange(allCars.Select(car => car.Brand).Distinct().ToArray());
            foreach (Car car in allCars)
            {
                CarNumberCB.Items.Add(car.Number_plate);
            }

            allTrips = db.GetAllTrips();
            if (allTrips != null)
            {
                var uniqueEsNames = allTrips.Select(t => t.Es_name).Distinct().ToList();
                foreach (var esName in uniqueEsNames)
                    EsNameCB.Items.Add(esName);
            }
            OkButton.Click += Insert;
            OkButton.Click -= Update;
            DateShift.ValueChanged += DateShift_ValueChanged;
        }

        public TripForm(DB database, Trips x)
        {
            InitializeComponent();

            db = database;
            selected = x;
            allImns = db.GetAllIMNS();
            imnsDisp = db.GetAllIMNSDispatcher();
            dispCarrier = db.GetAllDispatcherCarrier();
            carrierCar = db.GetAllCarrierCar();
            DateShift.Text = x.Date_shift;
            foreach (IMNS im in allImns) 
                ImnsCB.Items.Add(im.Imns_name);
            ImnsCB.Text = x.IMNS.Imns_name;
            ImnsCB.SelectedItem = x.IMNS.Imns_name;
            allDisp = db.GetAllDispatchers();
            foreach (Dispatcher disp in allDisp)
                DispCB.Items.Add(disp.Dispatcher_name);
            DispCB.DropDownHeight = DispCB.ItemHeight * 10;
            DispCB.SelectedItem = x.Dispatcher.Dispatcher_name;
            DispCB.Text = x.Dispatcher.Dispatcher_name;
            allCarrier = db.GetAllCarriers();
            foreach (Carrier carrier in allCarrier)
                CarrierCB.Items.Add(carrier.Carrier_name);
            CarrierCB.DropDownHeight = DispCB.ItemHeight * 10;
            CarrierCB.SelectedItem = x.Carrier.Carrier_name; 
            CarrierCB.Text = x.Carrier.Carrier_name;
            allCars = db.GetAllCars();
            CarBrandCB.Items.AddRange(allCars.Select(car => car.Brand).Distinct().ToArray());
            foreach (Car car in allCars)
                CarNumberCB.Items.Add(car.Number_plate);
            CarBrandCB.SelectedItem = x.Car.Brand;
            CarBrandCB.Text = x.Car.Brand;
            CarNumberCB.SelectedItem = x.Car.Number_plate;
            CarNumberCB.Text = x.Car.Number_plate;
            allTrips = db.GetAllTrips();
            if (allTrips != null)
            {
                var uniqueEsNames = allTrips.Select(t => t.Es_name).Distinct().ToList();
                foreach (var esName in uniqueEsNames)
                    EsNameCB.Items.Add(esName);
            }
            OrderTotalAmount.Value = x.Order_total;
            EsOrderCount.Value = x.Es_order_count;
            EsNameCB.Text = x.Es_name;
            OkButton.Click -= Insert;
            OkButton.Click += Update;
            DateShift.ValueChanged -= DateShift_ValueChanged;
        }

        private void Update(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(DispCB.Text) != true && string.IsNullOrEmpty(CarrierCB.Text) != true && string.IsNullOrEmpty(CarBrandCB.Text) != true && string.IsNullOrEmpty(CarNumberCB.Text) != true)
            {
                try
                {
                    string imnsName = ImnsCB.Text.Trim();
                    string dispName = DispCB.Text.Trim();
                    string carrierName = CarrierCB.Text.Trim();
                    string carBrand = CarBrandCB.Text.Trim();
                    string carNum = CarNumberCB.Text.Trim();

                    IMNS imns = allImns.First(x => x.Imns_name == imnsName);
                    Dispatcher disp = allDisp.First(x => x.Dispatcher_name == dispName);
                    Carrier carr = allCarrier.First(x => x.Carrier_name == carrierName);
                    Car car = allCars.First(x => x.Brand == carBrand && x.Number_plate == carNum);
                    if (carr != null && disp != null && imns != null && car != null)
                    {
                        Trips newRelation = new Trips()
                        {
                            IMNS = imns,
                            Dispatcher = disp,
                            Carrier = carr,
                            Car = car,
                            Date_shift = DateShift.Text,
                            Order_total = Convert.ToInt32(OrderTotalAmount.Value),
                            Es_order_count = Convert.ToInt32(EsOrderCount.Value),
                            Es_name = EsNameCB.SelectedItem == null ? "" : EsNameCB.SelectedItem.ToString().Trim(),
                        };
                        Trips isExist = allTrips.Find(x => x.Equals(newRelation));
                        if (isExist == null)
                        {
                            bool res = db.Update(newRelation);
                            if (res)
                            {
                                MessageBox.Show($"Отношение {newRelation} было успешно изменено", $"Изменение \"{DB.GetRussianTableName(Dispatcher_Carrier.GetName())}\" добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                allTrips.Add(newRelation);
                            }
                            else
                            {
                                MessageBox.Show($"Не удалось изменить поездку {newRelation}", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Поездка {newRelation} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show($"Чтобы изменить запись в таблице \"Поездки\", необходимо заполнить следующие поля:{Environment.NewLine}- Диспетчер;{Environment.NewLine}- Перевозчик.", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CarBrand_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Car> carsByBrand = allCars.FindAll(c => c.Brand == CarBrandCB.SelectedItem.ToString());
            if (carsByBrand != null)
            {
                CarNumberCB.Items.Clear();
                foreach (Car car in carsByBrand)
                {
                    CarNumberCB.Items.Add(car.Number_plate);
                }
            }
        }

        private void Insert(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(DispCB.Text) != true && string.IsNullOrEmpty(CarrierCB.Text) != true && string.IsNullOrEmpty(CarBrandCB.Text) != true && string.IsNullOrEmpty(CarNumberCB.Text) != true)
            {
                try
                {
                    string imnsName = ImnsCB.SelectedItem.ToString().Trim();
                    string dispName = DispCB.SelectedItem.ToString().Trim();
                    string carrierName = CarrierCB.SelectedItem.ToString().Trim();
                    string carBrand = CarBrandCB.SelectedItem.ToString().Trim();
                    string carNum = CarNumberCB.SelectedItem.ToString().Trim();

                    IMNS imns = allImns.First(x => x.Imns_name == imnsName);
                    Dispatcher disp = allDisp.First(x => x.Dispatcher_name == dispName);
                    Carrier carr = allCarrier.First(x => x.Carrier_name == carrierName);
                    Car car = allCars.First(x => x.Brand == carBrand && x.Number_plate == carNum);
                    if (carr != null && disp != null && imns != null && car != null)
                    {
                        Trips newRelation = new Trips()
                        {
                            IMNS = imns,
                            Dispatcher = disp,
                            Carrier = carr,
                            Car = car,
                            Date_shift = DateShift.Text,
                            Order_total = Convert.ToInt32(OrderTotalAmount.Value),
                            Es_order_count = Convert.ToInt32(EsOrderCount.Value),
                            Es_name = EsNameCB.SelectedItem == null ? "" : EsNameCB.SelectedItem.ToString().Trim(),
                        };
                        Trips isExist = allTrips.Find(x => x.Equals(newRelation));
                        if (isExist == null)
                        {
                            bool res = db.Insert(newRelation);
                            if (res)
                            {
                                MessageBox.Show($"Отношение {newRelation} было успешно добавлено в базу данных", $"Новое отношение \"{DB.GetRussianTableName(Dispatcher_Carrier.GetName())}\" добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                allTrips.Add(newRelation);
                            }
                            else
                            {
                                MessageBox.Show($"Не удалось добавить поездку {newRelation} в базу данных", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Поездка {newRelation} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show($"Чтобы добавить новую запись в таблицу \"Поездки\", необходимо заполнить следующие поля:{Environment.NewLine}- Наим. (наименование) Диспетчера;{Environment.NewLine}- Наим. (наименование) перевозчика.", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DispCB_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Dispatcher_Carrier> carrierByDisp = dispCarrier.FindAll(x => x.Dispatcher.Dispatcher_name == DispCB.SelectedItem.ToString());
            if (carrierByDisp != null)
            {
                CarrierCB.Items.Clear();
                foreach (Dispatcher_Carrier y in carrierByDisp)
                {
                    CarrierCB.Items.Add(y.Carrier.Carrier_name);
                }
            }
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }

        private void EsOrderCount_ValueChanged(object sender, EventArgs e)
        {
            if (EsOrderCount.Value > OrderTotalAmount.Value)
            {
                MessageBox.Show("Обратите внимание! Количество заказов с использованием ЭИС не может превышать общее количество заказов, выполненных за смену", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                EsOrderCount.Value--;
                return;
            }
        }

        private void DateShift_ValueChanged(object sender, EventArgs e)
        {
            if(DateShift.Value < DateTime.Today)
            {
                MessageBox.Show("Обратите внимание! Нельзя добавить поездку за дату, которая идет раньше сегодняшней", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DateShift.Value = DateTime.Today;
                return;
            }
        }

        private void ImnsCB_SelectedValueChanged(object sender, EventArgs e)
        {
            List<IMNS_Dispatcher> dispByImns = imnsDisp.FindAll(x => x.Imns.Imns_name == ImnsCB.SelectedItem.ToString());
            if (dispByImns != null)
            {
                DispCB.Items.Clear();
                foreach (IMNS_Dispatcher y in dispByImns)
                {
                    DispCB.Items.Add(y.Dispatcher.Dispatcher_name);
                }
            }
        }

        private void CarrierCB_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Carrier_Car> carByCarrier = carrierCar.FindAll(x => x.Carrier.Carrier_name == CarrierCB.SelectedItem.ToString());
            if (carByCarrier != null)
            {
                CarBrandCB.Items.Clear();
                CarNumberCB.Items.Clear();
                foreach (Carrier_Car y in carByCarrier)
                {
                    if (CarBrandCB.Items.Contains(y.Car.Brand) == false)
                    {
                        CarBrandCB.Items.Add(y.Car.Brand);
                    }
                    CarNumberCB.Items.Add(y.Car.Number_plate);
                }
            }
        }
    }
}
