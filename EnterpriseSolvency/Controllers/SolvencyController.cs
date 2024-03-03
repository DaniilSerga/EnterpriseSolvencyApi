using Microsoft.AspNetCore.Mvc;
using EnterpriseSolvency.BusinessLogic.Services.Contracts;
using EnterpriseSolvency.Model.Models;

namespace EnterpriseSolvency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolvencyController(ISolvencyService solvencyService) : Controller
    {
        private readonly ISolvencyService _solvencyService = solvencyService;

        // GET: api/Cars/5
        [HttpGet]
        public ActionResult<IEnumerable<SolvencyResult>> Get()
        {
            return Ok(_solvencyService.GetSolvencyHistory());
        }

        [HttpPost]
        public IActionResult Create(SolvencyResult solvencyResult)
        {
            ArgumentNullException.ThrowIfNull(solvencyResult);
            _solvencyService.CreateSolvency(solvencyResult);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _solvencyService.DeleteSolvency(id);
            return Ok();
        }
    }
}
