namespace Services.Domain.Leads
{
    public interface ILeadService
    {
        Lead GetById(int id);
        Lead Create(Lead lead);
        Lead Update(Lead lead);
        void Delete(Lead lead);
    }
}