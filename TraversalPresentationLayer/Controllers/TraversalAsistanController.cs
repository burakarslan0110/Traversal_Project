using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TraversalPresentationLayer.Controllers
{
    [AllowAnonymous]
    [Route("api/chat")]
    [ApiController]
    public class TraversalAsistanController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiApiKey = "";

        public TraversalAsistanController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        
        {
            var userId = User.Identity.IsAuthenticated ? User.Identity.Name : "anonymous";

            // Get current message count from session
            var messageCountKey = $"{userId}_messageCount";
            int messageCount = HttpContext.Session.GetInt32(messageCountKey) ?? 0;

            // Check message limits
            if (userId == "anonymous" && messageCount >= 4)
            {
                return BadRequest("Traversal AI Asistan'ın kullanım limitine ulaştınız, devam etmek için lütfen sağ üst menüden giriş yapın veya üye olun!");
            }
            else if (userId != "anonymous" && messageCount >= 8)
            {
                return BadRequest("Traversal AI Asistan'ın kullanım limitine ulaştınız, lütfen daha sonra tekrar deneyin.");
            }

            // Increment message count in session
            HttpContext.Session.SetInt32(messageCountKey, messageCount + 1);

            var openAiMessages = new List<object>();

            // Add previous messages to the request
            foreach (var historyItem in message.History)
            {
                openAiMessages.Add(new { role = historyItem.Role, content = historyItem.Content });
            }

            // Add the new user message
            openAiMessages.Add(new { role = "user", content = message.Text });

            var openAiRequest = new
            {
                model = "gpt-4o-mini", // or appropriate model
                messages = openAiMessages
            };

            var requestContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(openAiRequest),
                Encoding.UTF8,
                "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _openAiApiKey);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Traversal AI Asistan şu an kullanım dışı, lütfen daha sonra tekrar deneyin!");
            }

            return Ok(responseContent);
        }
    }
}

public class ChatMessage
{
    public string Text { get; set; }
    public List<MessageHistory> History { get; set; } = new List<MessageHistory>();
}

public class MessageHistory
{
    public string Role { get; set; }
    public string Content { get; set; }
}
