using Spedy.Desafio.API.Models.Entities;
using System;

namespace Spedy.Desafio.API.Models.DTOs
{
    public class ClassifiedForUpdateDto : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
