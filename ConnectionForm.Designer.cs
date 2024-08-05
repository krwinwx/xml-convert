namespace WindowsFormsApp1
{
    partial class ConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectDatabaseBt = new System.Windows.Forms.Button();
            this.DatabaseComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ServerNameTextBox.Enabled = false;
            this.ServerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerNameTextBox.ForeColor = System.Drawing.Color.Blue;
            this.ServerNameTextBox.Location = new System.Drawing.Point(13, 43);
            this.ServerNameTextBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ServerNameTextBox.Multiline = true;
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(408, 121);
            this.ServerNameTextBox.TabIndex = 1;
            this.ServerNameTextBox.Text = "localhost";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(176, 20);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(245, 22);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Изменить строку подключения";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.ChangeConnectionString);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Имя сервера";
            // 
            // ConnectDatabaseBt
            // 
            this.ConnectDatabaseBt.BackColor = System.Drawing.Color.Transparent;
            this.ConnectDatabaseBt.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.button;
            this.ConnectDatabaseBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectDatabaseBt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConnectDatabaseBt.FlatAppearance.BorderSize = 0;
            this.ConnectDatabaseBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectDatabaseBt.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectDatabaseBt.ForeColor = System.Drawing.Color.White;
            this.ConnectDatabaseBt.Location = new System.Drawing.Point(260, 174);
            this.ConnectDatabaseBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnectDatabaseBt.Name = "ConnectDatabaseBt";
            this.ConnectDatabaseBt.Size = new System.Drawing.Size(161, 38);
            this.ConnectDatabaseBt.TabIndex = 3;
            this.ConnectDatabaseBt.Text = "Подключиться";
            this.ConnectDatabaseBt.UseVisualStyleBackColor = false;
            this.ConnectDatabaseBt.Click += new System.EventHandler(this.Connect_Click);
            // 
            // DatabaseComboBox
            // 
            this.DatabaseComboBox.BackColor = System.Drawing.Color.AliceBlue;
            this.DatabaseComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DatabaseComboBox.ForeColor = System.Drawing.Color.Blue;
            this.DatabaseComboBox.FormattingEnabled = true;
            this.DatabaseComboBox.Location = new System.Drawing.Point(13, 261);
            this.DatabaseComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DatabaseComboBox.Name = "DatabaseComboBox";
            this.DatabaseComboBox.Size = new System.Drawing.Size(408, 28);
            this.DatabaseComboBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.button;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(260, 297);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выбрать базу";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ChooseDatabase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 224);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "База данных";
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.FhkHbDaaEAAwT3K;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(437, 345);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DatabaseComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectDatabaseBt);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ServerNameTextBox);
            this.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Convert Подключение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ServerNameTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectDatabaseBt;
        private System.Windows.Forms.ComboBox DatabaseComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}