using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1.Resources
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            docDataGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = new Font("Segoe Print", 12, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            docDataGrid.RowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = new Font("", 11, FontStyle.Regular),
                SelectionBackColor = Color.FromArgb(254, 118, 183)
            };
        }

        private void AddDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "XML-файлы (*.xml)|*.xml",
                Multiselect = true
            };

            open.ShowDialog();
            string[] fileNames = open.FileNames;
            foreach (string name in fileNames)
            {
                docDataGrid.Rows.Add(name);
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> docspath = new List<string>();
                foreach (DataGridViewRow row in docDataGrid.Rows)
                {
                    DataGridViewCell cell = row.Cells["PrimaryDocColumn"];
                    if (cell.Value != null && (string)row.Cells["StatusDocColumn"].Value != "Готово")
                    {
                        string value = cell.Value.ToString();
                        docspath.Add(value);
                    }
                }

                int i = 0;
                foreach (var path in docspath)
                {
                    try
                    {
                        XElement taxi = new XElement("taxi_company_report");
                        List<Trips> reports = Trips.LoadFromFile(path);
                        if (reports != null)
                        {
                            docDataGrid.Rows[i].Cells["StatusDocColumn"].Style.ForeColor = Color.Blue;
                            docDataGrid.Rows[i].Cells["StatusDocColumn"].Value = "В обработке...";
                            foreach (var rep in reports)
                            {
                                XElement report = new XElement("report");
                                XAttribute attr = new XAttribute("imns_code", rep.IMNS.Imns_code);
                                report.Add(attr);
                                attr = new XAttribute("imns_name", rep.IMNS.Imns_name);
                                report.Add(attr);
                                attr = new XAttribute("dispatcher_name", rep.Dispatcher.Dispatcher_name);
                                report.Add(attr);
                                attr = new XAttribute("dispatcher_unp", rep.Dispatcher.Dispatcher_unp);
                                report.Add(attr);
                                XElement elem = new XElement("carrier_name", rep.Carrier.Carrier_name);
                                report.Add(elem);
                                elem = new XElement("carrier_unp", rep.Carrier.Carrier_unp);
                                report.Add(elem);
                                elem = new XElement("ur_ip", rep.Carrier.Ur_ip);
                                report.Add(elem);
                                elem = new XElement("brand", rep.Car.Brand);
                                report.Add(elem);
                                elem = new XElement("number_plate", rep.Car.Number_plate);
                                report.Add(elem);
                                elem = new XElement("date_shift", rep.Date_shift);
                                report.Add(elem);
                                elem = new XElement("order_total", rep.Order_total);
                                report.Add(elem);
                                elem = new XElement("es_order_count", rep.Es_order_count);
                                report.Add(elem);
                                elem = new XElement("es_name", rep.Es_name);
                                report.Add(elem);
                                taxi.Add(report);
                            }

                            XDocument xdoc = new XDocument(taxi);
                            var savepath = docDataGrid.Rows[i].Cells["SavePathColumn"].Value.ToString();
                            xdoc.Save(savepath, SaveOptions.None);
                            docDataGrid.Rows[i].Cells["StatusDocColumn"].Style.ForeColor = Color.Black;
                            docDataGrid.Rows[i].Cells["StatusDocColumn"].Style.BackColor = Color.LightGreen;
                            docDataGrid.Rows[i].Cells["StatusDocColumn"].Value = "Готово";
                            i++;
                        }
                        else
                        {
                            docDataGrid.Rows[i].Cells["StatusDocColumn"].Style.ForeColor = Color.Red;
                            docDataGrid.Rows[i].Cells["StatusDocColumn"].Value = "Ошибка!";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при преобразовании документа {path}: {ex.Message}{Environment.NewLine}{ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        docDataGrid.Rows[i].Cells["StatusDocColumn"].Style.ForeColor = Color.Red;
                        docDataGrid.Rows[i].Cells["StatusDocColumn"].Value = "Ошибка!";
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при преобразовании документов: {ex.Message}{Environment.NewLine}{ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in docDataGrid.Rows)
            {
                string cell = row.Cells["StatusDocColumn"].Value.ToString();
                if (cell == "Готово")
                {
                    row.Cells["StatusDocColumn"].Value = "";
                    row.Cells["StatusDocColumn"].Style.ForeColor = Color.Black;
                    row.Cells["StatusDocColumn"].Style.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void PathTextBox_DoubleClick(object sender, EventArgs e)
        {
            PathTextBox.Clear();
            SaveFileDialog save = new SaveFileDialog
            {
                OverwritePrompt = true,
                RestoreDirectory = true,
                Filter = "XML-файлы (*.xml)|*.xml",
                FileName = "Новый XML-файл"
            };

            var result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                string name = save.FileName;
                if (!string.IsNullOrEmpty(name))
                {
                    PathTextBox.Text = name;
                }
            }
        }

        private void docsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == docDataGrid.Columns["SavePathColumn"].Index && e.RowIndex >= 0)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    OverwritePrompt = true,
                    RestoreDirectory = true,
                    Filter = "XML-файлы (*.xml)|*.xml",
                    FileName = "Новый XML-файл"
                };

                DialogResult result = save.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string selectedPath = save.FileName;
                    docDataGrid.Rows[e.RowIndex].Cells["SavePathColumn"].Value = selectedPath;
                }
            }
        }

        private void SavePathAllDocsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SavePathAllDocsCheck.CheckState == CheckState.Checked && PathTextBox.Text != "Выберите путь сохранения и имя документа")
            {
                int columnIndex = docDataGrid.Columns["SavePathColumn"].Index;
                foreach (DataGridViewRow row in docDataGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells[columnIndex].Value = PathTextBox.Text;
                    }
                }
            }
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SavePathAllDocsCheck.CheckState == CheckState.Checked)
            {
                string valueToFill = PathTextBox.Text;
                int columnIndex = docDataGrid.Columns["SavePathColumn"].Index;
                foreach (DataGridViewRow row in docDataGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells[columnIndex].Value = valueToFill;
                    }
                }
            }
        }

        private void HelpProviderMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram form = new AboutProgram();
            form.ShowDialog();
        }
    }
}
