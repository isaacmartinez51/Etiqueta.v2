using Cups.Forms;
using Cups.Forms.Etiqueta;
using Cups.Forms.Validar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cups
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormPrincipal());
            //Application.Run(new FormValidar());
            Application.Run(new FormEtiquetas());
        }
    }
}
