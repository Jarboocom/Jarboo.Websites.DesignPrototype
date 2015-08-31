using System;
using System.Collections.Generic;
using System.Linq;
using Services.Database;
using Services.Domain.Case;
using Website.Domain.Case;

namespace Services.Services
{
    public class CaseService:ICaseService
    {
        private JarbooContext db = new JarbooContext();


        public Case GetById(int id)
        {
            var thelead = db.Cases.FirstOrDefault(c => c.Id == id);
            return thelead;
        }

        public Case GetBySlug(string slug)
        {
            var thelead = db.Cases.FirstOrDefault(c => c.Slug == slug);
            return thelead;
        }

        public Case Create(Case acase)
        {
            db.Cases.Add(acase);
            db.SaveChanges();

            return GetById(acase.Id);
        }

        public Case Update(Case acase)
        {
            var thelead = db.Cases.FirstOrDefault(c => c.Id == acase.Id);

            thelead.Title = acase.Title;
            thelead.Description = acase.Description;
            thelead.Slug = acase.Slug;
            thelead.DownloadUrl = acase.DownloadUrl;


            db.SaveChanges();

            return GetById(acase.Id);
        }

        public List<Case> GetBySpecification(CaseSpecification specification)
        {
            throw new NotImplementedException();
        }
    }
}