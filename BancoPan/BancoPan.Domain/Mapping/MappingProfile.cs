using AutoMapper;
using BancoPan.Domain.Domain;
using BancoPan.Entity.Entity;

namespace BancoPan.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteModel, Cliente>();
            CreateMap<Cliente, ClienteModel>();
            CreateMap<int, int>();
            CreateMap<int, int>();
        }
    }
}
