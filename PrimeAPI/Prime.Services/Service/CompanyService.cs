using Prime.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public int UpdateCompany(Company company)
        {
            _repo.Update(company);
            return 1;
        }

        private List<dictionary><string,>> LoadData(string sqlSelect)
        {
            var table = new List<dictionary>< string,>> ();
            using (var ctx = db)
            {
                ctx.Database.Connection.Open();
                using (var cmd = ctx.Database.Connection.CreateCommand())
                {
                    cmd.CommandText = sqlSelect;
                    //foreach (var param in sqlParameters)
                    //    cmd.Parameters.Add(param);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string,>();
                            for (int i = 0; i < reader.FieldCount; i++)
                                row[reader.GetName(i)] = reader[i];
                            table.Add(row);
                        }
                    }
                }
            }
            return table;
        }
    }
}
