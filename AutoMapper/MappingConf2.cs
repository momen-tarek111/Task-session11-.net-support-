using AutoMapper;
using Project3.Models;
using Project3.Models.DTO;

namespace Project3.AutoMapper
{
    public class MappingConf2:Profile
    {
        public MappingConf2()
        {
            CreateMap<Blog,BlogDTO>().ReverseMap();
        }
    }
}
