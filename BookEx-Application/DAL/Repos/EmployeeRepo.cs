using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class EmployeeRepo : Repo, IRepo<Employee, int, bool>
    {

        public bool Delete(int id)
        {
            var ext = db.Employee.Find(id);
            db.Employee.Remove(ext);
            return db.SaveChanges() > 0;
        }



        public List<Employee> Get()
        {
            return db.Employee.ToList();
        }



        public Employee Get(int id)
        {
            return db.Employee.Find(id);
        }



        public bool Insert(Employee obj)
        {
            db.Employee.Add(obj);
            return db.SaveChanges() > 0;
        }



        public bool Update(Employee obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
