using System;
using System.Collections.Generic;
using System.Linq;
using Services.Database;
using Services.Domain.Leads;

namespace Services.Services
{
    public class LeadService: ILeadService
    {
        private JarbooContext db = new JarbooContext();

        public Lead GetById(int id)
        {
            var lead = db.Leads.FirstOrDefault(c => c.Id == id);

            return lead;
        }

        public Lead Create(Lead lead)
        {
            lead.DateCreated = DateTime.Now;
            lead.DateUpdated = DateTime.Now;
            lead.LeadStatus = LeadStatus.New;

            db.Leads.Add(lead);
            db.SaveChanges();

            return GetById(lead.Id);
        }

        public Lead Update(Lead lead)
        {
            var thelead = db.Leads.FirstOrDefault(c => c.Id ==lead.Id);

            
            thelead.DateUpdated = DateTime.Now;
            thelead.LeadStatus = lead.LeadStatus;
            
            db.SaveChanges();

            return GetById(lead.Id);
        }

        public void Delete(Lead lead)
        {
            var thelead = db.Leads.FirstOrDefault(c => c.Id == lead.Id);

            db.Leads.Remove(thelead);
            db.SaveChanges();
        }

        public List<Lead> GetBySpecification(LeadSpecification specification)
        {
            IQueryable<Lead> cases = db.Leads;

            //if (specification.Id > 0)
            //{
            //    dbLetters = dbLetters.Where(c => c.Id == specification.Id);
            //}

            return cases.OrderBy(c => c.Id).Take(specification.Take).Skip(specification.Skip).ToList();
        }
    }
}