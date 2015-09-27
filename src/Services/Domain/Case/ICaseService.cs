using System.Collections.Generic;

namespace Services.Domain.Case
{
    public interface ICaseService
    {
        Case GetById(int id);
        Case GetBySlug(string slug);

        Case Create(Case acase);
        Case Update(Case acase);

        List<Case> GetBySpecification(CaseSpecification specification);
    }
}