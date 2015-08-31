using System;
using System.Collections.Generic;
using Services.Domain.Case;
using Website.Domain.Case;

namespace Services.Services
{
    public class CaseService:ICaseService
    {
        public Case GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Case GetBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public Case Create(Case acase)
        {
            throw new NotImplementedException();
        }

        public Case Update(Case acase)
        {
            throw new NotImplementedException();
        }

        public List<Case> GetBySpecification(CaseSpecification specification)
        {
            throw new NotImplementedException();
        }
    }
}