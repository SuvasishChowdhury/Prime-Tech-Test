using Newtonsoft.Json;
using Prime.App.Models;
using System.Net.Http.Headers;

namespace Prime.App.Service
{
    public class CompanyService
    {
        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:7161/";
        public async Task<List<Company>> GetAllCompanies()
        {
            List<Company> compInfo = new List<Company>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllCompanies using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Company/GetAllCompanies");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var compResponse = Res.Content.ReadAsStringAsync().Result;
                    compInfo = JsonConvert.DeserializeObject<List<Company>>(compResponse);
                }
                
            }
            return compInfo;
        }

        public async Task<int> addCompanies(Company company)
        {
            var result = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PostAsJsonAsync("api/Company/AddCompany", company).Result;
                if (response.IsSuccessStatusCode)
                {
                    return result = 1;
                }
                else
                    return result;
            }
        }

        public async Task<int> addCompanyProp(string prop, string value)
        {
            var result = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PostAsJsonAsync("api/AddProp/AddCompanyProperty", prop).Result;
                if (response.IsSuccessStatusCode)
                {
                    return result = 1;
                }
                else
                    return result;
            }
        }
    }
}
