using System;

namespace Spedy.Desafio.API.Models.Entities
{
    public class Classified : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
