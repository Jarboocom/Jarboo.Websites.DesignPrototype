using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Domain.Case
{
    public interface ICaseService
    {
        Case GetById(int id);
        Case GetBySlug(string slug);

    }
}