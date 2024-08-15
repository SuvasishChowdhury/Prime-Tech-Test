using Microsoft.AspNetCore.Mvc;
using Prime.Entities;
using Prime.Infrastructure;
using Prime.Services.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _service;

        public CompanyController(IPrimeCustomRepository<Company> primeCustomRepository)
        {
            _service = new CompanyService(primeCustomRepository);
        }
        // GET: api/<CompanyController>
        [HttpGet]
        [Route("GetAllCompanies")]
        public IEnumerable<CompanyVM> Get()
        {
            List<CompanyVM> companies = _service.GetCompanies();

            return companies;
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public CompanyVM Get(int id)
        {
            CompanyVM com = _service.GetCompanyInfo(id);
            return com;
        }

        // POST api/<CompanyController>
        //[HttpPost]
        //[Route("AddCompany")]
        //public void Post([FromBody] Company company)
        //{
        //    _service.AddCompany(company);
        //}
        [HttpPost]
        [Route("AddCompany")]
        public void Post([FromBody] CompanyVM vm)
        {
            Company company  = new Company();
            company.Name = vm.Name;
            company.Address = vm.Address;
            company.AdditionalProperties = vm.AdditionalPropertiesJson;
            _service.AddCompany(company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company company)
        {
            _service.UpdateCompany(company);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteCompany(id);
        }
    }
}
