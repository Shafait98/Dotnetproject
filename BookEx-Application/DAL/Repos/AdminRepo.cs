using DAL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class AdminRepo : Repo, IRepo<Admin, int, bool>, IAuth
    {
        public Admin Authenticate(string username, string password)
        {
            var admin = db.Admin.FirstOrDefault(
                            a =>
                                a.Username.Equals(username) &&
                                a.Password.Equals(password)
                        );
            return admin;
        }

        public bool Delete(int id)
        {
            var ext = db.Admin.Find(id);
            db.Admin.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admin.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admin.Find(id);
        }

        public bool Insert(Admin obj)
        {
            db.Admin.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Admin obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
