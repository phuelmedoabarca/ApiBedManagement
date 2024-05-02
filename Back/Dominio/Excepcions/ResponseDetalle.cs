using System.Text.Json;

namespace Domain.Excepcions
{
    public class ResponseDetalle
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
