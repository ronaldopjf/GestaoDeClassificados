using Spedy.Desafio.API.Models.DTOs;
using Spedy.Desafio.API.Models.Entities;
using System.Collections.Generic;

namespace Spedy.Desafio.API.Interfaces.Services
{
    public interface IClassifiedService
    {
        IEnumerable<ClassifiedForReadDto> Get();
        ClassifiedForUpdateDto Get(int id);
        IEnumerable<ClassifiedForReadDto> Get(string title);
        ResponseObject<ClassifiedForReadDto> Post(ClassifiedForCreateDto classifiedForCreateDto);
        ResponseObject<ClassifiedForReadDto> Put(ClassifiedForUpdateDto classifiedForUpdateDto);
        ResponseObject<bool> Delete(int id);
        ResponseObject<bool> Delete(IEnumerable<ClassifiedForReadDto> classifieds);

    }
}
