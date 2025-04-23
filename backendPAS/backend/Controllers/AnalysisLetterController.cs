using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class AnalisisCartaController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public AnalisisCartaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> Analizar([FromBody] CartaRequest request)
        {
            var prompt = $"Analiza el siguiente texto y responde solo con una palabra: Aceptado, En espera o Rechazado.\n\nTexto:\n{request.Texto}";

            var content = new
            {
                model = "llama3",
                prompt = prompt,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:11434/api/generate", content);

            if (!response.IsSuccessStatusCode)
                return StatusCode(500, "Error al comunicarse con el modelo LLM");

            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();
            return Ok(new { estado = result?.response?.Trim() });
        }

        public class CartaRequest
        {
            public string Texto { get; set; }
        }

        public class OllamaResponse
        {
            public string response { get; set; }
        }
    }
}
