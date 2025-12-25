using AutoMapper;
using Entites.DataTransferObjects;
using Entites.Models;

namespace WebApi.Utilis.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>();
        }
    }
}
