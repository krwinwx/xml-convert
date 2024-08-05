using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartForm start = new StartForm();
            DateTime end = DateTime.Now + TimeSpan.FromSeconds(5);
            start.Show();
            while (end > DateTime.Now)
            {
                Application.DoEvents();
            }
            start.Close();
            start.Dispose();

            Application.Run(new Form1());
        }
    }
}
