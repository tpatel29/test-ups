using UPS_Project.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UPS_Project.Data;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

public class SiteService
{
    private readonly HttpClient httpClient;

    public SiteService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public Site GetFromFiles(string route)
    {
        try
        {
            string json = System.IO.File.ReadAllText("wwwroot/" + route + ".json");
            Site site = Newtonsoft.Json.JsonConvert.DeserializeObject<Site>(json);
            IEnumerable<MailBox> resultsMailBoxes = site.Mailboxes;
            return site;
        }
        catch(Exception ex)
        {
            return new Site();
        }
    }
    public async Task<Site> GetSiteAsync(string route)
    {

        //var API_URL = "https://json-server-zag8.onrender.com/tpatel29/newDatabase/" + route + ".json";
        var API_URL = "http://localhost:3000/tpatel29/newDatabase/" + "route" + ".json";

        var response = await httpClient.GetAsync(API_URL);
        //var response = await httpClient.GetAsync("");


        //response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        //Console.WriteLine(content.ToString());

        var site = JsonConvert.DeserializeObject<Site>(content);

        if (site != null)
        {
            return site;
        }
        else
        {
            return new Site();
        }
    }
}
