namespace WindowsFormsApp1.Resources
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.SavePathAllDocsCheck = new System.Windows.Forms.CheckBox();
            this.docDataGrid = new System.Windows.Forms.DataGridView();
            this.PrimaryDocColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SavePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusDocColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpProviderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.docDataGrid)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathTextBox
            // 
            this.PathTextBox.BackColor = System.Drawing.Color.White;
            this.PathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(118)))), ((int)(((byte)(183)))));
            this.PathTextBox.Location = new System.Drawing.Point(13, 72);
            this.PathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.PathTextBox.Size = new System.Drawing.Size(430, 26);
            this.PathTextBox.TabIndex = 8;
            this.PathTextBox.Text = "Выберите путь сохранения и имя документа";
            this.PathTextBox.TextChanged += new System.EventHandler(this.PathTextBox_TextChanged);
            this.PathTextBox.DoubleClick += new System.EventHandler(this.PathTextBox_DoubleClick);
            // 
            // SavePathAllDocsCheck
            // 
            this.SavePathAllDocsCheck.AutoSize = true;
            this.SavePathAllDocsCheck.BackColor = System.Drawing.Color.Transparent;
            this.SavePathAllDocsCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SavePathAllDocsCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.SavePathAllDocsCheck.Location = new System.Drawing.Point(14, 47);
            this.SavePathAllDocsCheck.Margin = new System.Windows.Forms.Padding(4);
            this.SavePathAllDocsCheck.Name = "SavePathAllDocsCheck";
            this.SavePathAllDocsCheck.Size = new System.Drawing.Size(271, 22);
            this.SavePathAllDocsCheck.TabIndex = 7;
            this.SavePathAllDocsCheck.Text = "Выбрать путь сохранения для всех";
            this.SavePathAllDocsCheck.UseVisualStyleBackColor = false;
            this.SavePathAllDocsCheck.CheckedChanged += new System.EventHandler(this.SavePathAllDocsCheck_CheckedChanged);
            // 
            // docDataGrid
            // 
            this.docDataGrid.AllowUserToAddRows = false;
            this.docDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.docDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.docDataGrid.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.docDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.docDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.docDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.docDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrimaryDocColumn,
            this.SavePathColumn,
            this.StatusDocColumn});
            this.docDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.docDataGrid.Location = new System.Drawing.Point(0, 157);
            this.docDataGrid.Name = "docDataGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(118)))), ((int)(((byte)(183)))));
            this.docDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.docDataGrid.Size = new System.Drawing.Size(872, 469);
            this.docDataGrid.TabIndex = 14;
            this.docDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.docsDataGrid_CellContentClick);
            // 
            // PrimaryDocColumn
            // 
            this.PrimaryDocColumn.HeaderText = "Исходный документ";
            this.PrimaryDocColumn.Name = "PrimaryDocColumn";
            // 
            // SavePathColumn
            // 
            this.SavePathColumn.HeaderText = "Путь сохранения";
            this.SavePathColumn.Name = "SavePathColumn";
            // 
            // StatusDocColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StatusDocColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.StatusDocColumn.HeaderText = "Статус";
            this.StatusDocColumn.Name = "StatusDocColumn";
            this.StatusDocColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.FileMenuItem,
            this.HelpMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(872, 36);
            this.MainMenu.TabIndex = 16;
            this.MainMenu.Text = "MainMenu";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.FileMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileMenuItem});
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
            this.OpenFileMenuItem.ForeColor = System.Drawing.Color.Black;
            this.OpenFileMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OpenFileMenuItem.Name = "OpenFileMenuItem";
            this.OpenFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFileMenuItem.Size = new System.Drawing.Size(249, 32);
            this.OpenFileMenuItem.Text = "Открыть";
            this.OpenFileMenuItem.Click += new System.EventHandler(this.AddDocument_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.HelpMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpProviderMenuItem,
            this.AboutMenuItem});
            this.HelpMenuItem.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpMenuItem.ForeColor = System.Drawing.Color.Black;
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(91, 32);
            this.HelpMenuItem.Text = "Справка";
            // 
            // HelpProviderMenuItem
            // 
            this.HelpProviderMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.HelpProviderMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.HelpProviderMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpProviderMenuItem.ForeColor = System.Drawing.Color.Black;
            this.HelpProviderMenuItem.Name = "HelpProviderMenuItem";
            this.HelpProviderMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.HelpProviderMenuItem.Size = new System.Drawing.Size(237, 32);
            this.HelpProviderMenuItem.Text = "Справка";
            this.HelpProviderMenuItem.Click += new System.EventHandler(this.HelpProviderMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.AboutMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_aero;
            this.AboutMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AboutMenuItem.ForeColor = System.Drawing.Color.Black;
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(237, 32);
            this.AboutMenuItem.Text = "О программе";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.restart;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(56, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Restart);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.play;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(10, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 15;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\krwinwx\\Desktop\\XML Convert\\WindowsFormsApp1\\bin\\Debug\\help.chm";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.FhkHbDaaEAAwT3K;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(872, 627);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.docDataGrid);
            this.Controls.Add(this.SavePathAllDocsCheck);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Convert v.1.0.3 Преобразование";
            ((System.ComponentModel.ISupportInitialize)(this.docDataGrid)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.CheckBox SavePathAllDocsCheck;
        private System.Windows.Forms.DataGridView docDataGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpProviderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaryDocColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SavePathColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusDocColumn;
    }
}