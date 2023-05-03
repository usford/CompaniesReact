using CompaniesReact.database.Interfaces;
using CompaniesReact.database.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CompaniesReact.database.Repositories
{
    public class CompanyBranchesRepository : ICompaniesBranchesRepository
    {
        private AppDbContext _db;
        public CompanyBranchesRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CompanyBranches>> Get()
        {
            return await _db.CompaniesBranches.Include(x => x.Company).ToArrayAsync();
        }
        public async Task<IEnumerable<CompanyBranches>> GetSQL()
        {
            var companyBranches = new List<CompanyBranches>();
            var connectionString = "User ID=postgres;Password=maksim444666;Host=localhost;Port=5432;Database=CompaniesTest;Pooling=true;Connection Lifetime=0;";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);
            await using (var cmd = dataSource.CreateCommand("SELECT * FROM \"CompaniesBranches\" as t1 " +
                "inner join \"Companies\" as t2 ON t1.\"CompanyId\" = t2.\"Id\""))

            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    companyBranches.Add(new CompanyBranches
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1),
                        CompanyId = reader.GetFieldValue<int>(2),
                        Company = new Company
                        {
                            Id = reader.GetFieldValue<int>(3),
                            Name = reader.GetFieldValue<string>(4),
                            BinarySign = reader.GetFieldValue<int>(5),
                        }
                    });
                }
            }

            return companyBranches;
        }
    }
}
