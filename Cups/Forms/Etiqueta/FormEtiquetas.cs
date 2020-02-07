using Cups.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cups.Forms.Etiqueta
{
    public partial class FormEtiquetas : Form
    {
        public FormEtiquetas()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            ObtenerEtiqueta();
            // ObtenerEtiquetaPrint();
        }

        private void ObtenerEtiqueta()
        {
            lblError.Visible = false;
            bool print = false;
            if (null != txtSerial.Text && txtSerial.Text != string.Empty)
            {
                var item = ConnectionTraza.GetInformationSerial(txtSerial.Text);
                //if (item.MLFB != null)
                //{
                //    string zpl = replaceZPL(item);
                //    print = printLabel(@"ZDesigner ZT410-203dpi ZPL", zpl);
                //    txtSerial.Text = string.Empty;
                //    if (print)
                //        Correcto();
                //    else
                //        Incorrecto();
                //}
                //else
                //    NoExiste();
            }
            else
                Vacio();
        }


        #region Validaciones
        private void Vacio()
        {
            txtSerial.Text = string.Empty;
            lblError.Text = "El campo no puede estar en blanco.";
            lblCorrecto.Visible = false;
            lblError.Visible = true;
        }
        private void NoExiste()
        {
            txtSerial.Text = string.Empty;
            lblError.Text = "No fué posible obtener información del serial.";
            lblCorrecto.Visible = false;
            lblError.Visible = true;
        }
        private void Correcto()
        {
            txtSerial.Text = string.Empty;
            lblCorrecto.Text = "Impresión correecta.";
            lblCorrecto.Visible = true;
            lblError.Visible = false;
        }
        private void Incorrecto()
        {
            txtSerial.Text = string.Empty;
            lblError.Text = "No fué posible imprimir";
            lblCorrecto.Visible = false;
            lblError.Visible = true;
        }
        #endregion

        private void ObtenerEtiquetaPrint()
        {
            printDialog1 = new PrintDialog();

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                bool print = false;
                if (null != txtSerial.Text)
                {

                    var item = ConnectionTraza.GetInformationSerial(txtSerial.Text);
                    if (item.MLFB != null)
                    {
                        string zpl = replaceZPL(item);
                        print = printLabel(printDialog1.PrinterSettings.PrinterName, zpl);
                        txtSerial.Text = string.Empty;
                        if (print)
                            Correcto();
                        else
                            Incorrecto();
                    }
                    else
                        NoExiste();
                }
                else
                    Vacio();
            }
        }
        #region ZPL
        private string replaceZPL(SerialPrintModel label)
        {

            if (label != null)
            {
                string zplBase = "^XA^RFW,H,1,2,1^FD4000^FS^RFW,A,2,16,1^FD*RFID*^FS^A0N,49,48^FO60,25^CI0^FD*tittle*^FS^A0N,25,26^FO65,70^CI0^FD*em*^FS^A0N,33,32^FO70,100^CI0^FDNo. de Parte:^FS^A0N,33,32^FO280,100^CI0^FD*mlfb* - *sh*R^FS^A0N,33,32^FO70,134^CI0^FDCantidad:^FS^A0N,33,32^FO200,132^CI0^FD*qn*^FS^A0N,33,32^FO320,132^CI0^FDTipo de Embarque:^FS^A0N,33,32^FO610,132^CI0^FD*ta*^FS^A0N,33,32^FO70,185^CI0^FDSerial:^FS^BY2,2.6^FO65,235^B3N,N,60,Y,N^FDsr^FS^A0N,17,18^FO73,360^CI0^FDFecha:^FS^A0N,17,18^FO126,360^CI0^FD*date*^FS^A0N,33,25^FO530,360^CI0^FDRFID^FS^PQ1,0,1,Y^XZ";
                StringBuilder zpl = new StringBuilder(zplBase);
                zpl.Replace("*RFID*", Mlfb16char(label.MLFB));
                zpl.Replace("*tittle*", "Blackflush de Producto Terminado");
                zpl.Replace("*em*", "Etiqueta Master");
                zpl.Replace("*mlfb*", label.MLFB);
                zpl.Replace("*sh*", label.PackingType);
                zpl.Replace("*ta*", "Tarima");
                zpl.Replace("*qn*", label.Quantity.ToString());
                zpl.Replace("sr", label.Serial);
                zpl.Replace("*date*", DateTime.Now.ToString());

                return zpl.ToString();
            }
            return null;
        }

        private string Mlfb16char(string mlfb)
        {
            int total = mlfb.Length;
            if (total < 16)
            {
                StringBuilder sbMlfb = new StringBuilder(mlfb);
                for (int i = total; i < 16; i++)
                {
                    sbMlfb.Insert(i, '@');
                }
                return sbMlfb.ToString();
            }
            else
                return mlfb;
        }

        private bool printLabel(string printer, string zpl)
        {
            return RawPrinterHelper.SendStringToPrinter(printer, zpl);
        }
        #endregion

        private void txtSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ObtenerEtiqueta();
            }
        }



        private void txtSerial_TextChanged(object sender, EventArgs e)
        {

            lblError.Visible = false;
            lblCorrecto.Visible = false;
        }
    }
}
