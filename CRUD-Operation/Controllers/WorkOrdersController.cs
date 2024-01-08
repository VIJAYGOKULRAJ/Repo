using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrdersController : ControllerBase
    {
        private readonly IWorkOrdersRepository _workOrdersRepository;
        public WorkOrdersController(IWorkOrdersRepository workOrdersRepository)
        {
            _workOrdersRepository = workOrdersRepository;

        }
        //Create a new Workorder
          [HttpPost]
          public IActionResult CreateWorkOrders(WorkOrders model)
          {
              if (ModelState.IsValid)
              {

                var result = _workOrdersRepository.WorkOrdersAdd(model);

                  return Ok(result);
              }
              return BadRequest();    
          }


        [HttpPut]
        public IActionResult EditWordOrders(int id)
        {
            if (ModelState.IsValid)
            {

                var result = _workOrdersRepository.EditWordOrders(id);

                return Ok(result);
            }
            return BadRequest();
        }

    }
}
