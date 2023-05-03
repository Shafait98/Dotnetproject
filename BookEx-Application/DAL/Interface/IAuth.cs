using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAuth
    {
        Admin Authenticate(string username, string password);
        

    }

    public interface IAuthPublish
    {
        Publisher Authentication(string username, string password);

    }



}
