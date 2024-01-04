using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IEstimatesRepository
    {
        public string EstimatesAdd(Estimates model);

         string LockTheEstimate(int id);
        string ChangeTheDefaultEstimate(int id);
        string EditEstimate(int id, Estimates model);
    }
}
