using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TableMenuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRowToDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveRowToDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRowFromDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportTableToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToExcelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InterruptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportAllToExcelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpProviderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabCloseContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прерватьСоединениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.установитьСоединениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToDBContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьВБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.IMNSButton = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.TableMenuContext.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.TabCloseContext.SuspendLayout();
            this.SaveToDBContext.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableMenuContext
            // 
            this.TableMenuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRowToDatabase,
            this.SaveRowToDatabase,
            this.DeleteRowFromDatabase,
            this.ExportTableToExcel});
            this.TableMenuContext.Name = "contextMenuStrip1";
            this.TableMenuContext.Size = new System.Drawing.Size(197, 92);
            // 
            // AddRowToDatabase
            // 
            this.AddRowToDatabase.BackColor = System.Drawing.Color.Black;
            this.AddRowToDatabase.ForeColor = System.Drawing.Color.White;
            this.AddRowToDatabase.Image = ((System.Drawing.Image)(resources.GetObject("AddRowToDatabase.Image")));
            this.AddRowToDatabase.Name = "AddRowToDatabase";
            this.AddRowToDatabase.Size = new System.Drawing.Size(196, 22);
            this.AddRowToDatabase.Text = "Добавить";
            // 
            // SaveRowToDatabase
            // 
            this.SaveRowToDatabase.BackColor = System.Drawing.Color.Black;
            this.SaveRowToDatabase.ForeColor = System.Drawing.Color.White;
            this.SaveRowToDatabase.Image = global::WindowsFormsApp1.Properties.Resources.save_ico;
            this.SaveRowToDatabase.Name = "SaveRowToDatabase";
            this.SaveRowToDatabase.Size = new System.Drawing.Size(196, 22);
            this.SaveRowToDatabase.Text = "Сохранить изменения";
            // 
            // DeleteRowFromDatabase
            // 
            this.DeleteRowFromDatabase.BackColor = System.Drawing.Color.Black;
            this.DeleteRowFromDatabase.ForeColor = System.Drawing.Color.White;
            this.DeleteRowFromDatabase.Image = ((System.Drawing.Image)(resources.GetObject("DeleteRowFromDatabase.Image")));
            this.DeleteRowFromDatabase.Name = "DeleteRowFromDatabase";
            this.DeleteRowFromDatabase.Size = new System.Drawing.Size(196, 22);
            this.DeleteRowFromDatabase.Text = "Удалить";
            this.DeleteRowFromDatabase.Click += new System.EventHandler(this.DeleteRows_Click);
            // 
            // ExportTableToExcel
            // 
            this.ExportTableToExcel.BackColor = System.Drawing.Color.Black;
            this.ExportTableToExcel.ForeColor = System.Drawing.Color.White;
            this.ExportTableToExcel.Image = ((System.Drawing.Image)(resources.GetObject("ExportTableToExcel.Image")));
            this.ExportTableToExcel.Name = "ExportTableToExcel";
            this.ExportTableToExcel.Size = new System.Drawing.Size(196, 22);
            this.ExportTableToExcel.Text = "Экспорт в Excel";
            this.ExportTableToExcel.Click += new System.EventHandler(this.ExportTableToExcel_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.MainMenu.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainMenu.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.DatabaseMenuItem,
            this.ConvertMenuItem,
            this.HelpMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1287, 36);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.FileMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileMenuItem,
            this.ExportToExcelMenuItem});
            this.FileMenuItem.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileMenuItem.ForeColor = System.Drawing.Color.Black;
            this.FileMenuItem.MergeIndex = 0;
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(67, 32);
            this.FileMenuItem.Text = "Файл";
            // 
            // OpenFileMenuItem
            // 
            this.OpenFileMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.OpenFileMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.OpenFileMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenFileMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.OpenFileMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OpenFileMenuItem.Name = "OpenFileMenuItem";
            this.OpenFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFileMenuItem.Size = new System.Drawing.Size(295, 32);
            this.OpenFileMenuItem.Text = "Открыть";
            this.OpenFileMenuItem.Click += new System.EventHandler(this.OpenXML_Click);
            // 
            // ExportToExcelMenuItem
            // 
            this.ExportToExcelMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ExportToExcelMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.ExportToExcelMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExportToExcelMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.ExportToExcelMenuItem.Name = "ExportToExcelMenuItem";
            this.ExportToExcelMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ExportToExcelMenuItem.Size = new System.Drawing.Size(295, 32);
            this.ExportToExcelMenuItem.Text = "Экспорт в Excel";
            this.ExportToExcelMenuItem.Click += new System.EventHandler(this.ExportTableToExcel_Click);
            // 
            // DatabaseMenuItem
            // 
            this.DatabaseMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DatabaseMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectMenuItem,
            this.InterruptMenuItem,
            this.CreateViewMenuItem,
            this.ExportAllToExcelMenuItem});
            this.DatabaseMenuItem.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DatabaseMenuItem.ForeColor = System.Drawing.Color.Black;
            this.DatabaseMenuItem.MergeIndex = 0;
            this.DatabaseMenuItem.Name = "DatabaseMenuItem";
            this.DatabaseMenuItem.Size = new System.Drawing.Size(120, 32);
            this.DatabaseMenuItem.Text = "База данных";
            // 
            // ConnectMenuItem
            // 
            this.ConnectMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ConnectMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.ConnectMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.ConnectMenuItem.Name = "ConnectMenuItem";
            this.ConnectMenuItem.Size = new System.Drawing.Size(315, 30);
            this.ConnectMenuItem.Text = "Подключиться";
            this.ConnectMenuItem.Click += new System.EventHandler(this.OpenConnection_Click);
            // 
            // InterruptMenuItem
            // 
            this.InterruptMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.InterruptMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.InterruptMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InterruptMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.InterruptMenuItem.Name = "InterruptMenuItem";
            this.InterruptMenuItem.Size = new System.Drawing.Size(315, 30);
            this.InterruptMenuItem.Text = "Прервать";
            this.InterruptMenuItem.Click += new System.EventHandler(this.InterruptConnection_Click);
            // 
            // CreateViewMenuItem
            // 
            this.CreateViewMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.CreateViewMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.CreateViewMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateViewMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.CreateViewMenuItem.Name = "CreateViewMenuItem";
            this.CreateViewMenuItem.Size = new System.Drawing.Size(315, 30);
            this.CreateViewMenuItem.Text = "Конструктор отчета";
            this.CreateViewMenuItem.Click += new System.EventHandler(this.CreateViewMenuItem_Click);
            // 
            // ExportAllToExcelMenuItem
            // 
            this.ExportAllToExcelMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ExportAllToExcelMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.ExportAllToExcelMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExportAllToExcelMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.ExportAllToExcelMenuItem.Name = "ExportAllToExcelMenuItem";
            this.ExportAllToExcelMenuItem.Size = new System.Drawing.Size(315, 30);
            this.ExportAllToExcelMenuItem.Text = "Экспорт всех таблиц в Excel";
            this.ExportAllToExcelMenuItem.Click += new System.EventHandler(this.ExportAllTablesToExcel_Click);
            // 
            // ConvertMenuItem
            // 
            this.ConvertMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ConvertMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConvertMenuItem.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConvertMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ConvertMenuItem.Name = "ConvertMenuItem";
            this.ConvertMenuItem.Size = new System.Drawing.Size(146, 32);
            this.ConvertMenuItem.Text = "Преобразование";
            this.ConvertMenuItem.Click += new System.EventHandler(this.ConvertFormOpen_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.HelpMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpProviderMenuItem,
            this.AboutMenuItem});
            this.HelpMenuItem.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpMenuItem.ForeColor = System.Drawing.Color.Black;
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(89, 32);
            this.HelpMenuItem.Text = "Справка";
            // 
            // HelpProviderMenuItem
            // 
            this.HelpProviderMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.HelpProviderMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.HelpProviderMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpProviderMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.HelpProviderMenuItem.Name = "HelpProviderMenuItem";
            this.HelpProviderMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.HelpProviderMenuItem.Size = new System.Drawing.Size(230, 30);
            this.HelpProviderMenuItem.Text = "Справка";
            this.HelpProviderMenuItem.Click += new System.EventHandler(this.HelpProviderMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.AboutMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.AboutMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AboutMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(230, 30);
            this.AboutMenuItem.Text = "О программе";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutProgram_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(273, 53);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1002, 572);
            this.tabControl.TabIndex = 9;
            this.tabControl.Visible = false;
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseRightClick_OnTab);
            // 
            // TabCloseContext
            // 
            this.TabCloseContext.BackColor = System.Drawing.Color.Transparent;
            this.TabCloseContext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabCloseContext.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TabCloseContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseTabMenuItem});
            this.TabCloseContext.Name = "TabContextMenu";
            this.TabCloseContext.Size = new System.Drawing.Size(228, 58);
            // 
            // CloseTabMenuItem
            // 
            this.CloseTabMenuItem.BackColor = System.Drawing.Color.Black;
            this.CloseTabMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.CloseTabMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseTabMenuItem.ForeColor = System.Drawing.Color.Black;
            this.CloseTabMenuItem.MergeIndex = 0;
            this.CloseTabMenuItem.Name = "CloseTabMenuItem";
            this.CloseTabMenuItem.Size = new System.Drawing.Size(227, 32);
            this.CloseTabMenuItem.Text = "Закрыть вкладку";
            this.CloseTabMenuItem.Click += new System.EventHandler(this.CloseTab_Click);
            // 
            // прерватьСоединениеToolStripMenuItem
            // 
            this.прерватьСоединениеToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(134)))), ((int)(((byte)(229)))));
            this.прерватьСоединениеToolStripMenuItem.Name = "прерватьСоединениеToolStripMenuItem";
            this.прерватьСоединениеToolStripMenuItem.Size = new System.Drawing.Size(152, 21);
            this.прерватьСоединениеToolStripMenuItem.Text = "Прервать соединение";
            this.прерватьСоединениеToolStripMenuItem.Click += new System.EventHandler(this.InterruptConnection_Click);
            // 
            // установитьСоединениеToolStripMenuItem
            // 
            this.установитьСоединениеToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(28)))), ((int)(((byte)(54)))));
            this.установитьСоединениеToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(134)))), ((int)(((byte)(229)))));
            this.установитьСоединениеToolStripMenuItem.Name = "установитьСоединениеToolStripMenuItem";
            this.установитьСоединениеToolStripMenuItem.Size = new System.Drawing.Size(160, 21);
            this.установитьСоединениеToolStripMenuItem.Text = "Установить соединение";
            this.установитьСоединениеToolStripMenuItem.Click += new System.EventHandler(this.OpenConnection_Click);
            // 
            // SaveToDBContext
            // 
            this.SaveToDBContext.BackColor = System.Drawing.SystemColors.Control;
            this.SaveToDBContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВБДToolStripMenuItem});
            this.SaveToDBContext.Name = "contextMenuStrip1";
            this.SaveToDBContext.Size = new System.Drawing.Size(288, 36);
            // 
            // добавитьВБДToolStripMenuItem
            // 
            this.добавитьВБДToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.добавитьВБДToolStripMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.добавитьВБДToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.добавитьВБДToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.добавитьВБДToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.добавитьВБДToolStripMenuItem.Name = "добавитьВБДToolStripMenuItem";
            this.добавитьВБДToolStripMenuItem.Size = new System.Drawing.Size(287, 32);
            this.добавитьВБДToolStripMenuItem.Text = "Сохранить в базу данных";
            this.добавитьВБДToolStripMenuItem.Click += new System.EventHandler(this.SaveFromFileToDB_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel.Controls.Add(this.button2);
            this.panel.Controls.Add(this.button7);
            this.panel.Controls.Add(this.button6);
            this.panel.Controls.Add(this.button5);
            this.panel.Controls.Add(this.button4);
            this.panel.Controls.Add(this.button3);
            this.panel.Controls.Add(this.button1);
            this.panel.Controls.Add(this.IMNSButton);
            this.panel.Location = new System.Drawing.Point(0, 53);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(271, 572);
            this.panel.TabIndex = 36;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.button2.Location = new System.Drawing.Point(18, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 46);
            this.button2.TabIndex = 0;
            this.button2.Text = "Поездки";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.button7.Location = new System.Drawing.Point(17, 367);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(238, 46);
            this.button7.TabIndex = 0;
            this.button7.Text = "Перевозчики и Авто";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.button6.Location = new System.Drawing.Point(12, 315);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(253, 46);
            this.button6.TabIndex = 0;
            this.button6.Text = "Диспетчеры и Перевозчики";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.button5.Location = new System.Drawing.Point(18, 263);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(237, 46);
            this.button5.TabIndex = 0;
            this.button5.Text = "ИМНС и Диспетчеры";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.button4.Location = new System.Drawing.Point(18, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(237, 46);
            this.button4.TabIndex = 0;
            this.button4.Text = "ИМНС";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.button3.Location = new System.Drawing.Point(18, 159);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(237, 46);
            this.button3.TabIndex = 0;
            this.button3.Text = "Авто";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.button1.Location = new System.Drawing.Point(18, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Перевозчики";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // IMNSButton
            // 
            this.IMNSButton.BackColor = System.Drawing.Color.Transparent;
            this.IMNSButton.FlatAppearance.BorderSize = 0;
            this.IMNSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IMNSButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IMNSButton.ForeColor = System.Drawing.Color.White;
            this.IMNSButton.Image = global::WindowsFormsApp1.Properties.Resources.long_button;
            this.IMNSButton.Location = new System.Drawing.Point(18, 55);
            this.IMNSButton.Name = "IMNSButton";
            this.IMNSButton.Size = new System.Drawing.Size(237, 46);
            this.IMNSButton.TabIndex = 0;
            this.IMNSButton.Text = "Диспетчеры";
            this.IMNSButton.UseVisualStyleBackColor = false;
            this.IMNSButton.Click += new System.EventHandler(this.OpenTabPage);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\krwinwx\\Desktop\\XML Convert\\WindowsFormsApp1\\bin\\Debug\\help.chm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.FhkHbDaaEAAwT3K;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1287, 637);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " XML Convert v.1.0.3";
            this.TableMenuContext.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TabCloseContext.ResumeLayout(false);
            this.SaveToDBContext.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem DatabaseMenuItem;
        private ToolStripMenuItem FileMenuItem;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem OpenFileMenuItem;
        private ContextMenuStrip TableMenuContext;
        private ToolStripMenuItem DeleteRowFromDatabase;
        private ToolStripMenuItem SaveRowToDatabase;
        private ToolStripMenuItem ExportToExcelMenuItem;
        private TabControl tabControl;
        private ContextMenuStrip TabCloseContext;
        private ToolStripMenuItem CloseTabMenuItem;
        private ToolStripMenuItem ConnectMenuItem;
        private ToolStripMenuItem InterruptMenuItem;
        private ToolStripMenuItem прерватьСоединениеToolStripMenuItem;
        private ToolStripMenuItem установитьСоединениеToolStripMenuItem;
        private ToolStripMenuItem CreateViewMenuItem;
        private ToolStripMenuItem ExportTableToExcel;
        private ToolStripMenuItem AddRowToDatabase;
        private ContextMenuStrip SaveToDBContext;
        private ToolStripMenuItem добавитьВБДToolStripMenuItem;
        private ToolStripMenuItem ConvertMenuItem;
        private ToolStripMenuItem HelpMenuItem;
        private ToolStripMenuItem ExportAllToExcelMenuItem;
        private ToolStripMenuItem HelpProviderMenuItem;
        private ToolStripMenuItem AboutMenuItem;
        private Panel panel;
        private Button IMNSButton;
        private HelpProvider helpProvider1;
        private Button button2;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button1;
    }
}

