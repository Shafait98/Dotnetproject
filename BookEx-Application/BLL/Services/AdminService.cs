using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class AdminServices
    {
        public static List<AdminDTO> Get()
        {
            var dbdata = DataAccessFactory.AdminDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<AdminDTO>>(dbdata);
            return data;
        }



        public static AdminDTO Get(int id)
        {
            var dbdata = DataAccessFactory.AdminDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<AdminDTO>(dbdata);
            return data;
        }



        public static AdminDTO Get(string username)
        {
            var dbdata = DataAccessFactory.AdminDataAccess().Get().FirstOrDefault(u => u.Username == username);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<AdminDTO>(dbdata);
            return data;
        }



        public static bool Add(AdminDTO adminDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Admin>(adminDto);

            if (Get(data.Username) != null)
            {
                return false;
            }
            return DataAccessFactory.AdminDataAccess().Insert(data);
        }



        public static bool Delete(int id)
        {
            return DataAccessFactory.AdminDataAccess().Delete(id);
        }



        public static bool Update(AdminDTO admin)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Admin>(admin);
            return DataAccessFactory.AdminDataAccess().Update(data);
        }




        public static object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
