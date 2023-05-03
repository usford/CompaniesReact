using CompaniesReact.database.Interfaces;
using CompaniesReact.database.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesBranchesController : ControllerBase
    {

        private readonly ILogger<CompaniesBranchesController> _logger;
        private readonly ICompaniesBranchesRepository _companiesBranchesRepository;

        public CompaniesBranchesController(ILogger<CompaniesBranchesController> logger,
            ICompaniesBranchesRepository companiesBranchesRepository)
        {
            _logger = logger;
            _companiesBranchesRepository = companiesBranchesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyBranches>> Get()
        {
            return await _companiesBranchesRepository.Get();
            //Аналог прямым запросом
            //return await _companiesBranchesRepository.GetSQL();
        }
    }
}