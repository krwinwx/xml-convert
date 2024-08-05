using System;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += 0.1d;
        }
    }
}
