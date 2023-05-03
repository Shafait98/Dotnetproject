using DAL.Interface;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IAuth AuthDataAccess()
        {
            return new AdminRepo();
        }
       


        public static IRepo<Admin, int, bool> AdminDataAccess()
        {
            return new AdminRepo();
        }


        public static IRepo<Category, int, bool> CategoryDataAccess()
        {
            return new CategoryRepo();
        }


        public static IRepo<Employee, int, bool> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }
        public static IRepo<Publisher, int, bool> PublisherDataAccess()
        {
            return new PublisherRepo();
        }
    }
}
