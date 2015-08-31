using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace Services.Domain.Case
{
    public interface ICaseService
    {
        Website.Domain.Case.Case GetById(int id);
        Website.Domain.Case.Case GetBySlug(string slug);

        Website.Domain.Case.Case Create(Website.Domain.Case.Case acase);
        Website.Domain.Case.Case Update(Website.Domain.Case.Case acase);

        List<Website.Domain.Case.Case> GetBySpecification(CaseSpecification specification);


    }
}