using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using CRUD_Operation.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadsRepository _leadsRepository;
        public LeadsController(ILeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;

        }

        //Create a new lead
        [HttpPost]
        public IActionResult CreateLeads(Leads model)
        {
            if (ModelState.IsValid)
            {

                _leadsRepository.LeadsAdd(model);

                return Ok("Successfully Created....!");
            }
            return BadRequest();    
        }


        // Get the all leads
        [HttpGet]
        public async Task<IEnumerable<Leads>> Get()
        {
            return await _leadsRepository.GetAll();
        }

        //get the leads by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lead = _leadsRepository.GetById(id);
            return Ok(lead);
        }

        // Edit the lead by using the id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Leads model)
        {
           

            try
            {
                await _leadsRepository.EditLeads(id, model);
                return Ok("");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
          
        }


    }
}
