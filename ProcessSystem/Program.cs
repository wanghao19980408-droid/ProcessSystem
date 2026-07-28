using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessSystemLib;
using ProcessSystemLib.Model;
namespace ProcessSystem
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            int[] FuelArea = { 197, 12, 8, 16, 1, 160, 0 };
            int[] FiringI = { 225, 10, 6, 16, 1, 128, 64 };
            int[] FiringII = { 183, 8, 6, 16, 1, 88, 64 };
            int[] Gase = { 246, 10, 26, 8, 1, 216, 0 };
            int[] GaseSource = { 89, 4, 4, 16, 1, 64, 0 };
            int[] IHighAI = { 64, 0, 0, 0, 1, 0, 64 };
            int[] IIHighAI = { 64, 0, 0, 0, 1, 0, 64 };
            try
            {
                Task.Run(() =>
                {
                    SqlSugarService.SetConnectionString("Data Source=192.168.25.155;Initial Catalog=FcsDB;User ID=sa;Password=123;");
                    //SqlSugarService.SetConnectionString("Data Source=DESKTOP-6MPOC9C;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";");
                    SqlSugarService.CreateTable<SequenceSettingsModel>();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(FuelArea, FiringI, FiringII, Gase, GaseSource, IHighAI, IIHighAI));
        }
    }
}
