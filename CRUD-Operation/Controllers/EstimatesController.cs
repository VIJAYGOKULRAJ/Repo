using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimatesController : ControllerBase
    {
        private readonly IEstimatesRepository _estimatesRepository;
        public EstimatesController(IEstimatesRepository estimatesRepository )
        {
            _estimatesRepository = estimatesRepository;
        }
        // create estimate
        [HttpPost]
        public IActionResult CreateEstimates(Estimates model)
        {
            var result = _estimatesRepository.EstimatesAdd(model);
            return Ok(result);
        }
    }
}
