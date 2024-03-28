using System.Net;
using System.Text.Json;

namespace LibraryUtil.DTO.ResponseDTO
{
    public class ResultResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
