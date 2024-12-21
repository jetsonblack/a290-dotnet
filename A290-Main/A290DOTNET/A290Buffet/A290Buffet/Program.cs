using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/**********************************************************
* Program.cs
*
* Base Program.cs genearted by VSstudio.
*
* Author: Jetson Black
* Date Created: 10/28/2024
* Last Modified by: Jetson Black
* Date Last Modified: 10/28/2024
* Assignment: A290 Buffet
* Part of: A290
*/



namespace A290Buffet
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBuffetMain());
        }
    }
}
