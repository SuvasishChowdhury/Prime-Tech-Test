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

        public async Task<Company> getCompanyInformation(int id)
        {
            Company compInfo = new Company();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync("api/Company/" + id).Result;
                if (Res.IsSuccessStatusCode)
                {
                    var compResponse = Res.Content.ReadAsStringAsync().Result;
                    compInfo = JsonConvert.DeserializeObject<Company>(compResponse);
                }

            }
            return compInfo;
        }

        public async Task<int> addCompanies(Company company)
        {
            var result = 0;
            if (company != null && company.ID != 0)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var response = client.PutAsJsonAsync("api/Company/" + company.ID, company).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return result = 1;
                    }
                    else
                        return result;
                }
            }
            else
            {
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
        }
        public async Task<int> deleteCompanies(int id)
        {
            var result = 0;
            if (id != 0)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var response = client.DeleteAsync("api/Company/" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return result = 1;
                    }
                    else
                        return result;
                }
            }
            return result;
        }

        public async Task<int> addCompanyProp(Company company)
        {
            var result = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PostAsJsonAsync("api/AddProp/AddCompanyProperty", company).Result;
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
