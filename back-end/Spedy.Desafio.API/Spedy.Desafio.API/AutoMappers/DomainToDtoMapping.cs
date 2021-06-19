using Spedy.Desafio.API.Models.DTOs;
using Spedy.Desafio.API.Models.Entities;

namespace Spedy.Desafio.API.AutoMappers
{
    public class DomainToDtoMapping : AutoMapper.Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Classified, ClassifiedForReadDto>().ReverseMap();
            CreateMap<Classified, ClassifiedForCreateDto>().ReverseMap();
            CreateMap<Classified, ClassifiedForUpdateDto>().ReverseMap();
        }
    }
}
