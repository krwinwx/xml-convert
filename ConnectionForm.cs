using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ConnectionForm : Form
    {
        public event Action<string, string> ConnectionInfoProvided;

        public ConnectionForm()
        {
            InitializeComponent();
            ServerNameTextBox.Text = Environment.MachineName + "\\SQLEXPRESS";
        }

        /// <summary>
        /// Подключается к серверу и выводит в выпадающий список названия найденных баз данных.
        /// </summary>
        private void Connect_Click(object sender, EventArgs e)
        {
            string serverName = ServerNameTextBox.Text.Trim();
            string connectionString = $"Data Source={serverName};Integrated Security=True;";

            DatabaseComboBox.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand databasesCommand = new SqlCommand("SELECT name FROM sys.databases", connection);
                    SqlDataReader databaseReader = databasesCommand.ExecuteReader();

                    while (databaseReader.Read())
                    {
                        string databaseName = databaseReader["name"].ToString();
                        DatabaseComboBox.Items.Add(databaseName);
                        if (databaseName.Contains("taxi"))
                        {
                            DatabaseComboBox.SelectedItem = databaseName;
                        }
                    }
                    databaseReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось подключиться к серверу: {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChooseDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                string serverName = ServerNameTextBox.Text.Trim();
                string selectedDatabase = DatabaseComboBox.SelectedItem.ToString();
                ConnectionInfoProvided?.Invoke(serverName, selectedDatabase);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ChangeConnectionString(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ServerNameTextBox.Enabled = true;
            }
            else
            {
                ServerNameTextBox.Enabled = false;
            }
        }
    }
}
