using System;
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

            int[] FuelArea = { 197, 12, 8, 16, 1, 160, 0 ,104, 60 };
            int[] FiringI = { 225, 10, 6, 16, 1, 128, 64 , 48, 24 };
            int[] FiringII = { 183, 8, 6, 16, 1, 88, 64, 40, 36 };
            int[] Gase = { 246, 10, 26, 8, 1, 216, 0 , 232, 24 };
            int[] GaseSource = { 89, 4, 4, 16, 1, 64, 0, 56, 36 };
            int[] IHighAI = { 64, 0, 0, 0, 1, 0, 64 };
            int[] IIHighAI = { 64, 0, 0, 0, 1, 0, 64 };
            try
            {
                Task.Run(() =>
                {
                    string rawConnectionString = IniConfigHelper.ReadIniData("SqlKey", "Key", "", Application.StartupPath + "\\Config");

                    if (string.IsNullOrWhiteSpace(rawConnectionString))
                    {
                        Console.WriteLine("数据库连接配置为空，请检查 INI 文件。");
                        return;
                    }

                    string cleanConnectionString = rawConnectionString
                        .Trim()                      
                        .Replace("\r", "")           
                        .Replace("\n", "")           
                        .Replace("\\\"", "\"");      

                    try
                    {
                        SqlSugarService.SetConnectionString(cleanConnectionString);
                        SqlSugarService.CreateTable<SequenceSettingsModel>();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"数据库连接或建表失败: {ex.Message}");
                    }
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
