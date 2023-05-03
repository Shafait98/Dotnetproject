using DAL.Interface;
using DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PublisherRepo : Repo, IRepo<Publisher, int, bool>, IAuthPublish
    {
        public Publisher Authentication(string username, string password)
        {
            var publisher = db.Publisher.FirstOrDefault(
                            a =>
                                a.Username.Equals(username) &&
                                a.Password.Equals(password)
                        );
            return publisher;

        }

        public bool Delete(int id)
        {
            var ext = db.Publisher.Find(id);
            db.Publisher.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Publisher> Get()
        {
            return db.Publisher.ToList();
        }

        public Publisher Get(int id)
        {
            return db.Publisher.Find(id);
        }

        public bool Insert(Publisher obj)
        {
            db.Publisher.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Publisher obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
