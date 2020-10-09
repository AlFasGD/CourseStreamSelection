using CourseStreamSelection.Forms;
using OfficeOpenXml;
using System;
using System.Windows.Forms;

namespace CourseStreamSelection
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            SetupDependencies();
            OpenMainProgram();
        }

        private static void OpenMainProgram()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        private static void SetupDependencies()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
        }
    }
}
