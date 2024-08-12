using Microsoft.AspNetCore.Mvc;
using Prime.Entities;
using Prime.Services.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPropController : ControllerBase
    {
        private readonly CompanyService _service;

        public AddPropController(IPrimeCustomRepository<Company> primeCustomRepository)
        {
            _service = new CompanyService(primeCustomRepository);
        }
        // POST api/<AddPropController>
        [HttpPost]
        [Route("AddCompanyProperty")]
        public void Post(string prop)
        {
            Company company = new Company();
            company.AddProperty(prop, null);
            _service.AddCompanyProp(company);
        }
    }
}
