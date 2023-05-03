using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeServices
    {
        public static List<EmployeeDTO> Get()
        {
            var dbdata = DataAccessFactory.EmployeeDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<EmployeeDTO>>(dbdata);
            return data;
        }



        public static EmployeeDTO Get(int id)
        {
            var dbdata = DataAccessFactory.EmployeeDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<EmployeeDTO>(dbdata);
            return data;
        }


        public static EmployeeDTO Get(string username)
        {
            var dbdata = DataAccessFactory.EmployeeDataAccess().Get().FirstOrDefault(u => u.Username == username);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<EmployeeDTO>(dbdata);
            return data;
        }



        public static bool Add(EmployeeDTO employeeDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(employeeDTO);

            if (Get(data.Username) != null)
            {
                return false;
            }
            return DataAccessFactory.EmployeeDataAccess().Insert(data);
        }



        public static bool Delete(int id)
        {
            return DataAccessFactory.EmployeeDataAccess().Delete(id);
        }



        public static bool Update(EmployeeDTO employee)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(employee);
            return DataAccessFactory.EmployeeDataAccess().Update(data);
        }




        public static object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
