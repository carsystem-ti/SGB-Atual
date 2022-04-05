using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SGB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>-0
        [STAThread]
        static void Main()
        {
            System.Reflection.Assembly app = System.Reflection.Assembly.GetExecutingAssembly();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if ( Environment.UserName.ToLower() == "cpier") // 
                Application.Run(new Menu());
            else
                // Application.Run(CarSystem.Login.Login.telaLogin(new Menu(), true, false, app.GetName().Name)); 
                Application.Run(new Remessa());
            //Application.Run(new geraBoletos.OperBoletos ());
            //Application.Run(CarSystem.Login.Login.telaLogin(new menu(), true, false, app.GetName().Name)); 


        }
    }
}
