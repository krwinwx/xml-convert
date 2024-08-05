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

namespace WindowsFormsApp1
{
    public partial class ImnsDispForm : Form
    {
        DB db = null;
        List<IMNS> allImns = null;
        List<Dispatcher> allDisp = null;
        List<IMNS_Dispatcher> allImnsDisp = null;
        IMNS_Dispatcher selected;
        public ImnsDispForm(DB db)
        {
            InitializeComponent();

            this.db = db;
            allImnsDisp = this.db.GetAllIMNSDispatcher();
            allImns = this.db.GetAllIMNS();
            allDisp = this.db.GetAllDispatchers();
            foreach (IMNS i in allImns)
                ImnsCB.Items.Add(i.Imns_name);

            ImnsCB.DropDownHeight = ImnsCB.ItemHeight * 10;
            foreach (Dispatcher d in allDisp)
                DispCB.Items.Add(d.Dispatcher_name);

            DispCB.DropDownHeight = DispCB.ItemHeight * 10;
            OkButton.Click -= Update;
            OkButton.Click += Insert;
        }

        public ImnsDispForm(DB db, IMNS_Dispatcher x)
        {
            InitializeComponent();

            this.db = db;
            selected = x;
            OkButton.Click -= Insert;
            OkButton.Click += Update;

            allImnsDisp = this.db.GetAllIMNSDispatcher();
            allImns = this.db.GetAllIMNS();
            allDisp = this.db.GetAllDispatchers();
            foreach (IMNS i in allImns)
                ImnsCB.Items.Add(i.Imns_name);

            ImnsCB.DropDownHeight = ImnsCB.ItemHeight * 10;
            foreach (Dispatcher d in allDisp)
                DispCB.Items.Add(d.Dispatcher_name);

            DispCB.DropDownHeight = DispCB.ItemHeight * 10;
            ImnsCB.SelectedItem = selected.Imns.Imns_name;
            ImnsCB.Text = selected.Imns.Imns_name;
            DispCB.SelectedItem = selected.Dispatcher.Dispatcher_name;
            DispCB.Text = selected.Dispatcher.Dispatcher_name;

        }

        private void Update(object sender, EventArgs e)
        {
            try
            {
                IMNS imns = db.GetObjectByPrimaryKey("IMNS", "imns_code", db.GetPrimaryKeyByValue("IMNS", "imns_code", "imns_name", ImnsCB.Text.Trim())) as IMNS;
                Dispatcher disp = db.GetObjectByPrimaryKey("Dispatcher", "dispatcher_unp", db.GetPrimaryKeyByValue("Dispatcher", "dispatcher_unp", "dispatcher_name", DispCB.Text.Trim())) as Dispatcher;
                if (imns != null && disp != null)
                {
                    IMNS_Dispatcher d = new IMNS_Dispatcher(imns, disp);
                    IMNS_Dispatcher isExist = allImnsDisp.Find(x => x.Imns.Imns_code == imns.Imns_code && x.Dispatcher.Dispatcher_unp == disp.Dispatcher_unp);
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
                            allImnsDisp.Add(d);
                            allImnsDisp.Remove(selected);
                        }
                        else
                        {
                            MessageBox.Show("Что-то пошло не так...");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Что-то пошло не так... {imns}, {disp}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insert(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(ImnsCB.Text) != true && string.IsNullOrEmpty(DispCB.Text) != true)
            {
                try
                {
                    string selectedImnsName = ImnsCB.SelectedItem.ToString().Trim();
                    string selectedDispName = DispCB.SelectedItem.ToString().Trim();
                    IMNS imns = allImns.First(x => x.Imns_name == selectedImnsName);
                    Dispatcher disp = allDisp.First(x => x.Dispatcher_name == selectedDispName);
                    if (imns != null && disp != null)
                    {
                        IMNS_Dispatcher newRelation = new IMNS_Dispatcher(imns, disp);
                        IMNS_Dispatcher isExist = allImnsDisp.Find(x => x.Imns.Imns_code == imns.Imns_code && x.Dispatcher.Dispatcher_unp == disp.Dispatcher_unp);
                        if (isExist == null)
                        {
                            bool res = db.Insert(newRelation);
                            if (res)
                            {
                                MessageBox.Show($"Отношение {newRelation} было успешно добавлено в базу данных", "Новое отношение \"ИМНС и Диспетчер\" добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                allImnsDisp.Add(newRelation);
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
                MessageBox.Show($"Чтобы добавить новое отношение \"ИМНС и Диспетчер\", необходимо заполнить следующие поля:{Environment.NewLine}- Наим. (наименование) ИМНС;{Environment.NewLine}- Наим. (наименование) диспетчера.", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
