namespace Services.Domain.Case
{
    public interface ICaseService
    {
        Website.Domain.Case.Case GetById(int id);
        Website.Domain.Case.Case GetBySlug(string slug);

    }
}