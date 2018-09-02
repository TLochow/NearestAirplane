using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiClient {
    public class WebClient {
        public static async Task<string> Get(string url) {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            return response;
        }
    }
}