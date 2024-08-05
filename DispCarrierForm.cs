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
    public partial class DispCarrierForm : Form
    {
        private readonly DB db;
        private List<Dispatcher> allDisp;
        private List<Carrier> allCarr;
        private List<Dispatcher_Carrier> allDispCarr;
        Dispatcher_Carrier selected;
        public DispCarrierForm(DB db)
        {
            InitializeComponent();
            
            this.db = db;
            allDisp = this.db.GetAllDispatchers();
            allCarr = this.db.GetAllCarriers();
            allDispCarr = this.db.GetAllDispatcherCarrier();
            OkButton.Click += Insert;
            OkButton.Click -= Update;
            foreach (Dispatcher d in allDisp)
                DispCB.Items.Add(d.Dispatcher_name);
            DispCB.DropDownHeight = DispCB.ItemHeight * 10;
            
            foreach(Carrier c in allCarr)
                CarrierCB.Items.Add(c.Carrier_name);
            CarrierCB.DropDownHeight = CarrierCB.ItemHeight * 10;
        }

        public DispCarrierForm(DB db, Dispatcher_Carrier x)
        {
            InitializeComponent();
            
            this.db = db;
            selected = x;
            OkButton.Click += Update;
            OkButton.Click -= Insert;
            allDisp = this.db.GetAllDispatchers();
            allCarr = this.db.GetAllCarriers();
            allDispCarr = this.db.GetAllDispatcherCarrier();
            
            foreach(Dispatcher d in allDisp)
                DispCB.Items.Add(d.Dispatcher_name);
            DispCB.DropDownHeight = DispCB.ItemHeight * 10;
            
            foreach(Carrier c in allCarr)
                CarrierCB.Items.Add(c.Carrier_name);
            CarrierCB.DropDownHeight = CarrierCB.ItemHeight * 10;

            DispCB.SelectedItem = selected.Dispatcher.Dispatcher_name;
            DispCB.Text = selected.Dispatcher.ToString();
            CarrierCB.SelectedItem = selected.Carrier.Carrier_name;
            CarrierCB.Text = selected.Carrier.ToString();
        }

        private void Update(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(DispCB.Text) != true && string.IsNullOrEmpty(CarrierCB.Text) != true)
            {
                try
                {
                    Dispatcher disp = db.GetObjectByPrimaryKey("Dispatcher", "dispatcher_unp", db.GetPrimaryKeyByValue("Dispatcher", "dispatcher_unp", "dispatcher_name", DispCB.Text.Trim())) as Dispatcher;
                    Carrier carr = db.GetObjectByPrimaryKey("Carrier", "carrier_unp", db.GetPrimaryKeyByValue("Carrier", "carrier_unp", "carrier_name", CarrierCB.Text.Trim())) as Carrier;
                    Dispatcher_Carrier d = new Dispatcher_Carrier(disp, carr);
                    Dispatcher_Carrier isExist = allDispCarr.Find(x => x.Dispatcher.Dispatcher_unp == disp.Dispatcher_unp && x.Carrier.Carrier_unp == carr.Carrier_unp);
                    if (isExist != null)
                    {
                        MessageBox.Show($"Отношение {d} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        d.Id = selected.Id;
                        bool res = db.Update(d);
                        if (res)
                        {
                            MessageBox.Show($"Данные изменены. Отношение {d} успешно добавлен в базу данных", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            allDispCarr.Add(d);
                            allDispCarr.Remove(selected);
                        }
                        else
                        {
                            MessageBox.Show("Что-то пошло не так...", "Упс..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Чтобы обновить запись в таблице Диспетчеры и Перевозчики, необходимо изменить значение полей \"Диспетчер\" и/или \"Перевозчик\".{Environment.NewLine}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Insert(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(DispCB.Text) != true && string.IsNullOrEmpty(CarrierCB.Text) != true)
            {
                try
                {
                    string dispName = DispCB.SelectedItem.ToString().Trim();
                    string carrierName = CarrierCB.SelectedItem.ToString().Trim();

                    Dispatcher disp = allDisp.First(x => x.Dispatcher_name == dispName);
                    Carrier carr = allCarr.First(x => x.Carrier_name == carrierName);

                    if (carr != null && disp != null)
                    {
                        Dispatcher_Carrier newRelation = new Dispatcher_Carrier(disp, carr);
                        Dispatcher_Carrier isExist = allDispCarr.Find(x => x.Dispatcher.Dispatcher_unp == disp.Dispatcher_unp && x.Carrier.Carrier_unp == carr.Carrier_unp);
                        if (isExist == null)
                        {
                            bool res = db.Insert(newRelation);
                            if (res)
                            {
                                MessageBox.Show($"Отношение {newRelation} было успешно добавлено в базу данных", $"Новое отношение \"{DB.GetRussianTableName(Dispatcher_Carrier.GetName())}\" добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                allDispCarr.Add(newRelation);
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
                MessageBox.Show($"Чтобы добавить новое отношение \"{DB.GetRussianTableName(Dispatcher_Carrier.GetName())}\", необходимо заполнить следующие поля:{Environment.NewLine}- Наим. (наименование) Диспетчера;{Environment.NewLine}- Наим. (наименование) перевозчика.", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
