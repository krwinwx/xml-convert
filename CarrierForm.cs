using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace WindowsFormsApp1
{
    public partial class CarrierForm : Form
    {
        private readonly DB db = null;
        List<Carrier> allCarriers = null;
        Carrier selected;
        public CarrierForm(DB db)
        {
            InitializeComponent();
            
            this.db = db;
            allCarriers = db.GetAllCarriers();
            foreach (var carr in allCarriers)
            {
                CarrierNameCB.Items.Add(carr.Carrier_name);
            }

            CarrierNameCB.DropDownHeight = CarrierNameCB.ItemHeight * 10;
            OkButton.Click -= Update;
            OkButton.Click += AddCarrButton_Click;
        }

        public CarrierForm(DB db, Carrier c)
        {
            InitializeComponent();

            this.db = db;
            selected = c;
            CarrierUnpTB.Text = selected.Carrier_unp;
            CarrierUnpTB.Enabled = false;
            CarrierNameCB.Text = selected.Carrier_name;
            UrIpCheckBox.Checked = selected.Ur_ip;
            OkButton.Click += Update;
            OkButton.Click -= AddCarrButton_Click;
            allCarriers = db.GetAllCarriers();
            foreach (var carr in allCarriers)
                CarrierNameCB.Items.Add(carr.Carrier_name);

            CarrierNameCB.DropDownHeight = CarrierNameCB.ItemHeight * 10;
        }

        private void Update(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(CarrierUnpTB.Text) != true && string.IsNullOrEmpty(CarrierNameCB.Text) != true)
            {
                try
                {
                    string unp = CarrierUnpTB.Text.ToString().Trim();
                    string name = CarrierNameCB.Text.ToString().Trim();
                    Carrier d = new Carrier(unp, name, UrIpCheckBox.Checked);
                    bool isExist = db.CheckExist(d);
                    if (isExist == true)
                    {
                        MessageBox.Show($"Перевозчик {d} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        bool res = db.Update(d);
                        if (res)
                        {
                            MessageBox.Show($"Данные изменены. Перевозчик {d} успешно добавлен в базу данных", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarrierNameCB.Items.Add(d.Carrier_name);
                            CarrierNameCB.Items.Remove(selected.Carrier_name);
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
                MessageBox.Show($"Чтобы обновить запись в таблице Диспетчеры, необходимо изменить значение поля \"Наим. диспетчера\".{Environment.NewLine}!!! ВНИМАНИЕ!!! Поменять УНП НЕЛЬЗЯ. Если Вы допустили ошибку при добавлении, то необходимо удалить неправильную запись и добавить новую! ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AddCarrButton_Click(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(CarrierUnpTB.Text) != true && string.IsNullOrEmpty(CarrierNameCB.Text) != true)
            {
                try
                {
                    string unp = CarrierUnpTB.Text.ToString().Trim();
                    string name = CarrierNameCB.Text.ToString().Trim();
                    bool isUr = UrIpCheckBox.Checked;
                    Carrier c = new Carrier(unp, name, isUr);
                    bool isExist = db.CheckExist(c);
                    if (isExist == true)
                    {
                        MessageBox.Show($"Перевозчик {c} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        bool res = db.Insert(c);
                        if (res)
                        {
                            MessageBox.Show($"Перевозчик {c} был успешно добавлен в базу данных", "Новый Перевозчик добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarrierNameCB.Items.Add(c.Carrier_name);
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
                MessageBox.Show($"Чтобы добавить новую запись в таблицу Перевозчик, необходимо заполнить следующие поля:{Environment.NewLine}- УНП перевозчика;{Environment.NewLine}- Наим. (наименование) перевозчика.", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CarrierNameCB_SelectedValueChanged(object sender, EventArgs e)
        {
            string carr = CarrierNameCB.SelectedItem.ToString().Trim();
            int unp = db.GetPrimaryKeyByValue("Carrier", "carrier_unp", "carrier_name", carr);
            if (unp != -1)
            {
                Carrier carrier = db.GetObjectByPrimaryKey("Carrier", "carrier_unp", unp) as Carrier;
                if (carrier != null)
                {
                    CarrierUnpTB.Text = carrier.Carrier_unp;
                    UrIpCheckBox.Checked = carrier.Ur_ip;
                }
            }
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
