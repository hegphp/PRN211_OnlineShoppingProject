using AutoMapper;
using Project.DTO;
using Project.Models;

namespace Project.DTOConfig {
    public class CustomerConfig {
        public static void CreateMap(IMapperConfigurationExpression cfg){
            cfg.CreateMap<Customer, RegisterDTO>();

            cfg.CreateMap<RegisterDTO, Customer>();
        }
    }
}
