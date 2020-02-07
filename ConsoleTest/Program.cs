using ReposotoriesCUPS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext())) {
                var user = unitOfWork.UsersR.GetQueryAllUser().ToList();
            }
                
        }
    }
}
