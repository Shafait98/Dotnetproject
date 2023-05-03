using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepo : Repo, IRepo<Category, int, bool>
    {
        public bool Delete(int id)
        {
            var ext = db.Category.Find(id);
            db.Category.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Category.ToList();
        }

        public Category Get(int id)
        {
            return db.Category.Find(id);
        }

        public bool Insert(Category obj)
        {
            db.Category.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Category obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}
