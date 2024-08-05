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
    public partial class DispatcherForm : Form
    {
        readonly DB db = null;
        List<Dispatcher> allDisp = null;
        Dispatcher selected = null;
        public DispatcherForm(DB db)
        {
            InitializeComponent();
            
            this.db = db;
            allDisp = this.db.GetAllDispatchers();
            foreach (Dispatcher dispatcher in allDisp)
            {
                DispNameCB.Items.Add(dispatcher.Dispatcher_name);
            }

            DispNameCB.DropDownHeight = DispNameCB.ItemHeight * 10;
            OkButton.Click -= Update;
            OkButton.Click += AddDispButton_Click;
        }

        public DispatcherForm(DB db, Dispatcher selected)
        {
            InitializeComponent();

            this.db = db;
            this.selected = selected;
            DispUnpTB.Text = selected.Dispatcher_unp;
            DispNameCB.Text = selected.Dispatcher_name;
            DispUnpTB.Enabled = false;
            allDisp = this.db.GetAllDispatchers();
            foreach (Dispatcher dispatcher in allDisp)
                DispNameCB.Items.Add(dispatcher.Dispatcher_name);

            DispNameCB.DropDownHeight = DispNameCB.ItemHeight * 10;
            OkButton.Click += Update;
            OkButton.Click -= AddDispButton_Click;
        }

        private void Update(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(DispUnpTB.Text) != true && string.IsNullOrEmpty(DispNameCB.Text) != true)
            {
                try
                {
                    string unp = DispUnpTB.Text.ToString().Trim();
                    string name = DispNameCB.Text.ToString().Trim();
                    Dispatcher d = new Dispatcher(unp, name);
                    bool isExist = db.CheckExist(d);
                    if (isExist == true)
                    {
                        MessageBox.Show($"Диспетчер {d} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        bool res = db.Update(d);
                        if (res)
                        {
                            MessageBox.Show($"Данные изменены. Диспетчер {d} успешно добавлен в базу данных", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DispNameCB.Items.Add(d.Dispatcher_name);
                            DispNameCB.Items.Remove(selected.Dispatcher_name);
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

        private void AddDispButton_Click(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(DispUnpTB.Text) != true && string.IsNullOrEmpty(DispNameCB.Text) != true)
            {
                try
                {
                    string unp = DispUnpTB.Text.ToString().Trim();
                    string name = DispNameCB.Text.ToString().Trim();
                    Dispatcher d = new Dispatcher(unp, name);
                    bool isExist = db.CheckExist(d);
                    if (isExist == true)
                    {
                        MessageBox.Show($"Диспетчер {d} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        bool res = db.Insert(d);
                        if (res)
                        {
                            MessageBox.Show($"Диспетчер {d} был успешно добавлен в базу данных", "Новый Диспетчер добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DispNameCB.Items.Add(d);
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
                MessageBox.Show($"Чтобы добавить новую запись в таблицу Диспетчеры, необходимо заполнить следующие поля:{Environment.NewLine}- УНП диспетчера;{Environment.NewLine}- Наим. (наименование) диспетчера.", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DispNameCB_SelectedValueChanged(object sender, EventArgs e)
        {
            string disp = DispNameCB.SelectedItem.ToString().Trim();
            int unp = db.GetPrimaryKeyByValue("Dispatcher", "dispatcher_unp", "dispatcher_name", disp);
            if (unp != -1)
            {
                DispUnpTB.Text = unp.ToString();
            }
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
