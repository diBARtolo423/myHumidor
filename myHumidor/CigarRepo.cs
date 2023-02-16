using myHumidor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;

namespace myHumidor
{
    public class CigarRepo : ICigarRepo
    {
        private readonly string _conn;
        
        public CigarRepo(string conn)
        {
            _conn = conn;
        }
        public Cigar GetCigarList()
        {
            var cigar = new Cigar();
            var cigar2 = new Cigar();
            var key = File.ReadAllText("appsettings.json");
            var APIKey = JObject.Parse(key).GetValue("DefaultKey").ToString();
            var client = new RestClient("https://cigars.p.rapidapi.com/cigars?page=1");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", $"{APIKey}");
            request.AddHeader("X-RapidAPI-Host", "cigars.p.rapidapi.com");

            var response = client.Execute(request);
            cigar = JsonConvert.DeserializeObject<Cigar>(response.Content);
            for (var i = 2; i <= 1; i++)
            {
                client = new RestClient($"https://cigars.p.rapidapi.com/cigars?page={i}");
                response = client.Execute(request);
                cigar2 = JsonConvert.DeserializeObject<Cigar>(response.Content);
                cigar.Cigars.AddRange(cigar2.Cigars);
            }

            Cigar.SearchList.AddRange(cigar.Cigars);

            if (Cigar.Favorites == null)
            {
                Cigar.Favorites = new List<Cigar>();
            }
            return cigar;
        }

        public IEnumerable<Cigar> SearchCigars(string searchString)
        {
            var searchResults = Cigar.SearchList.Where(c => c.Name.ToLower().Contains(searchString.ToLower()));
            return searchResults;            
        }

        public void UpdateFavorite(Cigar cigar)
        {

            if (cigar.Favorite == true)
            {
                Cigar.Favorites.Add(cigar);
            }
            else
            {
                Cigar.Favorites.Remove(cigar);
            }
        }
    }
}
