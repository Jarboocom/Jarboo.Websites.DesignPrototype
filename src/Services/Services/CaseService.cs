using System;
using System.Collections.Generic;
using System.Linq;
using Services.Database;
using Services.Domain.Case;
using Services.Services.Caching;

namespace Services.Services
{
    public class CaseService:ICaseService
    {
        private JarbooContext db = new JarbooContext();


        private readonly HttpCacheService _httpCacheService;

        public CaseService(HttpCacheService httpCacheService)
        {
            _httpCacheService = httpCacheService;
        }



        public Case GetById(int id)
        {
            var cacheKey = _httpCacheService.GetCacheKey("Content", "GetBySlug", id.ToString());

            if (!_httpCacheService.ContainsKey(cacheKey))
            {
                var thelead = db.Cases.FirstOrDefault(c => c.Id == id);
                var res =  thelead;

                _httpCacheService.Create(cacheKey, res);

                return res;
            }

            return (Case) (_httpCacheService.GetById(cacheKey));

        }

        public Case GetBySlug(string slug)
        {
            var cacheKey = _httpCacheService.GetCacheKey("Content", "GetBySlug", slug);

            if (!_httpCacheService.ContainsKey(cacheKey))
            {
                var thelead = db.Cases.FirstOrDefault(c => c.Slug == slug);
              

                _httpCacheService.Create(cacheKey, thelead);

                return thelead;
            }

            return (Case)(_httpCacheService.GetById(cacheKey));

          
        }

        public Case Create(Case acase)
        {
            db.Cases.Add(acase);
            db.SaveChanges();

            return GetById(acase.Id);
        }

        public Case Update(Case acase)
        {
            var thelead = db.Cases.FirstOrDefault(c => c.Id == acase.Id);

            thelead.Title = acase.Title;
            thelead.Description = acase.Description;
            thelead.Slug = acase.Slug;
            thelead.DownloadUrl = acase.DownloadUrl;


            db.SaveChanges();

            return GetById(acase.Id);
        }

        public List<Case> GetBySpecification(CaseSpecification specification)
        {
            var cacheKey = _httpCacheService.GetCacheKey("Content", "GetBySlug", specification.ToString());

            if (!_httpCacheService.ContainsKey(cacheKey))
            {
                IQueryable<Case> cases = db.Cases;

                //if (specification.Id > 0)
                //{
                //    dbLetters = dbLetters.Where(c => c.Id == specification.Id);
                //}

                var res= cases.OrderByDescending(c => c.Id).Take(specification.Take).Skip(specification.Skip).ToList();

                _httpCacheService.Create(cacheKey, res);

                return res;
            }
            return (List<Case>) (_httpCacheService.GetById(cacheKey));

        }
    }
}