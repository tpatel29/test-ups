using UPS_Project.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UPS_Project.Data;

public class SiteService
{
    private readonly HttpClient httpClient;

    public SiteService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Site> GetSiteAsync(string route)
    {

        //var API_URL = "https://json-server-zag8.onrender.com/tpatel29/tempDatabase/" + route + ".json";
        var API_URL = "http://localhost:3000/tpatel29/tempDatabase/" + route + ".json";

        var response = await httpClient.GetAsync(API_URL);

        //response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        //Console.WriteLine(content.ToString());

        var site = JsonConvert.DeserializeObject<Site>(content);

        return site;
    }
}
