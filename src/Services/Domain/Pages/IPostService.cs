using System.Collections.Generic;

namespace Services.Domain.Pages
{
    public interface IPostService : IContentService
    {
        List<JarbooPage> GetBySpecifiction(PageSpecification specification);
    }
}
