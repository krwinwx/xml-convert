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
    public partial class IMNSForm : Form
    {
        private readonly DB db = null;
        List<IMNS> allImns = null;
        IMNS selected = null;
        public IMNSForm(DB database)
        {
            InitializeComponent();

            db = database;
            allImns = db.GetAllIMNS();
            if (allImns != null && allImns.Count > 0)
            {
                foreach (IMNS imns in allImns)
                {
                    ImnsNameCB.Items.Add(imns.Imns_name);
                }

                ImnsNameCB.DropDownHeight = ImnsNameCB.ItemHeight * 10;
            }
            OkButton.Click -= Update;
            OkButton.Click += AddDispButton_Click;

        }
        public IMNSForm(DB database, IMNS i)
        {
            InitializeComponent();

            db = database;
            selected = i;
            allImns = db.GetAllIMNS();
            ImnsCodeTB.Text = selected.Imns_code.ToString();
            ImnsCodeTB.Enabled = false;
            ImnsNameCB.Text = selected.Imns_name.ToString();
            OkButton.Click -= AddDispButton_Click;
            OkButton.Click += Update;
            if (allImns != null && allImns.Count > 0)
            {
                foreach (IMNS imns in allImns)
                    ImnsNameCB.Items.Add(imns.Imns_name);

                ImnsNameCB.DropDownHeight = ImnsNameCB.ItemHeight * 10;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(ImnsCodeTB.Text) != true && string.IsNullOrEmpty(ImnsNameCB.Text) != true)
            {
                try
                {
                    string unp = ImnsCodeTB.Text.ToString().Trim();
                    string name = ImnsNameCB.Text.ToString().Trim();
                    IMNS d = new IMNS(Convert.ToInt32(unp), name);
                    bool isExist = db.CheckExist(d);
                    if (isExist == true)
                    {
                        MessageBox.Show($"ИМНС {d} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        bool res = db.Update(d);
                        if (res)
                        {
                            MessageBox.Show($"Данные изменены. ИМНС {d} успешно добавлено в базу данных", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ImnsNameCB.Items.Add(d.Imns_name);
                            ImnsNameCB.Items.Remove(selected.Imns_name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось обновить ИМНС. Причина: {ex.Message}", $"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Чтобы обновить запись в таблице ИМНС, необходимо изменить значение поля \"Наим. ИМНС\".{Environment.NewLine}!!! ВНИМАНИЕ!!! Изменить \"Код ИМНС\" НЕЛЬЗЯ. Если Вы допустили ошибку при добавлении, то необходимо удалить неправильную запись и добавить новую! ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AddDispButton_Click(object sender, EventArgs e)
        {
            if (db != null && string.IsNullOrEmpty(ImnsCodeTB.Text) != true && string.IsNullOrEmpty(ImnsCodeTB.Text) != true)
            {
                try
                {
                    int code = Convert.ToInt32(ImnsCodeTB.Text.Trim());
                    string name = ImnsNameCB.Text.Trim();
                    IMNS newImns = new IMNS(code, name);
                    bool isExist = db.CheckExist(newImns);
                    if (isExist == true)
                    {
                        MessageBox.Show($"ИМНС {newImns} уже существует в базе данных. Транзакция отклонена.", "Попытка добавить дубликат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        bool res = db.Insert(newImns);
                        if (res)
                        {
                            MessageBox.Show($"ИМНС {newImns} была успешно добавлен в базу данных", "Новая ИМНС добавлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ImnsNameCB.Items.Add(newImns.Imns_name);
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
                MessageBox.Show($"Чтобы добавить новую запись в таблицу ИМНС, необходимо заполнить следующие поля:{Environment.NewLine}- Код ИМНС;{Environment.NewLine}- Наим. (наименование) ИМНС.{Environment.NewLine}Поле \"Связанные Диспетчеры\" на данном этапе не обязательны для заполнения", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ImnsNameCB_SelectedValueChanged(object sender, EventArgs e)
        {
            int code = db.GetPrimaryKeyByValue("IMNS", "imns_code", "imns_name", ImnsNameCB.SelectedItem.ToString());
            if (code != -1)
                ImnsCodeTB.Text = code.ToString();
        }


        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
