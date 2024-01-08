using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IWorkOrdersRepository
    {
        public string WorkOrdersAdd(WorkOrders model);
        public string EditWordOrders(int id);
    }
}
