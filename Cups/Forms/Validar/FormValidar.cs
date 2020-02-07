using Cups.Business;
using Newtonsoft.Json;
using Repositories.ViewModels;
using ReposotoriesCUPS.Data;
using ReposotoriesCUPS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cups.Forms.Validar
{
    public partial class FormValidar : Form
    {
        public FormValidar()
        {
            InitializeComponent();
            //LlenarComboAnden();
        }
        #region Get API Embarques Information
        // el parametro debe ser un entero
        private ShipmentVModel Shipment(string numeroEmbarque)
        {
            ShipmentVModel result = new ShipmentVModel();
            try
            {
                int embarque = int.Parse(numeroEmbarque);
                var url = "https://continental.xlo.cloud/embarques/aviso/" + embarque;
                var webrequest = (HttpWebRequest)WebRequest.Create(url);
                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var json = reader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<ShipmentVModel>(json);

                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }



        }
        #endregion

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            OrderVModel order = new OrderVModel();
            if (BusinessOrders.Terminado(txbEmbarque.Text))
            {

            }
            else if (BusinessOrders.ExisteAsignada(txbEmbarque.Text))
            {
                var orden = BusinessOrders.GetOrder(txbEmbarque.Text);
            }
            else if (BusinessOrders.Existe(txbEmbarque.Text))
            {
                // se llena el combobox con los andenes
                LlenarComboAnden();
                // Obtengo los datos del embarque
                var uno = Shipment(txbEmbarque.Text);
                // Preguntas si esta cancelado
                if (int.Parse(uno.cancelado) == 0)
                {
                    dataGridView1.DataSource = null;
                    var dt = new DataTable();
                    dt.Columns.Add("continentalpartnumber");
                    dt.Columns.Add("traza");
                    dt.Columns.Add("total_pallets");
                    order = BusinessOrders.GetOrdenCompleta(txbEmbarque.Text);
                    foreach (var item in order.ListOrderDetail)
                    {
                        dt.Rows.Add(item.continentalpartnumber, item.traza, item.total_pallets);
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    dataGridView1.DataSource = dt;
                }
            }
            else {
                // se llena el combobox con los andenes
                LlenarComboAnden();
                // Obtengo los datos del embarque
                var uno = Shipment(txbEmbarque.Text);
                // Preguntas si esta cancelado
                if (int.Parse(uno.cancelado) == 0)
                {
                    dataGridView1.DataSource = null;
                    var dt = new DataTable();
                    dt.Columns.Add("continentalpartnumber");
                    dt.Columns.Add("traza");
                    dt.Columns.Add("total_pallets");
                    order = BusinessOrders.GetOrdenCompleta(txbEmbarque.Text);
                    foreach (var item in order.ListOrderDetail)
                    {
                        dt.Rows.Add(item.continentalpartnumber, item.traza, item.total_pallets);
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    dataGridView1.DataSource = dt;
                }

            }

            
        }

        private void LlenarComboAnden()
        {
            cboxAndenes.Visible = true;
            List<ReaderVModel> readers = new List<ReaderVModel>();
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                readers = unitOfWork.ReaderR.GetQueryReader().ToList();
            }
            //Vaciar comboBox
            cboxAndenes.DataSource = null;

            //Asignar la propiedad DataSource
            cboxAndenes.DataSource = readers;

            //Indicar qué propiedad se verá en la lista
            cboxAndenes.DisplayMember = "Name";

            //Indicar qué valor tendrá cada ítem
            cboxAndenes.ValueMember = "ReaderID";
        }
    }
}
