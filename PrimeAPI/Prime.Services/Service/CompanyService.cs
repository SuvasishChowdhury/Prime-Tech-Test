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

        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            var xcompanies = _repo.GetAll();
            companies = xcompanies.ToList();
            return companies;
        }       

        public Company GetCompanyInfo(int id)
        {
            Company company = _repo.Get(id);
            return company;
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

    }
}
