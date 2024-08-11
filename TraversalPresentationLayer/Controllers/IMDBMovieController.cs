using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalPresentationLayer.Areas.Admin.Models;
using TraversalPresentationLayer.Models;

namespace TraversalPresentationLayer.Controllers
{
    public class IMDBMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<IMDBMovieModel> apiMovies = new List<IMDBMovieModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
            { "x-rapidapi-key", "5304a69aacmsh6fc15023f51c452p19bc34jsn7ab26621b258" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies = JsonConvert.DeserializeObject<List<IMDBMovieModel>>(body);
                return View(apiMovies);
            }
        }
    }
}
