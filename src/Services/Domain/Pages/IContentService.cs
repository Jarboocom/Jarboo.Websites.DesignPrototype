namespace Services.Domain.Pages
{
    public interface IContentService
    {
        JarbooPage GetBySlug(string slug);
        JarbooPage Create(JarbooPage page);
        JarbooPage Update(JarbooPage page);
        void Delete(JarbooPage page);
    }
}