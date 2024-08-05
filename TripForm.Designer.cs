namespace WindowsFormsApp1
{
    partial class TripForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripForm));
            this.DateShift = new System.Windows.Forms.DateTimePicker();
            this.OrderTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.EsOrderCount = new System.Windows.Forms.NumericUpDown();
            this.DispCB = new System.Windows.Forms.ComboBox();
            this.CarrierCB = new System.Windows.Forms.ComboBox();
            this.CarBrandCB = new System.Windows.Forms.ComboBox();
            this.CarNumberCB = new System.Windows.Forms.ComboBox();
            this.EsNameCB = new System.Windows.Forms.ComboBox();
            this.ImnsCB = new System.Windows.Forms.ComboBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrderTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EsOrderCount)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DateShift
            // 
            this.DateShift.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateShift.CalendarMonthBackground = System.Drawing.Color.AliceBlue;
            this.DateShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateShift.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateShift.Location = new System.Drawing.Point(235, 46);
            this.DateShift.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DateShift.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.DateShift.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.DateShift.Name = "DateShift";
            this.DateShift.Size = new System.Drawing.Size(180, 24);
            this.DateShift.TabIndex = 1;
            this.DateShift.Value = new System.DateTime(2024, 5, 22, 19, 23, 31, 0);
            // 
            // OrderTotalAmount
            // 
            this.OrderTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderTotalAmount.Location = new System.Drawing.Point(235, 284);
            this.OrderTotalAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OrderTotalAmount.Name = "OrderTotalAmount";
            this.OrderTotalAmount.Size = new System.Drawing.Size(95, 24);
            this.OrderTotalAmount.TabIndex = 4;
            // 
            // EsOrderCount
            // 
            this.EsOrderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EsOrderCount.Location = new System.Drawing.Point(235, 325);
            this.EsOrderCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EsOrderCount.Name = "EsOrderCount";
            this.EsOrderCount.Size = new System.Drawing.Size(95, 24);
            this.EsOrderCount.TabIndex = 5;
            this.EsOrderCount.ValueChanged += new System.EventHandler(this.EsOrderCount_ValueChanged);
            // 
            // DispCB
            // 
            this.DispCB.BackColor = System.Drawing.Color.AliceBlue;
            this.DispCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DispCB.ForeColor = System.Drawing.Color.Black;
            this.DispCB.FormattingEnabled = true;
            this.DispCB.Location = new System.Drawing.Point(235, 123);
            this.DispCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DispCB.Name = "DispCB";
            this.DispCB.Size = new System.Drawing.Size(298, 26);
            this.DispCB.TabIndex = 6;
            this.DispCB.SelectedValueChanged += new System.EventHandler(this.DispCB_SelectedValueChanged);
            // 
            // CarrierCB
            // 
            this.CarrierCB.BackColor = System.Drawing.Color.AliceBlue;
            this.CarrierCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarrierCB.ForeColor = System.Drawing.Color.Black;
            this.CarrierCB.FormattingEnabled = true;
            this.CarrierCB.Location = new System.Drawing.Point(235, 164);
            this.CarrierCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CarrierCB.Name = "CarrierCB";
            this.CarrierCB.Size = new System.Drawing.Size(298, 26);
            this.CarrierCB.TabIndex = 6;
            this.CarrierCB.SelectedValueChanged += new System.EventHandler(this.CarrierCB_SelectedValueChanged);
            // 
            // CarBrandCB
            // 
            this.CarBrandCB.BackColor = System.Drawing.Color.AliceBlue;
            this.CarBrandCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarBrandCB.ForeColor = System.Drawing.Color.Black;
            this.CarBrandCB.FormattingEnabled = true;
            this.CarBrandCB.Location = new System.Drawing.Point(235, 204);
            this.CarBrandCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CarBrandCB.Name = "CarBrandCB";
            this.CarBrandCB.Size = new System.Drawing.Size(298, 26);
            this.CarBrandCB.TabIndex = 6;
            this.CarBrandCB.SelectedValueChanged += new System.EventHandler(this.CarBrand_SelectedValueChanged);
            // 
            // CarNumberCB
            // 
            this.CarNumberCB.BackColor = System.Drawing.Color.AliceBlue;
            this.CarNumberCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarNumberCB.ForeColor = System.Drawing.Color.Black;
            this.CarNumberCB.FormattingEnabled = true;
            this.CarNumberCB.Location = new System.Drawing.Point(235, 244);
            this.CarNumberCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CarNumberCB.Name = "CarNumberCB";
            this.CarNumberCB.Size = new System.Drawing.Size(180, 26);
            this.CarNumberCB.TabIndex = 6;
            // 
            // EsNameCB
            // 
            this.EsNameCB.BackColor = System.Drawing.Color.AliceBlue;
            this.EsNameCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EsNameCB.ForeColor = System.Drawing.Color.Black;
            this.EsNameCB.FormattingEnabled = true;
            this.EsNameCB.Location = new System.Drawing.Point(235, 362);
            this.EsNameCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EsNameCB.Name = "EsNameCB";
            this.EsNameCB.Size = new System.Drawing.Size(296, 26);
            this.EsNameCB.TabIndex = 6;
            // 
            // ImnsCB
            // 
            this.ImnsCB.BackColor = System.Drawing.Color.AliceBlue;
            this.ImnsCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImnsCB.ForeColor = System.Drawing.Color.Black;
            this.ImnsCB.FormattingEnabled = true;
            this.ImnsCB.Location = new System.Drawing.Point(235, 83);
            this.ImnsCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImnsCB.Name = "ImnsCB";
            this.ImnsCB.Size = new System.Drawing.Size(298, 26);
            this.ImnsCB.TabIndex = 6;
            this.ImnsCB.SelectedValueChanged += new System.EventHandler(this.ImnsCB_SelectedValueChanged);
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
            this.MainMenu.Size = new System.Drawing.Size(549, 36);
            this.MainMenu.TabIndex = 42;
            this.MainMenu.Text = "MainMenu";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.HelpMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpMenuItem.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpMenuItem.ForeColor = System.Drawing.Color.Black;
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(91, 32);
            this.HelpMenuItem.Text = "Справка";
            this.HelpMenuItem.Click += new System.EventHandler(this.HelpMenuItem_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\krwinwx\\Desktop\\XML Convert\\WindowsFormsApp1\\bin\\Debug\\help.chm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(104, 46);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 28);
            this.label10.TabIndex = 43;
            this.label10.Text = "Дата смены:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(155, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 28);
            this.label1.TabIndex = 43;
            this.label1.Text = "ИМНС:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(115, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 28);
            this.label2.TabIndex = 43;
            this.label2.Text = "Диспетчер:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(119, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 28);
            this.label3.TabIndex = 43;
            this.label3.Text = "Перевозчик:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(102, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 28);
            this.label4.TabIndex = 43;
            this.label4.Text = "Модель авто:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(101, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 28);
            this.label5.TabIndex = 43;
            this.label5.Text = "Гос. рег. знак:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 281);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 28);
            this.label6.TabIndex = 43;
            this.label6.Text = "Кол-во заказов, всего:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 322);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 28);
            this.label7.TabIndex = 43;
            this.label7.Text = "из кот-рых с исп. ЭИС:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(329, 281);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 28);
            this.label9.TabIndex = 43;
            this.label9.Text = "шт.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(329, 322);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 28);
            this.label11.TabIndex = 43;
            this.label11.Text = "шт.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(117, 360);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 28);
            this.label8.TabIndex = 43;
            this.label8.Text = "Наим. ЭИС:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.button;
            this.OkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.ForeColor = System.Drawing.Color.White;
            this.OkButton.Location = new System.Drawing.Point(8, 435);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(107, 35);
            this.OkButton.TabIndex = 44;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = false;
            // 
            // TripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.FhkHbDaaEAAwT3K;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(549, 478);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.EsNameCB);
            this.Controls.Add(this.CarNumberCB);
            this.Controls.Add(this.CarBrandCB);
            this.Controls.Add(this.CarrierCB);
            this.Controls.Add(this.ImnsCB);
            this.Controls.Add(this.DispCB);
            this.Controls.Add(this.EsOrderCount);
            this.Controls.Add(this.OrderTotalAmount);
            this.Controls.Add(this.DateShift);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TripForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица Поездки";
            ((System.ComponentModel.ISupportInitialize)(this.OrderTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EsOrderCount)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DateShift;
        private System.Windows.Forms.NumericUpDown OrderTotalAmount;
        private System.Windows.Forms.NumericUpDown EsOrderCount;
        private System.Windows.Forms.ComboBox DispCB;
        private System.Windows.Forms.ComboBox CarrierCB;
        private System.Windows.Forms.ComboBox CarBrandCB;
        private System.Windows.Forms.ComboBox CarNumberCB;
        private System.Windows.Forms.ComboBox EsNameCB;
        private System.Windows.Forms.ComboBox ImnsCB;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button OkButton;
    }
}