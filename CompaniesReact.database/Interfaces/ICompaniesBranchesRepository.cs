using CompaniesReact.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesReact.database.Interfaces
{
    public interface ICompaniesBranchesRepository
    {
        Task<IEnumerable<CompanyBranches>> Get();
        Task<IEnumerable<CompanyBranches>> GetSQL();
    }
}
