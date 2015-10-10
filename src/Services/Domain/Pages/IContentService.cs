using System.Collections.Generic;

namespace Services.Domain.Pages
{
    public interface IContentService
    {
        JarbooPage GetBySlug(string slug);
        JarbooPage Create(JarbooPage page);
        JarbooPage Update(JarbooPage page);
        void Delete(JarbooPage page);

        List<JarbooPage> GetBySpecification(ContentSpecification specification);
    }
}