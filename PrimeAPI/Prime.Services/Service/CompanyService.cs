using Newtonsoft.Json;
using Prime.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Services.Service
{
    public class CompanyService
    {
        private readonly IPrimeCustomRepository<Company> _repo;

        public CompanyService(IPrimeCustomRepository<Company> repo)
        {
            _repo = repo;
        }

        public List<CompanyVM> GetCompanies()
        {
            List<CompanyVM> companies = new List<CompanyVM>();
            var xcompanies = _repo.GetAll();
            companies = xcompanies.Select(s=> new CompanyVM()
            {
                ID = s.ID,
                Name = s.Name,
                Address = s.Address,
                AdditionalPropertiesJson = JsonConvert.SerializeObject(s.AdditionalProperties, Formatting.Indented)
            }).ToList();
            return companies;
        }       

        public CompanyVM GetCompanyInfo(int id)
        {
            Company company = _repo.Get(id);
            CompanyVM vm = new CompanyVM();
            vm.Name = company.Name;
            vm.Address = company.Address;
            vm.AdditionalPropertiesJson = JsonConvert.SerializeObject(company.AdditionalProperties, Formatting.Indented);
            return vm;
        }
        public int AddCompany(Company company)
        {
            _repo.Insert(company);
            return 1;
        }
        public int AddCompanyProp(Company company)
        {
            _repo.Update(company);
            return 1;
        }
        public int UpdateCompany(Company company)
        {
            _repo.Update(company);
            return 1;
        }

        public int DeleteCompany(int id)
        {
            _repo.Delete(id);
            return 1;
        }

    }
}
