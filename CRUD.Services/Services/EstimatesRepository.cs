using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class EstimatesRepository : IEstimatesRepository
    {
        private readonly ProductContext _context;
        private readonly ILeadsRepository _leadsRepository;

        public EstimatesRepository(ProductContext context , ILeadsRepository leadsRepository)
        {
            _context = context;
            _leadsRepository = leadsRepository;
        }
        private void Save()
        {
           _context.SaveChanges();
        }
        public string EstimatesAdd(Estimates model)
        {
            try
            {
                var ConvertTheEstimate = _leadsRepository.GetById(model.LeadsId);
                if(ConvertTheEstimate.IsOpportunity == true)
                {
                    
                    model.Locked = false;
                    model.DefaultEstimate = false;
                    if (model.Status == EstimateStatus.ReadyForWorkOrder)
                    {
                        model.ReadyForWorkOrder = true;
                        _context.Estimates.Add(model);
                        Save();
                        return "added successfully also Change the readyForWorkOrder True...!";
                    }
                    else
                    {
                        _context.Estimates.Add(model);
                        Save();
                        return "added successfully...!";
                    }
                }
                else
                {
                    return "You can create estimate only for Opportunity";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Estimates GetByLeadsId(int id)
        {
            return _context.Estimates.FirstOrDefault(x => x.LeadsId == id);
        }


        public string LockTheEstimate(int id)
        {
            Estimates lockedEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (lockedEstimate != null)
            {
                lockedEstimate.Locked = true;
                _context.SaveChanges();
                return "Estimate Blocked";
            }
            else
            {
                return "Estimate not found";
            }
        }


        public string EditEstimate(int id, Estimates model)
        {
            var previousDetails = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (previousDetails != null && previousDetails.Locked == false)
            {
                previousDetails.UserId = model.UserId;
                previousDetails.LeadsId = model.LeadsId;
                previousDetails.Name = model.Name;
                previousDetails.LineItemIds = model.LineItemIds;
                previousDetails.CustomerAccepted = model.CustomerAccepted;
                previousDetails.Notes = model.Notes;
                previousDetails.LocationId = model.LocationId;
                previousDetails.DefaultEstimate = model.DefaultEstimate;
                previousDetails.Type = model.Type;
                previousDetails.Number = model.Number;
                previousDetails.Status = model.Status;
                previousDetails.DateModified = model.DateModified;
                previousDetails.Fineprint = model.Fineprint;
                previousDetails.ChangeOrder = model.ChangeOrder;
                previousDetails.ReadyForWorkOrder = model.ReadyForWorkOrder;
                previousDetails.Duration = model.Duration;
                previousDetails.SignerName = model.SignerName;
                previousDetails.SignerTitle = model.SignerTitle;
                previousDetails.SignerSignature = model.SignerSignature;
                previousDetails.SignatureStyle = model.SignatureStyle;
                previousDetails.Dead = model.Dead;
                previousDetails.CreatedBy = model.CreatedBy;
                previousDetails.HidePhaseTotal = model.HidePhaseTotal;
                previousDetails.DisplayDiscountAmountOnPrintable = model.DisplayDiscountAmountOnPrintable;
                previousDetails.DateCustomerAccepted = model.DateCustomerAccepted;
                previousDetails.HideEstimateTotal = model.HideEstimateTotal;
                previousDetails.DepositAmount = model.DepositAmount;
                previousDetails.DepositAmountUnit = model.DepositAmountUnit;
                previousDetails.DepositNote = model.DepositNote;
                previousDetails.Amount = model.Amount;
                previousDetails.PaidDate = model.PaidDate;
                previousDetails.PayaVaultId = model.PayaVaultId;
                previousDetails.PaymentMethodPreview = model.PaymentMethodPreview;
                previousDetails.PayaVaultLocationId = model.PayaVaultLocationId;
                previousDetails.Token = model.Token;

                Save();

                return "Estimate Updated";
            }

            else
            {

                return "Estimate Blocked";
            }
        }

        public string ChangeTheDefaultEstimate(int id)
        {
            Estimates DefaultEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (DefaultEstimate != null && DefaultEstimate.Locked == false)
            {
                DefaultEstimate.DefaultEstimate = true;
                _context.SaveChanges();
                return "Default Estimate Changed";
            }
            else
            {
                return "Default Estimate not changed because of locked";
            }
        }

       
    }
}
