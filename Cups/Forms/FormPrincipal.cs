using Cups.Forms.Validar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cups.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            width();
            //Sidebar.Width = 270;
        }
        private void width()
        {

            var uno = Sidebar.Width;
            var dos = SidebarWrapper.Width;
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void MenuSidebar_Click(object sender, EventArgs e)
        {
            if (Sidebar.Width == 180)
            {
                Sidebar.Visible = false;
                Sidebar.Width = 55;
                SidebarWrapper.Width = 75;
                LineaSidebar.Width = 45;
                AnimationSidebar.Show(Sidebar);
            }
            else
            {
                Sidebar.Visible = false;
                Sidebar.Width = 180;
                SidebarWrapper.Width = 200;
                LineaSidebar.Width = 170;
                AnimationSidebarBack.Show(Sidebar);
            }
        }

        private void btnEtiquetas_Click(object sender, EventArgs e)
        {
            FormValidar etiquetas = new FormValidar();
            etiquetas.Show();
        }
    }

}
