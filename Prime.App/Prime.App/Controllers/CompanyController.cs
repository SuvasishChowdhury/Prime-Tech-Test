using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prime.App.Models;
using Prime.App.Service;
using System;
using System.Net.Http.Headers;

namespace Prime.App.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService _service;

        public CompanyController()
        {
            _service = new CompanyService();
        }
        public async Task<ActionResult> Index()
        {
            List<Company> compInfo = new List<Company>();
            compInfo = await _service.GetAllCompanies();
            return View(compInfo);            
        }


        [HttpGet]
        public async Task<ActionResult> AddCompany(int id)
        {
            Company company = new Company();
            if (id > 0)
            {
               company = await _service.getCompanyInformation(id);
            }

            return View(company);
        }

        [HttpPost]
        public async Task<ActionResult> AddCompany(Company company)
        {
            var result = await _service.addCompanies(company);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var result = await _service.deleteCompanies(id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult AddCompanyProp()
        {
            Company company = new Company();

            return View(company);
        }
        [HttpPost]
        public async Task<ActionResult> AddCompanyProp(Company company)
        {
            var result = await _service.addCompanyProp(company);
            return View(company);
        }
    }
}
