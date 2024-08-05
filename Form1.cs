using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Resources;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Описывает работу главной формы программного средства.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Поле класса <see cref="DB"/>, предоставляющего работу с базой данных.
        /// </summary>
        private DB database;

        /// <summary>
        /// Конструктор без параметров класса <see cref="Form1"/>.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            panel.Visible = false;
        }

        /// <summary>
        /// Открывает форму подключения к серверу базы данных.
        /// </summary>
        private void OpenConnection_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                ConnectionForm connect = new ConnectionForm();
                connect.ConnectionInfoProvided += ConnectionForm_ConnectionInfoProvided;
                connect.Show();
            }
        }

        /// <summary>
        /// Делегат, который получает имя сервера и базы данных после закрытия формы подключения.
        /// </summary>
        /// <param name="databaseName">Имя сервера</param>
        /// <param name="serverName">Имя базы данных</param>
        private void ConnectionForm_ConnectionInfoProvided(string serverName, string databaseName)
        {
            try
            {
                database = new DB(serverName, databaseName);
                panel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при передаче данных через делегат: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Прерывает соединение с сервером базы данных.
        /// </summary>
        private void InterruptConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (database != null)
                {
                    tabControl.TabPages.Clear();
                    database = null;
                    panel.Visible = false;
                    tabControl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось отключиться от сервера: {ex.Message}{Environment.NewLine}{ex.StackTrace}", "Ошибка отключения", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void OpenTabPage(object sender, EventArgs e)
        {
            try
            {
                if (database != null && sender is Button b)
                {
                    string tableName = DB.GetEnglishTableName(b.Text);
                    foreach (TabPage t in tabControl.TabPages)
                    {
                        if (t.Text == b.Text)
                        {
                            tabControl.SelectedTab = t;
                            return;
                        }
                    }
                    TabPage tabPage = new TabPage(b.Text);
                    if (tabControl.TabPages.ContainsKey(b.Text) != true)
                    {
                        tabPage.Name = tableName;
                        MyTable myTable = new MyTable()
                        {
                            Name = tableName,
                            Dock = DockStyle.Fill
                        };
                        myTable.AddButton.Click += AddNew_Click;
                        myTable.DeleteButton.Click += DeleteRows_Click;
                        myTable.ExcelButton.Click += ExportTableToExcel_Click;
                        myTable.EditButton.Click += Update_Click;
                        myTable.RefreshButton.Click += Refresh_Click;
                        switch (tableName)
                        {
                            case "Trips":
                            case "IMNS_Dispatcher":
                            case "Dispatcher_Carrier":
                            case "Carrier_Car":
                                {
                                    myTable.DataGrid.DataSource = database.LoadDataFromView(tabPage.Name);
                                    break;
                                }
                            default:
                                {
                                    myTable.DataGrid.DataSource = database.LoadDataFromTable(tabPage.Name);
                                    break;
                                }
                        }

                        if (myTable.DataGrid.DataSource != null)
                        {
                            foreach (DataGridViewColumn column in myTable.DataGrid.Columns)
                            {
                                if (column.HeaderText == "id")
                                    column.Visible = false;
                                column.HeaderText = DB.GetRussianColumnName(column.Name);
                            }

                            tabPage.Controls.Add(myTable);
                            if (tabControl.Visible == false)
                                tabControl.Visible = true;
                            tabControl.Controls.Add(tabPage);
                            tabControl.SelectedTab = tabPage;
                            tabPage.Controls.Add(myTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть вкладку: {ex.Message}", "Ошибка открытия вкладки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            MyTable current = (MyTable)tabControl.SelectedTab.Controls[0];
            switch (current.Name)
            {
                case "Trips":
                case "IMNS_Dispatcher":
                case "Dispatcher_Carrier":
                case "Carrier_Car":
                    {
                        current.DataGrid.DataSource = database.LoadDataFromView(current.Name);
                        break;
                    }
                default:
                    {
                        current.DataGrid.DataSource = database.LoadDataFromTable(current.Name);
                        break;
                    }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            MyTable current = (MyTable)tabControl.SelectedTab.Controls[0];
            if (current.DataGrid.SelectedRows.Count > 0 && current != null)
            {
                var selected = current.DataGrid.SelectedRows[0];
                Form addForm;
                switch (current.Name)
                {
                    case "Trips":
                        {

                            Trips x = database.GetObjectByPrimaryKey("Trips", "id", Convert.ToInt32(selected.Cells[0].Value.ToString())) as Trips;
                            addForm = new TripForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Dispatcher":
                        {
                            Dispatcher x = new Dispatcher()
                            {
                                Dispatcher_unp = selected.Cells[0].Value.ToString(),
                                Dispatcher_name = selected.Cells[1].Value.ToString()
                            };

                            addForm = new DispatcherForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Carrier":
                        {
                            Carrier x = new Carrier()
                            {
                                Carrier_unp = selected.Cells[0].Value.ToString(),
                                Carrier_name = selected.Cells[1].Value.ToString(),
                                Ur_ip = Convert.ToBoolean(selected.Cells[2].Value)
                            };

                            addForm = new CarrierForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Car":
                        {
                            Car x = new Car()
                            {
                                Id = Convert.ToInt32(selected.Cells[0].Value),
                                Brand = selected.Cells[1].Value.ToString(),
                                Number_plate = selected.Cells[2].Value.ToString(),
                            };

                            addForm = new CarForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "IMNS":
                        {
                            IMNS x = new IMNS()
                            {
                                Imns_code = Convert.ToInt32(selected.Cells[0].Value),
                                Imns_name = selected.Cells[1].Value.ToString(),
                            };

                            addForm = new IMNSForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "IMNS_Dispatcher":
                        {
                            IMNS_Dispatcher x = database.GetObjectByPrimaryKey("IMNS_Dispatcher", "id", Convert.ToInt32(selected.Cells[0].Value)) as IMNS_Dispatcher;
                            addForm = new ImnsDispForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Dispatcher_Carrier":
                        {
                            Dispatcher_Carrier x = database.GetObjectByPrimaryKey("Dispatcher_Carrier", "id", Convert.ToInt32(selected.Cells[0].Value)) as Dispatcher_Carrier;
                            addForm = new DispCarrierForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Carrier_Car":
                        {
                            Carrier_Car x = database.GetObjectByPrimaryKey("Carrier_Car", "id", Convert.ToInt32(selected.Cells[0].Value)) as Carrier_Car;
                            addForm = new CarrierCarForm(database, x);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show($"Не найден конструктор добавления для таблицы {DB.GetRussianTableName(current.Name)}. Возможно, что он не предусмотрен, либо такой таблицы не существует", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Выберите объект для изменения. Для этого выделите всю строку в таблице", "Не выбран объект", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            MyTable current = (MyTable)tabControl.SelectedTab.Controls[0];
            if (current != null)
            {
                Form addForm;
                switch (current.Name)
                {
                    case "Trips":
                        {
                            addForm = new TripForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Dispatcher":
                        {
                            addForm = new DispatcherForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Carrier":
                        {
                            addForm = new CarrierForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Car":
                        {
                            addForm = new CarForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "IMNS":
                        {
                            addForm = new IMNSForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "IMNS_Dispatcher":
                        {
                            addForm = new ImnsDispForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Dispatcher_Carrier":
                        {
                            addForm = new DispCarrierForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    case "Carrier_Car":
                        {
                            addForm = new CarrierCarForm(database);
                            addForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                            addForm.ShowDialog();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show($"Не найден конструктор добавления для таблицы {DB.GetRussianTableName(current.Name)}. Возможно, что он не предусмотрен, либо такой таблицы не существует", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                }
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Refresh_Click(sender, e);
        }

        /// <summary>
        /// Открывает форму преобразования XML-документов <see cref="Form2"/>.
        /// </summary>
        private void ConvertFormOpen_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        /// <summary>
        /// Считывает XML-документ по указанному пути и формирует новую вкладку с таблицей из полученных данных.
        /// </summary>
        private void OpenXML_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog
                {
                    Title = "Открыть файл",
                    Filter = "XML-файлы (*.xml)|*.xml",
                    Multiselect = true
                };
                string[] fullname = null;
                var result = open.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    fullname = open.FileNames;
                    foreach (string name in fullname)
                    {
                        TabPage tabPage = new TabPage(name)
                        {
                            Name = name,
                            BackColor = System.Drawing.Color.FromArgb(4, 5, 12),
                            ContextMenuStrip = TabCloseContext
                        };
                        tabPage.MouseClick += MouseRightClick_OnTab;
                        MyTable myTable = new MyTable();
                        myTable.Dock = DockStyle.Fill;
                        List<Trips> reports = Trips.LoadFromFile(name);
                        myTable.DataGrid.Rows.Clear();
                        myTable.DataGrid.Columns.Clear();
                        myTable.DataGrid.Columns.Add("date_shift", "Дата смены");
                        myTable.DataGrid.Columns.Add("imns_code", "Код ИМНС");
                        myTable.DataGrid.Columns.Add("imns_name", "Наим. ИМНС");
                        myTable.DataGrid.Columns.Add("dispatcher_unp", "УНП диспетчера");
                        myTable.DataGrid.Columns.Add("dispatcher_name", "Наим. диспетчера");
                        myTable.DataGrid.Columns.Add("carrier_unp", "УНП перевозчика");
                        myTable.DataGrid.Columns.Add("carrier_name", "Наим. перевозчика");
                        myTable.DataGrid.Columns.Add("brand", "Модель авто");
                        myTable.DataGrid.Columns.Add("number_plate", "Гос. рег. знак");
                        myTable.DataGrid.Columns.Add("order_total", "Кол-во заказов, всего шт.");
                        myTable.DataGrid.Columns.Add("es_order_count", "с исп. ЭИС, шт.");
                        myTable.DataGrid.Columns.Add("es_name", "Наим. ЭИС");
                        if (reports != null)
                        {
                            foreach (var report in reports)
                            {
                                myTable.DataGrid.Rows.Add(report.Date_shift, report.IMNS.Imns_code, report.IMNS.Imns_name, report.Dispatcher.Dispatcher_unp, report.Dispatcher.Dispatcher_name, report.Carrier.Carrier_unp, report.Carrier.Carrier_name, report.Car.Brand, report.Car.Number_plate, report.Order_total, report.Es_order_count, report.Es_name);
                            }
                        }
                        myTable.DataGrid.ContextMenuStrip = SaveToDBContext;
                        tabPage.Controls.Add(myTable);
                        tabControl.TabPages.Add(tabPage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        /// <summary>
        /// Экспортирует выбранную таблицу в Excel.
        /// </summary>
        private void ExportTableToExcel_Click(object sender, EventArgs e)
        {
            if (GetSheetName() != "")
            {
                string sheetName = GetSheetName();

                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Экспорт в Excel",
                    Filter = "Лист Excel (*.xlsx)|*.xlsx",
                    OverwritePrompt = true,
                    FileName = $"{sheetName} от {DateTime.Now.ToShortDateString().Replace('.', '-')}"
                };

                var result = save.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    var filename = save.FileName;
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);
                            if (tabControl.SelectedTab.Controls[0] is MyTable current)
                            {
                                if (sheetName == "Поездки")
                                {
                                    worksheet.Cells["A1:G1"].Merge = true;
                                    worksheet.Cells["A1"].Value = "Информация о выполненных перевозках пассажиров автомобилями-такси";
                                    worksheet.Cells["A1"].Style.Font.Size = 14;
                                    worksheet.Cells["A1"].Style.Font.Bold = true;
                                    AddColumnHeaders(current, worksheet, 3);
                                    AddDataRows(current, worksheet, 4);
                                    excelPackage.SaveAs(new FileInfo(filename));
                                }
                                else
                                {
                                    AddColumnHeaders(current, worksheet, 1);
                                    AddDataRows(current, worksheet, 2);
                                    excelPackage.SaveAs(new FileInfo(filename));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}{Environment.NewLine}{ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает название листа Excel на основании имени вкладки.
        /// </summary>
        /// <returns>Название листа Excel d формате строки <see cref="string"/></returns>
        private string GetSheetName()
        {
            if (tabControl.SelectedTab != null)
                return tabControl.SelectedTab.Text;

            return "";
        }

        /// <summary>
        /// Добавляет в лист Excel столбцы из выбранной таблицы.
        /// </summary>
        /// <param name="tableControl">Объект класса <see cref="MyTable"/>, представляющий выбранную таблицу для экспорта</param>
        /// <param name="worksheet">Лист Excel</param>
        private void AddColumnHeaders(MyTable tableControl, ExcelWorksheet worksheet, int startRow)
        {
            int columnIndex = 1;
            foreach (DataGridViewColumn column in tableControl.DataGrid.Columns)
            {
                if (column.HeaderText != "id")
                {
                    worksheet.Cells[startRow, columnIndex].Value = column.HeaderText;
                    worksheet.Cells[startRow, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[startRow, columnIndex].Style.Font.Bold = true;
                    worksheet.Cells[startRow, columnIndex].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    columnIndex++;
                }
            }

            worksheet.Cells[1, columnIndex].AutoFitColumns();
        }

        /// <summary>
        /// Добавляет в лист Excel строки из выбранной таблицы.
        /// </summary>
        /// <param name="tableControl">Объект класса <see cref="MyTable"/>, представляющий выбранную таблицу для экспорта</param>
        /// <param name="worksheet">Лист Excel</param>
        private void AddDataRows(MyTable tableControl, ExcelWorksheet worksheet, int rowStart)
        {
            int rowCounter = rowStart;
            foreach (DataGridViewRow row in tableControl.DataGrid.Rows)
            {
                int colCounter = 1;
                if (tableControl.DataGrid.Columns.Contains("id") == true)
                    colCounter = 0;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (tableControl.DataGrid.Columns[cell.ColumnIndex].HeaderText != "id")
                    {
                        if (cell.Value is DateTime dateValue)
                        {
                            worksheet.Cells[rowCounter, colCounter].Value = dateValue;
                            worksheet.Cells[rowCounter, colCounter].Style.Numberformat.Format = "dd-MM-yyyy";
                        }
                        else
                        {
                            worksheet.Cells[rowCounter, colCounter].Value = cell.Value;
                        }

                        string header = tableControl.DataGrid.Columns[cell.ColumnIndex].HeaderText;
                        worksheet.Cells[rowCounter, colCounter].Style.HorizontalAlignment = header == "Код ИМНС" || header == "Юр.лицо/ИП" ? ExcelHorizontalAlignment.Center : ExcelHorizontalAlignment.Left;
                    }

                    colCounter++;
                }
                rowCounter++;
            }
            worksheet.Columns.AutoFit();
            foreach (ExcelRangeBase cell in worksheet.Cells)
            {
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }
        }

        /// <summary>
        /// Обработчик события клика по пункту меню "Сформировать представление"
        /// </summary>
        private void CreateViewMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                ViewForm view = new ViewForm(database);
                view.OnViewTableCreated += HandleViewTable;
                view.ShowDialog();
            }
            else
            {
                MessageBox.Show($"Вы не подключены к серверу. Необходимо подключиться к серверу базы данных, чтобы сформировать представление. {Environment.NewLine}Для этого выберите в меню \"База данных\" -> \"Установить соединение\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HandleViewTable(DataTable viewTable)
        {
            TabPage tabPage = new TabPage("Отчет");
            if (tabControl.TabPages.ContainsKey("Отчет") != true)
            {
                MyTable myTable = new MyTable()
                {
                    Dock = DockStyle.Fill,
                };
                myTable.DataGrid.DataSource = viewTable;
                myTable.ExcelButton.Click += ExportView_Click;
                if (myTable.DataGrid.DataSource != null)
                {
                    foreach (DataGridViewColumn column in myTable.DataGrid.Columns)
                    {
                        if (column.HeaderText == "id")
                            column.Visible = false;

                        column.HeaderText = DB.GetRussianColumnName(column.Name);
                    }

                    tabPage.Controls.Add(myTable);
                    tabControl.Controls.Add(tabPage);
                    tabControl.SelectedTab = tabPage;
                    tabPage.Controls.Add(myTable);
                }
            }
        }

        private void ExportView_Click(object sender, EventArgs e)
        {
            if (GetSheetName() != "")
            {
                string sheetName = GetSheetName();

                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Экспорт в Excel",
                    Filter = "Лист Excel (*.xlsx)|*.xlsx",
                    OverwritePrompt = true,
                    FileName = $"{sheetName} от {DateTime.Now.ToShortDateString().Replace('.', '-')}"
                };

                var result = save.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    var filename = save.FileName;
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);
                            if (tabControl.SelectedTab.Controls[0] is MyTable current)
                            {
                                AddColumnHeaders(current, worksheet, 1);
                                AddDataRows(current, worksheet, 2);
                                excelPackage.SaveAs(new FileInfo(filename));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}{Environment.NewLine}{ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //.............................
        private void ViewForm_FormClosedEvent(TabPage tabPage)
        {
            tabControl.Controls.Add(tabPage);
        }

        /// <summary>
        /// Удаляет вкладку <see cref="TabPage"/> из коллекции вкладок класса <see cref="TabControl"/>.
        /// </summary>
        private void CloseTab_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabControl.SelectedTab);
        }

        /// <summary>
        /// Удаляет выделенные строки в таблице из базы данных.
        /// </summary>
        private void DeleteRows_Click(object sender, EventArgs e)
        {
            MyTable current = (MyTable)tabControl.SelectedTab.Controls[0];
            string tabName = tabControl.SelectedTab.Text;
            if (current.DataGrid.SelectedRows.Count != 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выделенные строки?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                bool deleteResult = false;
                if (result == DialogResult.Yes)
                {
                    string table = "";
                    string columnID = "id";
                    switch (tabName)
                    {
                        case "Диспетчеры":
                            {
                                table = "Dispatcher";
                                columnID = "dispatcher_unp";
                                break;
                            }
                        case "Перевозчики":
                            {
                                table = "Carrier";
                                columnID = "carrier_unp";
                                break;
                            }
                        case "ИМНС":
                            {
                                table = "IMNS";
                                columnID = "imns_code";
                                break;
                            }
                        case "Авто":
                            {
                                table = "Car";
                                columnID = "id";
                                break;
                            }
                        case "ИМНС и Диспетчеры":
                            {
                                table = "IMNS_Dispatcher";
                                columnID = "id";
                                break;
                            }
                        case "Диспетчеры и Перевозчики":
                            {
                                table = "Dispatcher_Carrier";
                                columnID = "id";
                                break;
                            }
                        case "Перевозчики и Авто":
                            {
                                table = "Carrier_Car";
                                columnID = "id";
                                break;
                            }
                        case "Поездки":
                            {
                                table = "Trips";
                                columnID = "id";
                                break;
                            }
                    }

                    foreach (DataGridViewRow row in current.DataGrid.SelectedRows)
                    {
                        string value = row.Cells[columnID].Value.ToString();
                        deleteResult = database.DeleteValues(table, columnID, value);
                    }

                    if (deleteResult)
                    {
                        MessageBox.Show("Выбранные строки успешно удалены из базы данных. Закройте и откройте вкладку повторно.", "Удаление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строки для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// //////////...................
        private void SaveFromFileToDB_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show($"Вы не подключены к серверу. Чтобы сохранить данные из отчета в базу данных, необходимо подключиться к серверу базы данных.{Environment.NewLine}Для этого выберете в меню \"База данных\" -> \"Установить соединение\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                bool result = false;
                using (SqlConnection connection = new SqlConnection(database.Connection))
                {
                    connection.Open();
                    string path = tabControl.SelectedTab.Name;
                    List<Trips> reports = Trips.LoadFromFile(path);
                    if (reports != null)
                    {
                        foreach (var report in reports)
                        {
                            string checkDuplicateQuery = "SELECT COUNT(*) FROM Car WHERE brand = @brand AND number_plate = @number_plate";
                            SqlCommand checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@brand", report.Car.Brand);
                            checkDuplicateCmd.Parameters.AddWithValue("@number_plate", report.Car.Number_plate);
                            int existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (existingCount == 0)
                            {
                                string insertCar = "INSERT INTO Car (brand, number_plate) VALUES (@brand, @number_plate)";
                                SqlCommand carCommand = new SqlCommand(insertCar, connection);
                                carCommand.Parameters.AddWithValue("@brand", report.Car.Brand);
                                carCommand.Parameters.AddWithValue("@number_plate", report.Car.Number_plate);
                                carCommand.ExecuteNonQuery();
                                result = true;
                            }

                            checkDuplicateQuery = "SELECT COUNT(*) FROM Carrier WHERE carrier_unp = @carrier_unp OR carrier_name = @carrier_name";
                            checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@carrier_unp", report.Carrier.Carrier_unp);
                            checkDuplicateCmd.Parameters.AddWithValue("@carrier_name", report.Carrier.Carrier_name);
                            existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (existingCount == 0)
                            {
                                string insertCarrier = "INSERT INTO Carrier (carrier_unp, carrier_name, ur_ip) VALUES (@carrier_unp, @carrier_name, @ur_ip)";
                                SqlCommand carrierCmd = new SqlCommand(insertCarrier, connection);
                                carrierCmd.Parameters.AddWithValue("@carrier_unp", report.Carrier.Carrier_unp);
                                carrierCmd.Parameters.AddWithValue("@carrier_name", report.Carrier.Carrier_name);
                                carrierCmd.Parameters.AddWithValue("@ur_ip", report.Carrier.Ur_ip);
                                carrierCmd.ExecuteNonQuery();
                                result = true;
                            }

                            checkDuplicateQuery = "SELECT COUNT(*) FROM IMNS WHERE imns_code = @imns_code OR imns_name = @imns_name";
                            checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@imns_code", report.IMNS.Imns_code);
                            checkDuplicateCmd.Parameters.AddWithValue("@imns_name", report.IMNS.Imns_name);
                            existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (existingCount == 0)
                            {
                                string insertIMNS = "INSERT INTO IMNS (imns_code, imns_name) VALUES (@imns_code, @imns_name)";
                                SqlCommand imnsCmd = new SqlCommand(insertIMNS, connection);
                                imnsCmd.Parameters.AddWithValue("@imns_code", report.IMNS.Imns_code);
                                imnsCmd.Parameters.AddWithValue("@imns_name", report.IMNS.Imns_name);
                                imnsCmd.ExecuteNonQuery();
                                result = true;
                            }

                            checkDuplicateQuery = "SELECT COUNT(*) FROM Dispatcher WHERE dispatcher_unp = @dispatcher_unp OR dispatcher_name = @dispatcher_name";
                            checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@dispatcher_unp", report.Dispatcher.Dispatcher_unp);
                            checkDuplicateCmd.Parameters.AddWithValue("@dispatcher_name", report.Dispatcher.Dispatcher_name);
                            existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (existingCount == 0)
                            {
                                string insertDispatcher = "INSERT INTO Dispatcher (dispatcher_unp, dispatcher_name) VALUES (@dispatcher_unp, @dispatcher_name)";
                                SqlCommand dispatcherCmd = new SqlCommand(insertDispatcher, connection);
                                dispatcherCmd.Parameters.AddWithValue("@dispatcher_unp", report.Dispatcher.Dispatcher_unp);
                                dispatcherCmd.Parameters.AddWithValue("@dispatcher_name", report.Dispatcher.Dispatcher_name);
                                dispatcherCmd.ExecuteNonQuery();
                                result = true;
                            }

                            checkDuplicateQuery = "SELECT COUNT(*) FROM IMNS_Dispatcher WHERE imns = @imns AND dispatcher = @dispatcher";
                            checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@imns", report.IMNS.Imns_code);
                            checkDuplicateCmd.Parameters.AddWithValue("@dispatcher", report.Dispatcher.Dispatcher_unp);
                            existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (existingCount == 0)
                            {
                                string imnsDispatcherQuery = "INSERT INTO IMNS_Dispatcher (imns, dispatcher) VALUES (@imns, @dispatcher)";
                                SqlCommand imnsDispatcherCmd = new SqlCommand(imnsDispatcherQuery, connection);
                                imnsDispatcherCmd.Parameters.AddWithValue("@imns", report.IMNS.Imns_code);
                                imnsDispatcherCmd.Parameters.AddWithValue("@dispatcher", report.Dispatcher.Dispatcher_unp);
                                imnsDispatcherCmd.ExecuteNonQuery();
                                result = true;
                            }

                            checkDuplicateQuery = "SELECT COUNT(*) FROM Dispatcher_Carrier WHERE dispatcher = @dispatcher AND carrier = @carrier";
                            checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@dispatcher", report.Dispatcher.Dispatcher_unp);
                            checkDuplicateCmd.Parameters.AddWithValue("@carrier", report.Carrier.Carrier_unp);
                            existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (existingCount == 0)
                            {
                                string imnsDispatcherQuery = "INSERT INTO Dispatcher_Carrier (dispatcher, carrier) VALUES (@dispatcher, @carrier)";
                                SqlCommand imnsDispatcherCmd = new SqlCommand(imnsDispatcherQuery, connection);
                                imnsDispatcherCmd.Parameters.AddWithValue("@dispatcher", report.Dispatcher.Dispatcher_unp);
                                imnsDispatcherCmd.Parameters.AddWithValue("@carrier", report.Carrier.Carrier_unp);
                                imnsDispatcherCmd.ExecuteNonQuery();
                                result = true;
                            }

                            // Получение id автомобиля из таблицы Car
                            string getCarIdQuery = "SELECT id FROM Car WHERE brand = @brand AND number_plate = @number_plate";
                            SqlCommand getCarIdCmd = new SqlCommand(getCarIdQuery, connection);
                            getCarIdCmd.Parameters.AddWithValue("@brand", report.Car.Brand);
                            getCarIdCmd.Parameters.AddWithValue("@number_plate", report.Car.Number_plate);
                            int carId = (int)getCarIdCmd.ExecuteScalar();

                            // Проверка наличия записи в таблице Carrier_Car
                            checkDuplicateQuery = "SELECT COUNT(*) FROM Carrier_Car WHERE carrier = @carrier AND car = @car";
                            checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@carrier", report.Carrier.Carrier_unp);
                            checkDuplicateCmd.Parameters.AddWithValue("@car", carId);
                            existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            // Если запись не существует, добавляем её
                            if (existingCount == 0)
                            {
                                string insertQuery = "INSERT INTO Carrier_Car (carrier, car) VALUES (@carrier, @car)";
                                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                                insertCmd.Parameters.AddWithValue("@carrier", report.Carrier.Carrier_unp);
                                insertCmd.Parameters.AddWithValue("@car", carId);
                                insertCmd.ExecuteNonQuery();
                                result = true;
                            }

                            // Получение id из таблиц
                            int imnsDispatcherId = GetIdFromTable(connection, "IMNS_Dispatcher", "imns", "dispatcher", report.IMNS.Imns_code.ToString(), report.Dispatcher.Dispatcher_unp);
                            int dispatcherCarrierId = GetIdFromTable(connection, "Dispatcher_Carrier", "dispatcher", "carrier", report.Dispatcher.Dispatcher_unp, report.Carrier.Carrier_unp);
                            int carrierCarId = GetIdFromTable(connection, "Carrier_Car", "carrier", "car", report.Carrier.Carrier_unp, carId.ToString()); // carId получен из предыдущего примера

                            // Проверка наличия записи в таблице Trips
                            checkDuplicateQuery = "SELECT COUNT(*) FROM Trips WHERE date_shift = @date_shift AND imns_dispatcher = @imns_dispatcher AND dispatcher_carrier = @dispatcher_carrier AND carrier_car = @carrier_car AND order_total = @order_total AND es_order_count = @es_order_count AND es_name = @es_name";
                            checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, connection);
                            checkDuplicateCmd.Parameters.AddWithValue("@date_shift", report.Date_shift);
                            checkDuplicateCmd.Parameters.AddWithValue("@imns_dispatcher", imnsDispatcherId);
                            checkDuplicateCmd.Parameters.AddWithValue("@dispatcher_carrier", dispatcherCarrierId);
                            checkDuplicateCmd.Parameters.AddWithValue("@carrier_car", carrierCarId);
                            checkDuplicateCmd.Parameters.AddWithValue("@order_total", report.Order_total);
                            checkDuplicateCmd.Parameters.AddWithValue("@es_order_count", report.Es_order_count);
                            checkDuplicateCmd.Parameters.AddWithValue("@es_name", report.Es_name);
                            existingCount = (int)checkDuplicateCmd.ExecuteScalar();

                            // Если запись не существует, добавляем её
                            if (existingCount == 0)
                            {
                                string insertQuery = "INSERT INTO Trips (date_shift, imns_dispatcher, dispatcher_carrier, carrier_car, order_total, es_order_count, es_name) VALUES (@date_shift, @imns_dispatcher, @dispatcher_carrier, @carrier_car, @order_total, @es_order_count, @es_name)";
                                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                                insertCmd.Parameters.AddWithValue("@date_shift", report.Date_shift);
                                insertCmd.Parameters.AddWithValue("@imns_dispatcher", imnsDispatcherId);
                                insertCmd.Parameters.AddWithValue("@dispatcher_carrier", dispatcherCarrierId);
                                insertCmd.Parameters.AddWithValue("@carrier_car", carrierCarId);
                                insertCmd.Parameters.AddWithValue("@order_total", report.Order_total);
                                insertCmd.Parameters.AddWithValue("@es_order_count", report.Es_order_count);
                                insertCmd.Parameters.AddWithValue("@es_name", report.Es_name);
                                insertCmd.ExecuteNonQuery();
                                result = true;
                            }
                        }
                    }
                }
                if (result)
                {
                    MessageBox.Show("Недостающие данные из отчета были внесены в базу данных.");
                }
                else
                {
                    MessageBox.Show("Все найденные данные уже существуют в базе данных. Ничего не было добавлено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка при добавлении записей из файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для получения id из таблицы
        int GetIdFromTable(SqlConnection connection, string tableName, string firstColumnName, string secondColumnName, string firstColumnValue, string secondColumnValue)
        {
            string getIdQuery = $"SELECT id FROM {tableName} WHERE {firstColumnName} = @firstColumnValue AND {secondColumnName} = @secondColumnValue";
            SqlCommand getIdCmd = new SqlCommand(getIdQuery, connection);
            getIdCmd.Parameters.AddWithValue("@firstColumnValue", firstColumnValue);
            getIdCmd.Parameters.AddWithValue("@secondColumnValue", secondColumnValue);
            return (int)getIdCmd.ExecuteScalar();
        }

        /// <summary>
        /// Отображает контекстное меню при клике на правую кнопку мыши (ПКМ) по вкладке <see cref="TabPage"/>.
        /// </summary>
        private void MouseRightClick_OnTab(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TabCloseContext.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// ///////////////////////////////////////////...............................
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportAllTablesToExcel_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Экспорт в Excel",
                    Filter = "Лист Excel (*.xlsx)|*.xlsx",
                    OverwritePrompt = true,
                    FileName = $"Отчет всех таблиц от {DateTime.Now.ToShortDateString().Replace('.', '-')}"
                };

                var result = save.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    var filename = save.FileName;
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            foreach (var tableName in new string[] { "Trips", "IMNS_Dispatcher", "Dispatcher_Carrier", "Carrier_Car", "IMNS", "Dispatcher", "Carrier", "Car" })
                            {
                                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(DB.GetRussianTableName(tableName.ToString()));
                                MyTable current = new MyTable();
                                switch (tableName)
                                {
                                    case "Trips":
                                        {
                                            current.DataGrid.DataSource = database.LoadDataFromView(tableName);
                                            worksheet.Cells["A1:G1"].Merge = true;
                                            worksheet.Cells["A1"].Value = "Информация о выполненных перевозках пассажиров автомобилями-такси";
                                            worksheet.Cells["A1"].Style.Font.Size = 14;
                                            worksheet.Cells["A1"].Style.Font.Bold = true;
                                            foreach (DataGridViewColumn column in current.DataGrid.Columns)
                                            {
                                                if (column.HeaderText == "id")
                                                {
                                                    column.Visible = false;
                                                }
                                                column.HeaderText = DB.GetRussianColumnName(column.Name);
                                            }
                                            AddColumnHeaders(current, worksheet, 3);
                                            AddDataRows(current, worksheet, 4);
                                            break;
                                        }
                                    case "IMNS_Dispatcher":
                                    case "Dispatcher_Carrier":
                                    case "Carrier_Car":
                                        {
                                            current.DataGrid.DataSource = database.LoadDataFromView(tableName);
                                            foreach (DataGridViewColumn column in current.DataGrid.Columns)
                                            {
                                                if (column.HeaderText == "id")
                                                {
                                                    column.Visible = false;
                                                }
                                                column.HeaderText = DB.GetRussianColumnName(column.Name);
                                            }
                                            AddColumnHeaders(current, worksheet, 1);
                                            AddDataRows(current, worksheet, 2);

                                            break;
                                        }
                                    default:
                                        {
                                            current.DataGrid.DataSource = database.LoadDataFromTable(tableName);
                                            foreach (DataGridViewColumn column in current.DataGrid.Columns)
                                            {
                                                if (column.HeaderText == "id")
                                                {
                                                    column.Visible = false;
                                                }
                                                column.HeaderText = DB.GetRussianColumnName(column.Name);
                                            }
                                            AddColumnHeaders(current, worksheet, 1);
                                            AddDataRows(current, worksheet, 2);
                                            break;
                                        }
                                }
                                excelPackage.SaveAs(new FileInfo(filename));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}{Environment.NewLine}{ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Вы не подключены к серверу. Чтобы сохранить данные из отчета в базу данных, необходимо подключиться к серверу базы данных.{Environment.NewLine}Для этого выберете в меню \"База данных\" -> \"Установить соединение\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AboutProgram_Click(object sender, EventArgs e)
        {
            var about = new AboutProgram();
            about.ShowDialog();
        }

        private void HelpProviderMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
    }
