﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Database;
using Website.Domain.Leads;

namespace Website.Services
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
            throw new NotImplementedException();
        }

        public void Delete(Lead lead)
        {
            throw new NotImplementedException();
        }
    }
}