using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Предоставляет работы с базой данных.
    /// </summary>
    public class DB
    {
        /// <summary>
        /// Получает или задает строку подключения к базе данных.
        /// </summary>
        /// <returns>Строка подключения.</returns>
        public string Connection { get; set; }

        /// <summary>
        /// Получает или задает имя сервера.
        /// </summary>
        /// <returns>Имя сервера.</returns>
        public string Server { get; set; }

        /// <summary>
        /// Получает или задает имя базы данных.
        /// </summary>
        /// <returns>Имя базы данных.</returns>
        public string Database { get; set; }

        /// <summary>
        /// Конструктор класса <see cref="DB"/>. Инициализирует новый экземляр класса <see cref="DB"/> после получения имени сервера и базы данных.
        /// </summary>
        /// <param name="server">Имя сервера</param>
        /// <param name="database">Имя базы данных</param>
        public DB(string server, string database)
        {
            Server = server;
            Database = database;
            Connection = GetConnectStr(server, database);
        }

        /// <summary>
        /// Формирует строку подключения по имени сервера server и базы данных db.
        /// </summary>
        /// <param name="server">Имя сервера</param>
        /// <param name="database">Имя базы данных</param>
        /// <returns>Строка подключения с именем сервера и базы данных.</returns>
        public string GetConnectStr(string server, string database)
        {
            return $"Data Source={server};Initial Catalog={database};Integrated Security=True";
        }

        public static Dictionary<string, string> TableTranslations = new Dictionary<string, string>
        {
            { "ИМНС", "IMNS" },
            { "Диспетчеры", "Dispatcher" }, 
            { "Перевозчики", "Carrier" },
            { "Авто", "Car" },
            { "Поездки", "Trips" },
            { "ИМНС и Диспетчеры", "IMNS_Dispatcher" },
            { "Диспетчеры и Перевозчики", "Dispatcher_Carrier" },
            { "Перевозчики и Авто", "Carrier_Car" }
        };
        public static string GetEnglishTableName(string russianTableName)
        {
            if (TableTranslations.ContainsKey(russianTableName))
            {
                return TableTranslations[russianTableName];
            }
            return russianTableName; // Возвращаем русское название, если нет соответствия
        }

        public static string GetRussianTableName(string englishTableName)
        {
            foreach (var kvp in TableTranslations)
            {
                if (kvp.Value == englishTableName)
                {
                    return kvp.Key;
                }
            }
            return englishTableName; // Возвращаем английское название, если нет соответствия
        }


        // Создайте словарь для соответствия английских и русских названий
        public static Dictionary<string, string> ColumnTranslations = new Dictionary<string, string>
        {
                        { "imns_code", "Код ИМНС" },
                        { "imns_name", "Наим. ИМНС" },
                        { "dispatcher_name", "Наим. диспетчера" },
                        { "dispatcher_unp", "УНП диспетчера" },
                        { "carrier_name", "Наим. перевозчика" },
                        { "carrier_unp", "УНП перевозчика" },
                        { "ur_ip", "Юр.лицо/ИП" },
                        { "brand", "Модель авто" },
                        { "number_plate", "Гос. рег. знак" },
                        { "date_shift", "Дата смены" },
                        { "order_total", "Кол-во заказов, всего шт." },
                        { "es_order_count", "с исп. ЭИС, шт." },
                        { "es_name", "Наим. ЭИС" },
                        { "imns", "Код ИМНС" },
                        { "dispatcher", "УНП диспетчера" },
                        { "carrier", "УНП перевозчика" },
        };

        public static string GetRussianColumnName(string englishColumnName)
        {
            if (ColumnTranslations.ContainsKey(englishColumnName))
            {
                return ColumnTranslations[englishColumnName];
            }
            return englishColumnName; // Возвращаем английское название, если нет соответствия
        }

        public static string GetEnglishColumnName(string russianColumnName)
        {
            foreach (var kvp in ColumnTranslations)
            {
                if (kvp.Value == russianColumnName)
                    return kvp.Key;
            }
            return russianColumnName; // Возвращаем английское название, если нет соответствия
        }

        /// <summary>
        /// Получает названия таблиц в базе данных.
        /// </summary>
        /// <returns>Список названий таблиц <see cref="List{String}"/>, полученных в результате запроса.</returns>
        public List<string> GetTables()
        {
            string serverConnect = $"Data Source={Server};Integrated Security=True;";
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(serverConnect))
            {
                try
                {
                    connection.Open();
                    SqlCommand tablesCommand = new SqlCommand($"USE {Database}; SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection);
                    SqlDataReader tablesReader = tablesCommand.ExecuteReader();
                    while (tablesReader.Read())
                    {
                        string tableName = tablesReader["TABLE_NAME"].ToString();
                        if (!tableName.Contains("sys"))
                        {
                            list.Add(tableName);
                        }
                    }

                    tablesReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошлв ошибка при получении таблиц: {ex.Message}", $"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return list;
            }
        }

        public bool Insert(object obj)
        {
            string query;
            switch (obj.GetType().ToString())
            {
                case "WindowsFormsApp1.Trips":
                    {
                        try
                        {
                            Trips x = obj as Trips;
                            query = "INSERT INTO Trips VALUES (@date_shift, @imns_dispatcher, @dispatcher_carrier, @carrier_car, @order_total, @es_order_count, @es_name)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@date_shift", x.Date_shift);
                                IMNS_Dispatcher imns_disp = GetAllIMNSDispatcher().First(y => y.Imns.Imns_code == x.IMNS.Imns_code && y.Dispatcher.Dispatcher_unp == x.Dispatcher.Dispatcher_unp);
                                if (imns_disp != null)
                                {
                                    command.Parameters.AddWithValue("@imns_dispatcher", imns_disp.Id);
                                    Dispatcher_Carrier disp_carr = GetAllDispatcherCarrier().First(y => y.Dispatcher.Dispatcher_unp == x.Dispatcher.Dispatcher_unp);
                                    if (disp_carr != null)
                                    {
                                        command.Parameters.AddWithValue("@dispatcher_carrier", disp_carr.Id);
                                        Carrier_Car carr_car = GetAllCarrierCar().Find(y => y.Carrier.Carrier_unp == x.Carrier.Carrier_unp && y.Car.Id == x.Car.Id);
                                        if (carr_car != null)
                                        {
                                            command.Parameters.AddWithValue("@carrier_car", carr_car.Id);
                                            command.Parameters.AddWithValue("@order_total", x.Order_total);
                                            command.Parameters.AddWithValue("@es_order_count", x.Es_order_count);
                                            command.Parameters.AddWithValue("@es_name", x.Es_name);
                                            int result = command.ExecuteNonQuery();
                                            if (result > 0)
                                                return true;
                                            else
                                                return false;
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Отношение между {carr_car.Carrier.Carrier_name} и {carr_car.Car.Brand} {carr_car.Car.Number_plate} не найдено. Добавьте его на окне добавления новой записи", "Отношение не найдено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Отношение между {disp_carr.Dispatcher.Dispatcher_name} и {disp_carr.Carrier.Carrier_name} не найдено. Добавьте его на окне добавления новой записи", "Отношение не найдено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Отношение между {imns_disp.Imns.Imns_name} и {imns_disp.Dispatcher.Dispatcher_name} не найдено. Добавьте его на окне добавления новой записи", "Отношение не найдено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return false;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить запись в таблицу \"Поездки\". Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Dispatcher":
                    {
                        try
                        {
                            Dispatcher d = obj as Dispatcher;
                            query = "INSERT INTO Dispatcher VALUES (@dispatcher_unp, @dispatcher_name)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@dispatcher_unp", Convert.ToInt32(d.Dispatcher_unp));
                                command.Parameters.AddWithValue("@dispatcher_name", d.Dispatcher_name);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить Диспетчера. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Carrier":
                    {
                        try
                        {
                            Carrier c = obj as Carrier;
                            query = "INSERT INTO Carrier VALUES (@carrier_unp, @carrier_name, @ur_ip)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@carrier_unp", Convert.ToInt32(c.Carrier_unp));
                                command.Parameters.AddWithValue("@carrier_name", c.Carrier_name);
                                command.Parameters.AddWithValue("@ur_ip", c.Ur_ip);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить Перевозчика. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Car":
                    {
                        try
                        {
                            Car c = obj as Car;
                            query = "INSERT INTO Car VALUES (@brand, @number_plate)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@brand", c.Brand);
                                command.Parameters.AddWithValue("@number_plate", c.Number_plate);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить Авто. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.IMNS":
                    {
                        try
                        {
                            IMNS i = obj as IMNS;
                            query = "INSERT INTO IMNS VALUES (@imns_code, @imns_name)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@imns_code", Convert.ToInt32(i.Imns_code));
                                command.Parameters.AddWithValue("@imns_name", i.Imns_name);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить ИМНС. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.IMNS_Dispatcher":
                    {
                        try
                        {
                            IMNS_Dispatcher i = obj as IMNS_Dispatcher;
                            query = "INSERT INTO IMNS_Dispatcher VALUES (@imns_code, @dispatcher_unp)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@imns_code", Convert.ToInt32(i.Imns.Imns_code));
                                command.Parameters.AddWithValue("@dispatcher_unp", Convert.ToInt32(i.Dispatcher.Dispatcher_unp));
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить отношение ИМНС и Диспетчера. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Dispatcher_Carrier":
                    {
                        try
                        {
                            Dispatcher_Carrier dc = obj as Dispatcher_Carrier;
                            query = "INSERT INTO Dispatcher_Carrier VALUES (@dispatcher_unp, @carrier_unp)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@dispatcher_unp", Convert.ToInt32(dc.Dispatcher.Dispatcher_unp));
                                command.Parameters.AddWithValue("@carrier_unp", Convert.ToInt32(dc.Carrier.Carrier_unp));
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить отношение Диспетчера и Перевозчика. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Carrier_Car":
                    {
                        try
                        {
                            Carrier_Car cc = obj as Carrier_Car;
                            query = "INSERT INTO Carrier_Car VALUES (@carrier_unp, @car_id)";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@carrier_unp", Convert.ToInt32(cc.Carrier.Carrier_unp));
                                command.Parameters.AddWithValue("@car_id", Convert.ToInt32(cc.Car.Id));
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось добавить отношение Перевозчика и Авто. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                default:
                    {
                        MessageBox.Show($"Для объекта типа данных {obj.GetType()} не определен функционал. Действие, которое Вы выбрали не может быть выполнено.", $"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
            }
        }

        public bool Update(object obj)
        {
            string query;
            switch (obj.GetType().ToString())
            {
                case "WindowsFormsApp1.Trips":
                    {
                        try
                        {
                            Trips x = obj as Trips;
                            query = "UPDATE Trips SET date_shift = @date_shift, order_total = @order_total, es_order_count = @es_order_count, es_name = @es_name, imns_dispatcher = @idi, dispatcher_carrier = @dci, carrier_car = @cci WHERE id = @id";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@date_shift", x.Date_shift);
                                IMNS_Dispatcher imns_disp = GetAllIMNSDispatcher().First(y => y.Imns.Imns_code == x.IMNS.Imns_code && y.Dispatcher.Dispatcher_unp == x.Dispatcher.Dispatcher_unp);
                                Dispatcher_Carrier disp_carr = GetAllDispatcherCarrier().First(y => y.Dispatcher.Dispatcher_unp == x.Dispatcher.Dispatcher_unp);
                                Carrier_Car carr_car = GetAllCarrierCar().First(y => y.Carrier.Carrier_unp == x.Carrier.Carrier_unp && y.Car.Id == x.Car.Id);
                                command.Parameters.AddWithValue("@idi", imns_disp.Id);
                                command.Parameters.AddWithValue("@dci", disp_carr.Id);
                                command.Parameters.AddWithValue("@cci", carr_car.Id);
                                command.Parameters.AddWithValue("@order_total", x.Order_total);
                                command.Parameters.AddWithValue("@es_order_count", x.Es_order_count);
                                command.Parameters.AddWithValue("@es_name", x.Es_name);
                                command.Parameters.AddWithValue("@id", x.Id);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить запись \"Поездки\". Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Dispatcher":
                    {
                        try
                        {
                            Dispatcher d = obj as Dispatcher;
                            query = "UPDATE Dispatcher SET dispatcher_name = @dispatcher_name WHERE dispatcher_unp = @dispatcher_unp";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@dispatcher_unp", Convert.ToInt32(d.Dispatcher_unp));
                                command.Parameters.AddWithValue("@dispatcher_name", d.Dispatcher_name);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить Диспетчера. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Carrier":
                    {
                        try
                        {
                            Carrier c = obj as Carrier;
                            query = "UPDATE Carrier SET carrier_name = @carrier_name, ur_ip = @ur_ip WHERE carrier_unp = @carrier_unp";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@carrier_unp", Convert.ToInt32(c.Carrier_unp));
                                command.Parameters.AddWithValue("@carrier_name", c.Carrier_name);
                                command.Parameters.AddWithValue("@ur_ip", c.Ur_ip);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить Перевозчика. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Car":
                    {
                        try
                        {
                            Car c = obj as Car;
                            query = "UPDATE Car SET brand = @brand, number_plate = @number_plate WHERE id = @id";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@id", c.Id);
                                command.Parameters.AddWithValue("@brand", c.Brand);
                                command.Parameters.AddWithValue("@number_plate", c.Number_plate);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить Авто. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.IMNS":
                    {
                        try
                        {
                            IMNS i = obj as IMNS;
                            query = "UPDATE IMNS SET imns_name = @imns_name WHERE imns_code = @imns_code";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@imns_code", Convert.ToInt32(i.Imns_code));
                                command.Parameters.AddWithValue("@imns_name", i.Imns_name);
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить ИМНС. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.IMNS_Dispatcher":
                    {
                        try
                        {
                            IMNS_Dispatcher i = obj as IMNS_Dispatcher;
                            query = "UPDATE IMNS_Dispatcher SET imns = @imns, dispatcher = @dispatcher WHERE id = @id";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@id", i.Id);
                                command.Parameters.AddWithValue("@imns", Convert.ToInt32(i.Imns.Imns_code));
                                command.Parameters.AddWithValue("@dispatcher", Convert.ToInt32(i.Dispatcher.Dispatcher_unp));
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить отношение ИМНС и Диспетчера. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Dispatcher_Carrier":
                    {
                        try
                        {
                            Dispatcher_Carrier dc = obj as Dispatcher_Carrier;
                            query = "UPDATE Dispatcher_Carrier SET dispatcher = @dispatcher, carrier = @carrier WHERE id = @id";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@id", dc.Id);
                                command.Parameters.AddWithValue("@dispatcher", Convert.ToInt32(dc.Dispatcher.Dispatcher_unp));
                                command.Parameters.AddWithValue("@carrier", Convert.ToInt32(dc.Carrier.Carrier_unp));
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить отношение Диспетчера и Перевозчика. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Carrier_Car":
                    {
                        try
                        {
                            Carrier_Car cc = obj as Carrier_Car;
                            query = "UPDATE Carrier_Car SET carrier = @carrier, car = @car WHERE id = @id";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@id", cc.Id);
                                command.Parameters.AddWithValue("@carrier", Convert.ToInt32(cc.Carrier.Carrier_unp));
                                command.Parameters.AddWithValue("@car", Convert.ToInt32(cc.Car.Id));
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Не удалось обновить отношение Перевозчика и Авто. Причина: {ex.Message}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                default:
                    {
                        MessageBox.Show($"Для объекта типа данных {obj.GetType()} не определен функционал. Действие, которое Вы выбрали не может быть выполнено.", $"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
            }
        }

        public bool CheckExist(object obj)
        {
            string checkExist;
            switch (obj.GetType().ToString())
            {
                case "WindowsFormsApp1.Dispatcher":
                    {
                        try
                        {
                            Dispatcher d = obj as Dispatcher;
                            checkExist = "SELECT COUNT(*) FROM Dispatcher WHERE dispatcher_unp = @dispatcher_unp AND dispatcher_name = @dispatcher_name";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(checkExist, connection);
                                command.Parameters.AddWithValue("@dispatcher_unp", Convert.ToInt32(d.Dispatcher_unp));
                                command.Parameters.AddWithValue("@dispatcher_name", d.Dispatcher_name);
                                int result = (int)command.ExecuteScalar();
                                if (result != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось проверить на существование Диспетчера. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Carrier":
                    {
                        try
                        {
                            Carrier c = obj as Carrier;
                            checkExist = "SELECT COUNT(*) FROM Carrier WHERE carrier_unp = @carrier_unp AND carrier_name = @carrier_name AND ur_ip = @ur_ip";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(checkExist, connection);
                                command.Parameters.AddWithValue("@carrier_unp", Convert.ToInt32(c.Carrier_unp));
                                command.Parameters.AddWithValue("@carrier_name", c.Carrier_name);
                                command.Parameters.AddWithValue("@ur_ip", c.Ur_ip);
                                int result = (int)command.ExecuteScalar();
                                if (result != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось проверить на существование Перевозчика. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Car":
                    {
                        try
                        {
                            Car c = obj as Car;
                            checkExist = "SELECT COUNT(*) FROM Car WHERE brand = @brand AND number_plate = @number_plate";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(checkExist, connection);
                                command.Parameters.AddWithValue("@brand", c.Brand);
                                command.Parameters.AddWithValue("@number_plate", c.Number_plate);
                                int result = (int)command.ExecuteScalar();
                                if (result != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось проверить на существование Авто. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.IMNS":
                    {
                        try
                        {
                            IMNS i = obj as IMNS;
                            checkExist = "SELECT COUNT(*) FROM IMNS WHERE imns_code = @imns_code AND imns_name = @imns_name";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(checkExist, connection);
                                command.Parameters.AddWithValue("@imns_code", Convert.ToInt32(i.Imns_code));
                                command.Parameters.AddWithValue("@imns_name", i.Imns_name);
                                int result = (int)command.ExecuteScalar();
                                if (result != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось проверить на существование ИМНС. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.IMNS_Dispatcher":
                    {
                        try
                        {
                            IMNS_Dispatcher imnsDisp = obj as IMNS_Dispatcher;
                            checkExist = "SELECT COUNT(*) FROM IMNS_Dispatcher WHERE imns = @imns_code AND dispatcher = @dispatcher_unp";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(checkExist, connection);
                                command.Parameters.AddWithValue("@imns_code", Convert.ToInt32(imnsDisp.Imns.Imns_code));
                                command.Parameters.AddWithValue("@dispatcher_unp", Convert.ToInt32(imnsDisp.Dispatcher.Dispatcher_unp));
                                int result = (int)command.ExecuteScalar();
                                if (result != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось проверить на существование отношение ИМНС и Диспетчера. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Dispatcher_Carrier":
                    {
                        try
                        {
                            Dispatcher_Carrier dc = obj as Dispatcher_Carrier;
                            checkExist = "SELECT COUNT(*) FROM Dispatcher_Carrier WHERE dispatcher = @dispatcher_unp AND carrier = @carrier_unp";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(checkExist, connection);
                                command.Parameters.AddWithValue("@dispatcher_unp", Convert.ToInt32(dc.Dispatcher.Dispatcher_unp));
                                command.Parameters.AddWithValue("@carrier_unp", Convert.ToInt32(dc.Carrier.Carrier_unp));
                                int result = (int)command.ExecuteScalar();
                                if (result != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось проверить на существование отношение Диспетчера и Перевозчика. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                case "WindowsFormsApp1.Carrier_Car":
                    {
                        try
                        {
                            Carrier_Car cc = obj as Carrier_Car;
                            checkExist = "SELECT COUNT(*) FROM Carrier_Car WHERE carrier = @carrier_unp AND car = @car_id";
                            using (SqlConnection connection = new SqlConnection(Connection))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(checkExist, connection);
                                command.Parameters.AddWithValue("@carrier_unp", Convert.ToInt32(cc.Carrier.Carrier_unp));
                                command.Parameters.AddWithValue("@car_id", Convert.ToInt32(cc.Car.Id));
                                int result = (int)command.ExecuteScalar();
                                if (result != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось проверить на существование отношение Перевозчика и Авто. Причина: {ex.Message}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                default:
                    {
                        MessageBox.Show($"Для объекта типа данных {obj.GetType()} не определен функционал. Действие, которое Вы выбрали не может быть выполнено.", $"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
            }
        }

        /// <summary>
        /// Удаляет запись из таблицы table по названию столбца column и значению value.
        /// </summary>
        /// <param name="table">Название таблицы</param>
        /// <param name="column">Название столбца</param>
        /// <param name="value">Значение</param>
        /// <returns>Значение <see langword="true"/>, если строка успешно удалена, иначе - <see langword="false"/>.</returns>
        public bool DeleteValues(string table, string column, string value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection))
                {
                    connection.Open();
                    string deleteQuery = $"DELETE FROM {table} WHERE {column} = {value}";
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось удалить запись из таблицы {table}. {ex.Message}", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Возвращает таблицу <see cref="DataTable"/>, заполненную результатом запроса SELECT(*) для таблицы table.
        /// </summary>
        /// <param name="table">Название таблицы</param>
        /// <returns>Заполненная результатом запроса SELECT(*) таблица <see cref="DataTable"/>.</returns>
        public DataTable LoadDataFromTable(string table)
        {
            try
            {
                string query = $"SELECT * FROM {table}";
                using (SqlConnection connect = new SqlConnection(Connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Не удалось прочитать данные из таблицы {table}: {ex.Message}", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        /// <summary>
        /// Возвращает таблицу <see cref="DataTable"/>, заполненную результатом выполнения представления viewName.
        /// </summary>
        /// <param name="viewName">Название представления</param>
        /// <returns>Заполненная таблица <see cref="DataTable"/>.</returns>
        public DataTable LoadDataFromView(string viewName)
        {
            viewName = viewName.Insert(viewName.Length, "_View");
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection))
                {
                    connection.Open();
                    string selectQuery = $"SELECT * FROM {viewName}";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить данные из представления {viewName}: {ex.Message}", "Ошибка ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        ////////////////////////////////////////..............................................
        /// <summary>
        /// Возвращает ID по значению.
        /// </summary>
        /// <param name="table">Название таблицы</param>
        /// <param name="value">Значение</param>
        /// <returns>ID из таблицы table по значению value.</returns>
        public int GetPrimaryKeyByValue(string table, string pkColumn, string column, string value)
        {
            try
            {
                string query = $"SELECT {pkColumn} FROM {table} WHERE {column} = '{value}'";
                using (SqlConnection connect = new SqlConnection(Connection))
                {
                    connect.Open();
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                            return Convert.ToInt32(result);
                        else
                            return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", $"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        ////////////////////////////////////////..............................................
        /// <summary>
        /// Возвращает ID по значению.
        /// </summary>
        /// <param name="table">Название таблицы</param>
        /// <param name="value">Значение</param>
        /// <returns>ID из таблицы table по значению value.</returns>
        public object GetObjectByPrimaryKey(string table, string primaryColumn, int pk)
        {
            string query = $"SELECT * FROM {table} WHERE {primaryColumn} = {pk}";
            try
            {
                using (SqlConnection connect = new SqlConnection(Connection))
                {
                    connect.Open();
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            switch (table)
                            {
                                case "Trips":
                                    {
                                        var trip = new Trips()
                                        {
                                            Id = Convert.ToInt32(reader["id"]),
                                            Date_shift = reader["date_shift"].ToString(),
                                            Order_total = Convert.ToInt32(reader["order_total"]),
                                            Es_order_count = Convert.ToInt32(reader["es_order_count"]),
                                            Es_name = reader["es_name"].ToString(),
                                        };

                                        var imns_disp = GetObjectByPrimaryKey("IMNS_Dispatcher", "id", Convert.ToInt32(reader["imns_dispatcher"])) as IMNS_Dispatcher;
                                        var disp_carr = GetObjectByPrimaryKey("Dispatcher_Carrier", "id", Convert.ToInt32(reader["dispatcher_carrier"])) as Dispatcher_Carrier;
                                        var carr_car = GetObjectByPrimaryKey("Carrier_Car", "id", Convert.ToInt32(reader["carrier_car"])) as Carrier_Car;

                                        trip.IMNS = imns_disp.Imns;
                                        trip.Dispatcher = disp_carr.Dispatcher;
                                        trip.Carrier = carr_car.Carrier;
                                        trip.Car = carr_car.Car;
                                        return trip;
                                    }
                                case "Dispatcher":
                                    {
                                        var dispatch = new Dispatcher
                                        {
                                            Dispatcher_unp = reader["dispatcher_unp"].ToString(),
                                            Dispatcher_name = reader["dispatcher_name"].ToString()
                                        };
                                        return dispatch;
                                    }
                                case "Carrier":
                                    {
                                        var carrier = new Carrier
                                        {
                                            Carrier_unp = reader["carrier_unp"].ToString(),
                                            Carrier_name = reader["carrier_name"].ToString(),
                                            Ur_ip = Convert.ToBoolean(reader["ur_ip"].ToString())
                                        };
                                        return carrier;
                                    }
                                case "Car":
                                    {
                                        var car = new Car
                                        {
                                            Id = Convert.ToInt32(reader["id"]),
                                            Brand = reader["brand"].ToString(),
                                            Number_plate = reader["number_plate"].ToString()
                                        };
                                        return car;
                                    }
                                case "IMNS":
                                    {
                                        var imns = new IMNS
                                        {
                                            Imns_code = Convert.ToInt32(reader["imns_code"]),
                                            Imns_name = reader["imns_name"].ToString()
                                        };
                                        return imns;
                                    }
                                case "IMNS_Dispatcher":
                                    {
                                        var imns = new IMNS_Dispatcher
                                        {
                                            Id = Convert.ToInt32(reader["id"]),
                                            Imns = GetObjectByPrimaryKey("IMNS", "imns_code", Convert.ToInt32(reader["imns"])) as IMNS,
                                            Dispatcher = GetObjectByPrimaryKey("Dispatcher", "dispatcher_unp", Convert.ToInt32(reader["dispatcher"])) as Dispatcher
                                        };
                                        return imns;
                                    }
                                case "Dispatcher_Carrier":
                                    {
                                        var imns = new Dispatcher_Carrier
                                        {
                                            Id = Convert.ToInt32(reader["id"]),
                                            Carrier = GetObjectByPrimaryKey("Carrier", "carrier_unp", Convert.ToInt32(reader["carrier"])) as Carrier,
                                            Dispatcher = GetObjectByPrimaryKey("Dispatcher", "dispatcher_unp", Convert.ToInt32(reader["dispatcher"])) as Dispatcher
                                        };
                                        return imns;
                                    }
                                case "Carrier_Car":
                                    {
                                        var imns = new Carrier_Car
                                        {
                                            Id = Convert.ToInt32(reader["id"]),
                                            Carrier = GetObjectByPrimaryKey("Carrier", "carrier_unp", Convert.ToInt32(reader["carrier"])) as Carrier,
                                            Car = GetObjectByPrimaryKey("Car", "id", Convert.ToInt32(reader["car"])) as Car
                                        };
                                        return imns;
                                    }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",$"{ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return null;
        }

        public List<Dispatcher> GetAllDispatchers()
        {
            var allDispatch = new List<Dispatcher>();
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                string query = "SELECT * FROM Dispatcher";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var dispatch = new Dispatcher
                    {
                        Dispatcher_unp = reader["dispatcher_unp"].ToString(),
                        Dispatcher_name = reader["dispatcher_name"].ToString()
                    };
                    allDispatch.Add(dispatch);
                }
            }

            return allDispatch;
        }

        public List<Carrier> GetAllCarriers()
        {
            var allCarriers = new List<Carrier>();
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                string query = "SELECT * FROM Carrier";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var carrier = new Carrier
                    {
                        Carrier_unp = reader["carrier_unp"].ToString(),
                        Carrier_name = reader["carrier_name"].ToString(),
                        Ur_ip = Convert.ToBoolean(reader["ur_ip"])
                    };
                    allCarriers.Add(carrier);
                }
            }

            return allCarriers;
        }

        public List<Car> GetAllCars()
        {
            var allCars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                string query = "SELECT * FROM Car";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var car = new Car
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Brand = reader["brand"].ToString(),
                        Number_plate = reader["number_plate"].ToString()
                    };
                    allCars.Add(car);
                }
            }

            return allCars;
        }

        public List<IMNS> GetAllIMNS()
        {
            var allIMNS = new List<IMNS>();
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                string query = "SELECT * FROM IMNS";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var imns = new IMNS
                    {
                        Imns_code = Convert.ToInt32(reader["imns_code"]),
                        Imns_name = reader["imns_name"].ToString()
                    };
                    allIMNS.Add(imns);
                }
            }

            return allIMNS;
        }

        public List<Trips> GetAllTrips()
        {
            var allTrips = new List<Trips>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection))
                {
                    string query = "SELECT * FROM Trips";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        IMNS_Dispatcher imnsDisp = GetObjectByPrimaryKey("IMNS_Dispatcher", "id", Convert.ToInt32(reader["imns_dispatcher"])) as IMNS_Dispatcher;
                        Dispatcher_Carrier dispCarr = GetObjectByPrimaryKey("Dispatcher_Carrier", "id", Convert.ToInt32(reader["dispatcher_carrier"])) as Dispatcher_Carrier;
                        Carrier_Car carrCar = GetObjectByPrimaryKey("Carrier_Car", "id", Convert.ToInt32(reader["carrier_car"])) as Carrier_Car;
                        var trip = new Trips
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Date_shift = reader["date_shift"].ToString(),
                            IMNS = imnsDisp.Imns,
                            Dispatcher = dispCarr.Dispatcher,
                            Carrier = dispCarr.Carrier,
                            Car = carrCar.Car,
                            Order_total = Convert.ToInt32(reader["order_total"]),
                            Es_order_count = Convert.ToInt32(reader["es_order_count"]),
                            Es_name = reader["es_name"].ToString()
                        };
                        allTrips.Add(trip);
                    }
                }
                return allTrips;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<IMNS_Dispatcher> GetAllIMNSDispatcher()
        {
            var allIMNSDisp = new List<IMNS_Dispatcher>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection))
                {
                    string query = "SELECT * FROM IMNS_Dispatcher";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var imns_disp = new IMNS_Dispatcher();
                        IMNS imns = GetObjectByPrimaryKey("IMNS", "imns_code", Convert.ToInt32(reader["imns"])) as IMNS;
                        Dispatcher disp = GetObjectByPrimaryKey("Dispatcher", "dispatcher_unp", Convert.ToInt32(reader["dispatcher"])) as Dispatcher;
                        if (imns != null && disp != null)
                        {
                            imns_disp = new IMNS_Dispatcher
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Imns = imns,
                                Dispatcher = disp
                            };
                            allIMNSDisp.Add(imns_disp);
                        }
                        else
                            MessageBox.Show($"По какой-то причине не удалось найти экземпляры таблиц ИМНС и Диспетчера, которые записаны под id {imns_disp.Id}", "Ошибка чтения таблицы ИМНС и Диспетчеры", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    return allIMNSDisp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Dispatcher_Carrier> GetAllDispatcherCarrier()
        {
            var allDispCarr = new List<Dispatcher_Carrier>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection))
                {
                    string query = "SELECT * FROM Dispatcher_Carrier";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var disp_carr = new Dispatcher_Carrier();
                        Dispatcher disp = GetObjectByPrimaryKey("Dispatcher", "dispatcher_unp", Convert.ToInt32(reader["dispatcher"])) as Dispatcher;
                        Carrier carr = GetObjectByPrimaryKey("Carrier", "carrier_unp", Convert.ToInt32(reader["carrier"])) as Carrier;
                        if (carr != null && disp != null)
                        {
                            disp_carr = new Dispatcher_Carrier
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Dispatcher = disp,
                                Carrier = carr
                            };
                            allDispCarr.Add(disp_carr);
                        }
                        else
                            MessageBox.Show($"По какой-то причине не удалось найти экземпляры таблиц \"Диспетчеры\" и \"Перевозчики\", которые записаны под id {disp_carr.Id}", "Ошибка чтения таблицы \"Диспетчеры и Перевозчики\"", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                return allDispCarr;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Carrier_Car> GetAllCarrierCar()
        {
            var all = new List<Carrier_Car>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection))
                {
                    string query = "SELECT * FROM Carrier_Car";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var carr_car = new Carrier_Car();
                        Carrier carr = GetObjectByPrimaryKey("Carrier", "carrier_unp", Convert.ToInt32(reader["carrier"])) as Carrier;
                        Car car = GetObjectByPrimaryKey("Car", "id", Convert.ToInt32(reader["car"])) as Car;
                        if (carr != null && car != null)
                        {
                            carr_car = new Carrier_Car
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Carrier = carr,
                                Car = car
                            };
                            all.Add(carr_car);
                        }
                        else
                            MessageBox.Show($"По какой-то причине не удалось найти экземпляры таблиц \"Диспетчеры\" и \"Перевозчики\", которые записаны под id {carr_car.Id}", "Ошибка чтения таблицы \"Диспетчеры и Перевозчики\"", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                return all;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", $"Ошибка {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
