using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Domain.Pages
{
    public interface IContentService
    {
        JarbooPage GetBySlug(string slug);
        JarbooPage Create(JarbooPage page);
        JarbooPage Update(JarbooPage page);
        void Delete(JarbooPage page);
    }
}