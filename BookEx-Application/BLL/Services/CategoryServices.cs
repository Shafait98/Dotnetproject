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
    public class CategoryServices
    {
        public static List<CategoryDTO> Get()
        {
            var dbdata = DataAccessFactory.CategoryDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CategoryDTO>>(dbdata);
            return data;
        }



        public static CategoryDTO Get(int id)
        {
            var dbdata = DataAccessFactory.CategoryDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<CategoryDTO>(dbdata);
            return data;
        }



        public static CategoryDTO Get(string name)
        {
            var dbdata = DataAccessFactory.CategoryDataAccess().Get().FirstOrDefault(u => u.Name == name);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<CategoryDTO>(dbdata);
            return data;
        }




        public static bool Add(CategoryDTO categoryDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(categoryDTO);

            if (Get(data.Name) != null)
            {
                return false;
            }
            return DataAccessFactory.CategoryDataAccess().Insert(data);
        }



        public static bool Delete(int id)
        {
            return DataAccessFactory.CategoryDataAccess().Delete(id);
        }



        public static bool Update(CategoryDTO category)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(category);
            return DataAccessFactory.CategoryDataAccess().Update(data);
        }




        public static object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
