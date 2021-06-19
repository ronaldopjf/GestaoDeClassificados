namespace Spedy.Desafio.API.Models.Entities
{
    public class ResponseObject<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }

        public ResponseObject(bool success, string message = "", dynamic obj = null)
        {
            Success = success;
            Message = message;
            Object = obj;
        }
    }
}
