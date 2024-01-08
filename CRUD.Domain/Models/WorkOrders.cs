using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class WorkOrders
    {
        [Key]
        public int WorkOrdersId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Leads")]
        public int LeadsId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }
        public string LineItemIds { get; set; }
        public string Owner { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Notes { get; set; }
        public bool? Scheduled { get; set; }
        public string LocationId { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public string StatusHistory { get; set; }
        public bool? NotifySalesman { get; set; }
        public bool? NotifyAccounting { get; set; }
        public decimal? LaborAmount { get; set; }
        public bool? PartialWorkOrder { get; set; }
        public bool? DisplayLaborAmount { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string LaborAmountType { get; set; }
        public bool? AllowInvoiceBeforeComplete { get; set; }
        public DateTime? TentativeDate { get; set; }
        public bool HourlyOnlyLaborCost { get; set; }
    }
}
