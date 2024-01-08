using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class WorkOrdersRepository : IWorkOrdersRepository
    {
        private readonly ProductContext _context;
        private readonly IEstimatesRepository _estimatesRepository;
        private readonly ILeadsRepository _leadsRepository;


        public WorkOrdersRepository(ProductContext context, IEstimatesRepository estimatesRepository, ILeadsRepository leadsRepository)
        {
            _context = context;
            _estimatesRepository = estimatesRepository;
            _leadsRepository = leadsRepository; 
        }
        private void Save()
        {
            _context.SaveChanges();
        }
        public string WorkOrdersAdd(WorkOrders model)
        {
            try
            {
                var estimatesData = _estimatesRepository.GetByLeadsId(model.LeadsId);

                if (estimatesData.ReadyForWorkOrder == true)
                {
                    _context.WorkOrders.Add(model);
                    Save();
                    return "Added successfully when ReadyForWorkOrder is true!";
                }
                else
                {
                    return "You can create a work order only when ReadyForWorkOrder is true for the corresponding estimate.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditWordOrders(int id)
        {
            var previousDetails = _context.WorkOrders.FirstOrDefault(x => x.WorkOrdersId == id);
            if (previousDetails != null)
            {
                
                Save();
                return "WordOrders Completed";
            }
            else
            {
                return "WorkOrders not yet changed";
            }
        }
    }
}
