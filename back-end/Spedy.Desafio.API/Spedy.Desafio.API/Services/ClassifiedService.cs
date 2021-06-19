using AutoMapper;
using Spedy.Desafio.API.Interfaces.Repositories;
using Spedy.Desafio.API.Interfaces.Services;
using Spedy.Desafio.API.Interfaces.UnityOfWork;
using Spedy.Desafio.API.Models.DTOs;
using Spedy.Desafio.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Spedy.Desafio.API.Services
{
    public class ClassifiedService : IClassifiedService
    {
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IClassifiedRepository _classifiedRepository;

        public ClassifiedService(IMapper mapper, IUnityOfWork unityOfWork, IClassifiedRepository classifiedRepository)
        {
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _classifiedRepository = classifiedRepository;
        }

        public IEnumerable<ClassifiedForReadDto> Get()
        {
            var classifieds = _classifiedRepository.Get();
            return _mapper.Map<IEnumerable<ClassifiedForReadDto>>(classifieds);
        }

        public ClassifiedForUpdateDto Get(int id)
        {
            var classified = _classifiedRepository.Get(id);
            return _mapper.Map<ClassifiedForUpdateDto>(classified);
        }

        public IEnumerable<ClassifiedForReadDto> Get(string title)
        {
            var classifieds = _classifiedRepository.Get(title);
            return _mapper.Map<IEnumerable<ClassifiedForReadDto>>(classifieds);
        }

        public ResponseObject<ClassifiedForReadDto> Post(ClassifiedForCreateDto classifiedForCreateDto)
        {
            var classifiedForCreate = _mapper.Map<Classified>(classifiedForCreateDto);
            classifiedForCreate.Active = true;
            classifiedForCreate.Date = DateTime.Now;

            _classifiedRepository.Post(classifiedForCreate);

            try
            {
                var commit = _unityOfWork.Commit();

                return commit
                    ? new ResponseObject<ClassifiedForReadDto>(true, obj: _mapper.Map<ClassifiedForReadDto>(classifiedForCreate))
                    : new ResponseObject<ClassifiedForReadDto>(false);
            }
            catch (Exception e)
            {
                return new ResponseObject<ClassifiedForReadDto>(false, e.InnerException.Message, null);
            }
        }

        public ResponseObject<ClassifiedForReadDto> Put(ClassifiedForUpdateDto classifiedForUpdateDto)
        {
            var classifiedForCheckId = _classifiedRepository.Get(classifiedForUpdateDto.Id);
            if (classifiedForCheckId == null)
                return new ResponseObject<ClassifiedForReadDto>(false, "Classificado inexistente");

            var classifiedForUpdate = _mapper.Map<Classified>(classifiedForUpdateDto);
            _classifiedRepository.Put(classifiedForUpdate);
            var commit = _unityOfWork.Commit();

            return commit
                ? new ResponseObject<ClassifiedForReadDto>(true, obj: _mapper.Map<ClassifiedForReadDto>(classifiedForUpdate))
                : new ResponseObject<ClassifiedForReadDto>(false);
        }

        public ResponseObject<bool> Delete(int id)
        {
            _classifiedRepository.Delete(id);
            var commit = _unityOfWork.Commit();

            return commit
                ? new ResponseObject<bool>(true, "Classificado excluído com sucesso", true)
                : new ResponseObject<bool>(false, "A exclusão falhou", false);
        }

        public ResponseObject<bool> Delete(IEnumerable<ClassifiedForReadDto> classifieds)
        {
            throw new NotImplementedException();
        }
    }
}
