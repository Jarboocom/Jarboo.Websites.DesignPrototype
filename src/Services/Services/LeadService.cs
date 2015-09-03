using System;
using System.Collections.Generic;
using System.Linq;
using Services.Database;
using Services.Domain.Leads;

namespace Services.Services
{
    public class LeadService: ILeadService
    {
        private readonly JarbooContext _db = new JarbooContext();

        public Lead GetById(int id)
        {
            var lead = _db.Leads.FirstOrDefault(c => c.Id == id);

            return lead;
        }

        public Lead Create(Lead lead)
        {
            lead.DateCreated = DateTime.Now;
            lead.DateUpdated = DateTime.Now;
            lead.LeadStatus = LeadStatus.New;

            _db.Leads.Add(lead);
            _db.SaveChanges();

            return lead;
        }

        public Lead Update(Lead lead)
        {
            var thelead = _db.Leads.FirstOrDefault(c => c.Id ==lead.Id);

            if (thelead != null)
            {
                thelead.DateUpdated = DateTime.Now;
                thelead.LeadStatus = lead.LeadStatus;

                _db.SaveChanges();
            }

            return thelead;
        }

        public void Delete(Lead lead)
        {
            var thelead = _db.Leads.FirstOrDefault(c => c.Id == lead.Id);

            _db.Leads.Remove(thelead);
            _db.SaveChanges();
        }

        public List<Lead> GetBySpecification(LeadSpecification specification)
        {
            IQueryable<Lead> cases = _db.Leads;

            //if (specification.Id > 0)
            //{
            //    dbLetters = dbLetters.Where(c => c.Id == specification.Id);
            //}

            return cases.OrderBy(c => c.Id).Take(specification.Take).Skip(specification.Skip).ToList();
        }
    }
}