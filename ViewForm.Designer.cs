namespace WindowsFormsApp1
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Код ИМНС");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Наим. ИМНС");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ИМНС", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("УНП диспетчера");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Наим. диспетчера");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Диспетчеры", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("УНП перевозчика");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Наим. перевозчика");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Юр.лицо/ИП");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Перевозчики", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Модель авто");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Гос. рег. знак");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Авто", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Дата смены");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Наим. ИМНС");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Наим. диспетчера");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Наим. перевозчика");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Модель авто");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Гос. рег. знак");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Кол-во заказов, всего шт.");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("с исп. ЭИС, шт.");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Наим. ЭИС");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Поездки", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.TablesTreeView = new System.Windows.Forms.TreeView();
            this.FieldsDataGrid = new System.Windows.Forms.DataGridView();
            this.Table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateNewViewButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpProviderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.FieldsDataGrid)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablesTreeView
            // 
            this.TablesTreeView.BackColor = System.Drawing.Color.LavenderBlush;
            this.TablesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TablesTreeView.CheckBoxes = true;
            this.TablesTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TablesTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TablesTreeView.HideSelection = false;
            this.TablesTreeView.Indent = 20;
            this.TablesTreeView.LineColor = System.Drawing.Color.DodgerBlue;
            this.TablesTreeView.Location = new System.Drawing.Point(12, 38);
            this.TablesTreeView.Name = "TablesTreeView";
            treeNode1.Name = "imns_code";
            treeNode1.Text = "Код ИМНС";
            treeNode2.Name = "imns_name";
            treeNode2.Text = "Наим. ИМНС";
            treeNode3.ForeColor = System.Drawing.Color.Blue;
            treeNode3.Name = "IMNS";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode3.Text = "ИМНС";
            treeNode4.Name = "dispatcher_unp";
            treeNode4.Text = "УНП диспетчера";
            treeNode5.Name = "dispatcher_name";
            treeNode5.Text = "Наим. диспетчера";
            treeNode6.ForeColor = System.Drawing.Color.Blue;
            treeNode6.Name = "Dispatcher";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode6.Text = "Диспетчеры";
            treeNode7.Name = "carrier_unp";
            treeNode7.Text = "УНП перевозчика";
            treeNode8.Name = "carrier_name";
            treeNode8.Text = "Наим. перевозчика";
            treeNode9.Name = "ur_ip";
            treeNode9.Text = "Юр.лицо/ИП";
            treeNode10.ForeColor = System.Drawing.Color.Blue;
            treeNode10.Name = "Carrier";
            treeNode10.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode10.Text = "Перевозчики";
            treeNode11.Name = "brand";
            treeNode11.Text = "Модель авто";
            treeNode12.Name = "number_plate";
            treeNode12.Text = "Гос. рег. знак";
            treeNode13.ForeColor = System.Drawing.Color.Blue;
            treeNode13.Name = "Car";
            treeNode13.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode13.Text = "Авто";
            treeNode14.Name = "date_shift";
            treeNode14.Text = "Дата смены";
            treeNode15.Name = "imns_name";
            treeNode15.Text = "Наим. ИМНС";
            treeNode16.Name = "dispatcher_name";
            treeNode16.Text = "Наим. диспетчера";
            treeNode17.Name = "carrier_name";
            treeNode17.Text = "Наим. перевозчика";
            treeNode18.Name = "brand";
            treeNode18.Text = "Модель авто";
            treeNode19.Name = "number_plate";
            treeNode19.Text = "Гос. рег. знак";
            treeNode20.Name = "order_total";
            treeNode20.Text = "Кол-во заказов, всего шт.";
            treeNode21.Name = "es_order_count";
            treeNode21.Text = "с исп. ЭИС, шт.";
            treeNode22.Name = "es_name";
            treeNode22.Text = "Наим. ЭИС";
            treeNode23.ForeColor = System.Drawing.Color.Blue;
            treeNode23.Name = "Trips";
            treeNode23.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode23.Text = "Поездки";
            this.TablesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode10,
            treeNode13,
            treeNode23});
            this.TablesTreeView.Size = new System.Drawing.Size(239, 516);
            this.TablesTreeView.TabIndex = 0;
            this.TablesTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TablesTreeView_AfterCheck);
            // 
            // FieldsDataGrid
            // 
            this.FieldsDataGrid.AllowUserToAddRows = false;
            this.FieldsDataGrid.AllowUserToResizeRows = false;
            this.FieldsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FieldsDataGrid.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.FieldsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(118)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FieldsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FieldsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Table,
            this.Column,
            this.Condition});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(118)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldsDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.FieldsDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.FieldsDataGrid.Location = new System.Drawing.Point(262, 38);
            this.FieldsDataGrid.Name = "FieldsDataGrid";
            this.FieldsDataGrid.Size = new System.Drawing.Size(676, 516);
            this.FieldsDataGrid.TabIndex = 3;
            // 
            // Table
            // 
            this.Table.HeaderText = "Таблица";
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column
            // 
            this.Column.HeaderText = "Поле";
            this.Column.Name = "Column";
            this.Column.ReadOnly = true;
            this.Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Condition
            // 
            this.Condition.HeaderText = "Условие";
            this.Condition.Name = "Condition";
            this.Condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CreateNewViewButton
            // 
            this.CreateNewViewButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateNewViewButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.button;
            this.CreateNewViewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateNewViewButton.FlatAppearance.BorderSize = 0;
            this.CreateNewViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateNewViewButton.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewViewButton.ForeColor = System.Drawing.Color.White;
            this.CreateNewViewButton.Location = new System.Drawing.Point(756, 561);
            this.CreateNewViewButton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateNewViewButton.Name = "CreateNewViewButton";
            this.CreateNewViewButton.Size = new System.Drawing.Size(184, 39);
            this.CreateNewViewButton.TabIndex = 7;
            this.CreateNewViewButton.Text = "Создать отчет";
            this.CreateNewViewButton.UseVisualStyleBackColor = false;
            this.CreateNewViewButton.Click += new System.EventHandler(this.CreateNewViewButton_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainMenu.BackgroundImage")));
            this.MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainMenu.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenuItem});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(953, 34);
            this.MainMenu.TabIndex = 8;
            this.MainMenu.Text = "MainMenu";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.HelpMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpProviderMenuItem,
            this.AboutMenuItem});
            this.HelpMenuItem.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(89, 30);
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
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\krwinwx\\Desktop\\XML Convert\\WindowsFormsApp1\\bin\\Debug\\help.chm";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.FhkHbDaaEAAwT3K;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(953, 610);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.CreateNewViewButton);
            this.Controls.Add(this.FieldsDataGrid);
            this.Controls.Add(this.TablesTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конструктор отчета";
            ((System.ComponentModel.ISupportInitialize)(this.FieldsDataGrid)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView TablesTreeView;
        private System.Windows.Forms.DataGridView FieldsDataGrid;
        private System.Windows.Forms.Button CreateNewViewButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpProviderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}