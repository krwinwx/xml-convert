using SharpCompress;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ViewForm : Form
    {
        public delegate void MyTableEventHandler(DataTable viewTable);
        public event MyTableEventHandler OnViewTableCreated;

        DB database = null;

        public ViewForm(DB database)
        {
            this.database = database;
            InitializeComponent();
            TablesTreeView.ExpandAll();
        }

        private void TablesTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Отключаем обработчик события на время изменения состояния дочерних узлов, чтобы предотвратить рекурсию
            TablesTreeView.AfterCheck -= TablesTreeView_AfterCheck;

            try
            {
                // Устанавливаем такое же состояние для всех дочерних узлов
                SetNodeCheckState(e.Node, e.Node.Checked);

                // Обновляем DataGridView
                UpdateFieldsDataGridView(e.Node, e.Node.Checked);
            }
            finally
            {
                // Возвращаем обработчик события
                TablesTreeView.AfterCheck += TablesTreeView_AfterCheck;
            }
        }

        private void SetNodeCheckState(TreeNode node, bool isChecked)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                childNode.Checked = isChecked;
                SetNodeCheckState(childNode, isChecked); // Рекурсивно устанавливаем состояние для всех дочерних узлов
            }
        }

        private void UpdateFieldsDataGridView(TreeNode node, bool isChecked)
        {
            if (isChecked)
            {
                AddNodeToDataGridView(node);
                node.ExpandAll(); 
            }
            else
            {
                RemoveNodeFromDataGridView(node);
            }
        }

        private void AddNodeToDataGridView(TreeNode node)
        {
            if (node.Parent == null)
            {
                AddRowsToDataGridView(node.Text, node.Nodes);
            }
            else
            {
                AddRowToDataGridView(node.Parent.Text, node.Text);
            }
        }

        private void AddRowToDataGridView(string parentText, string childText)
        {
            foreach (DataGridViewRow row in FieldsDataGrid.Rows)
            {
                if (row.Cells["Table"].Value != null && row.Cells["Column"].Value != null &&
                    row.Cells["Table"].Value.ToString() == parentText &&
                    row.Cells["Column"].Value.ToString() == childText)
                {
                    // Такая строка уже существует
                    return;
                }
            }

            // Добавляем новую строку
            FieldsDataGrid.Rows.Add(parentText, childText);
        }

        private void AddRowsToDataGridView(string parentText, TreeNodeCollection childNodes)
        {
            foreach (TreeNode childNode in childNodes)
            {
                AddRowToDataGridView(parentText, childNode.Text);
                AddRowsToDataGridView(childNode.Text, childNode.Nodes);
            }
        }

        private void RemoveNodeFromDataGridView(TreeNode node)
        {
            if (node.Parent == null)
            {
                // Узел является корневым
                RemoveRowsFromDataGridView(node.Text, node.Nodes);
            }
            else
            {
                // Узел является дочерним
                RemoveRowFromDataGridView(node.Parent.Text, node.Text);
            }
        }

        private void RemoveRowFromDataGridView(string parentText, string childText)
        {
            for (int i = FieldsDataGrid.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = FieldsDataGrid.Rows[i];
                if (row.Cells["Table"].Value != null && row.Cells["Column"].Value != null &&
                    row.Cells["Table"].Value.ToString() == parentText &&
                    row.Cells["Column"].Value.ToString() == childText)
                {
                    FieldsDataGrid.Rows.RemoveAt(i);
                }
            }
        }

        private void RemoveRowsFromDataGridView(string parentText, TreeNodeCollection childNodes)
        {
            foreach (TreeNode childNode in childNodes)
            {
                RemoveRowFromDataGridView(parentText, childNode.Text);
                RemoveRowsFromDataGridView(childNode.Text, childNode.Nodes);
            }
        }

        private void CreateNewViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = CreateSqlQuery();
                if (query == "")
                {
                    MessageBox.Show("Произошла оишбка при формировании запроса...", "Пустой запрос", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DataTable results = ExecuteSqlQuery(query);
                    DisplayResults(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}{Environment.NewLine}{ex.StackTrace}", $"Исключение {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetSelectedFields()
        {
            List<string> fields = new List<string>();

            foreach (DataGridViewRow row in FieldsDataGrid.Rows)
            {
                if (row.Cells["Table"].Value != null && row.Cells["Column"].Value != null)
                {
                    string russianTable = row.Cells["Table"].Value.ToString();
                    string field = row.Cells["Column"].Value.ToString();
                    string englishTable = DB.GetEnglishTableName(russianTable);
                    string englishField = DB.GetEnglishColumnName(field);
                    switch (englishTable) 
                    {
                        case "Trips":
                        case "IMNS_Dispatcher":
                        case "Dispatcher_Carrier":
                        case "Carrier_Car":
                            {
                                fields.Add($"{englishTable}_View.{englishField}");
                                break;
                            }
                        default:
                            {
                                fields.Add($"{englishTable}.{englishField}");
                                break;
                            }
                    }
                }
            }

            return fields;
        }

        private List<string> GetConditions()
        {
            List<string> conditions = new List<string>();

            foreach (DataGridViewRow row in FieldsDataGrid.Rows)
            {
                if (row.Cells["Condition"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["Condition"].Value.ToString()))
                {
                    string russianTable = row.Cells["Table"].Value.ToString();
                    string field = row.Cells["Column"].Value.ToString();
                    string englishTable = DB.GetEnglishTableName(russianTable);
                    string englishField = DB.GetEnglishColumnName(field);
                    string condition = FormatCondition(englishTable, englishField, row.Cells["Condition"].Value.ToString());
                    if (condition == null)
                    {
                        return null;
                    }
                    else
                    {
                        conditions.Add(condition);
                    }
                }
            }

            return conditions;
        }

        private string FormatCondition(string table, string field, string condition)
        {
            switch (field)
            {
                case "imns_code":
                case "dispatcher_unp":
                case "carrier_unp":
                case "ur_ip":
                case "order_total":
                case "es_order_count":
                    {
                        string patternForInt = @"^(=|!=|>|<|>=|<=)\s*\d+$";
                        if (Regex.IsMatch(condition, patternForInt))
                        {
                            if (table == "Trips" || table == "IMNS_Dispatcher" || table == "Dispatcher_Carrier" || table == "Carrier_Car")
                            {
                                return $"{table}_View.{field} {condition}";
                            }
                            return $"{table}.{field} {condition}";
                        }
                        else
                        {
                            MessageBox.Show($"Введено неккоректное условие для {table}.{field}: {condition}. Условие должно быть следующего вида:{Environment.NewLine}- для строк используются знаки сравнения = (равно) либо != (не равно), условие заключается в кавычки, например: != \"Диспетчер №1\"{Environment.NewLine}- для чисел используются знаки сравнения: = (равно), != (не равно), > (больше), >= (больше либо равно), < (меньше), <= (меньше либо равно). После одного из знаков идет одно (1) целочисленное число. Пример: > 100{Environment.NewLine}Обратите внимание, что для одного поля можно задать ТОЛЬКО одно условие!", "Неккоректное условие", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return null;
                        }
                    }
                default:
                    {
                        string patternForString = @"^(=|!=)\s*""[^""]*""$";
                        if (Regex.IsMatch(condition, patternForString))
                        {
                            condition = condition.Replace("\"", "\'");
                            if (table == "Trips" || table == "IMNS_Dispatcher" || table == "Dispatcher_Carrier" || table == "Carrier_Car")
                            {
                                return $"{table}_View.{field} {condition}";
                            }

                            return $"{table}.{field} {condition}";
                        }
                        else
                        {
                            MessageBox.Show($"Введено неккоректное условие для {table}.{field}: {condition}. Условие должно быть следующего вида:{Environment.NewLine}- для строк: =\"условие\" либо !=\"условие\"{Environment.NewLine}- для чисел: =Числоб !=Число, >Число, <Число, >=Число, <=Число", "Неккоректное условие", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return null;
                        }
                    }
            }
        }

        private string CreateSqlQuery()
        {
            List<string> selectedFields = GetSelectedFields();
            List<string> conditions = GetConditions();
            if (selectedFields != null && conditions != null)
            {
                if (selectedFields.Count == 0)
                {
                    throw new InvalidOperationException("Не выбрано ни одного поля.");
                }

                var tables = selectedFields.Select(f => f.Split('.')[0]).Distinct();

                string query;
                if (tables.Count() > 1)
                {
                    var firstTable = tables.First();
                    var joinClauses = new List<string>();
                    var fromClause = $"{firstTable}";

                    foreach (var table in tables.Skip(1))
                    {
                        joinClauses.Add($"INNER JOIN {table} ON {firstTable}.id = {table}.id");
                    }

                    query = $"SELECT {string.Join(", ", selectedFields)} FROM {fromClause} {string.Join(" ", joinClauses)}";
                }
                else
                {
                    switch (tables.First())
                    {
                        case "Trips":
                        case "IMNS_Dispatcher":
                        case "Dispatcher_Carrier":
                        case "Carrier_Car":
                            {
                                query = $"SELECT {string.Join(", ", selectedFields)} FROM {tables.First()}_View";
                                break;
                            }
                        default:
                            {
                                query = $"SELECT {string.Join(", ", selectedFields)} FROM {tables.First()}";
                                break;
                            }
                    }
                }

                if (conditions.Count > 0)
                {
                    query += $" WHERE {string.Join(" AND ", conditions)}";
                }
                return query;
            }
            return "";
        }

        private DataTable ExecuteSqlQuery(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(database.Connection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private void DisplayResults(DataTable dataTable)
        {
            OnViewTableCreated?.Invoke(dataTable);
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
