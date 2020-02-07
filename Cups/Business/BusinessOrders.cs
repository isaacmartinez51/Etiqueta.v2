using Repositories.ViewModels;
using ReposotoriesCUPS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cups.Business
{
    public static class BusinessOrders
    {
        public static bool Terminado(string embarque)
        {
            bool terminado = false;
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                terminado = unitOfWork.OrderR.Exist(x => x.ShipmentNumber.Equals(embarque) && x.OnShipment == true && x.Finished == true);
            }
            return terminado;
        }

        public static bool Existe(string embarque) {
            bool existe = false;
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                var todo = unitOfWork.OrderR.ReadsItems();
                existe = unitOfWork.OrderR.Exist(x => x.ShipmentNumber.Equals(embarque));
                // OrderEModel
            }
            return existe;
        }
        /// <summary>
        /// Existe y esta asignada
        /// </summary>
        /// <param name="embarque"></param>
        /// <returns></returns>
        public static bool ExisteAsignada(string embarque)
        {
            bool existe = false;
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                var todo = unitOfWork.OrderR.ReadsItems();
                existe = unitOfWork.OrderR.Exist(x => x.ShipmentNumber.Equals(embarque) && x.OnShipment == true);
                // OrderEModel
            }
            return existe;
        }

        public static OrderVModel GetOrder(string embarque)
        {
            OrderVModel orden = new OrderVModel();
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                orden = unitOfWork.OrderR.GetOrderOnshipment(embarque);
               
                // OrderEModel
            }
            return orden;
        }

        public static OrderVModel GetOrdenCompleta(string embarque)
        {
            OrderVModel orden = new OrderVModel();
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                orden = unitOfWork.OrderR.GetQueryOrderComplete(embarque);
            }
            return orden;
        }


    }
}
