using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PublisherServices
    {
        public static List<PublisherDTO> Get()
        {
            var dbdata = DataAccessFactory.PublisherDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Publisher, PublisherDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PublisherDTO>>(dbdata);
            return data;
        }



        public static PublisherDTO Get(int id)
        {
            var dbdata = DataAccessFactory.PublisherDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Publisher, PublisherDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<PublisherDTO>(dbdata);
            return data;
        }



        public static PublisherDTO Get(string username)
        {
            var dbdata = DataAccessFactory.PublisherDataAccess().Get().FirstOrDefault(u => u.Username == username);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Publisher, PublisherDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<PublisherDTO>(dbdata);
            return data;
        }



        public static bool Add(PublisherDTO publisherDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PublisherDTO, Publisher>();
                cfg.CreateMap<Publisher, PublisherDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Publisher>(publisherDto);

            if (Get(data.Username) != null)
            {
                return false;
            }
            return DataAccessFactory.PublisherDataAccess().Insert(data);
        }



        public static bool Delete(int id)
        {
            return DataAccessFactory.PublisherDataAccess().Delete(id);
        }



        public static bool Update(PublisherDTO publisher)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PublisherDTO, Publisher>();
                cfg.CreateMap<Publisher, PublisherDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Publisher>(publisher);
            return DataAccessFactory.PublisherDataAccess().Update(data);
        }




        public static object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
