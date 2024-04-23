using AutoMapper;
using Project3.Models;
using Project3.Models.DTO;

namespace Project3.AutoMapper
{
    public class MappingConf :Profile
    {
        public MappingConf() { 
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
        
    }
}
