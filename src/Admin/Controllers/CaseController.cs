﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Case;
using Services.Domain.Leads;
using Services.Services;

namespace Admin.Controllers
{
    public class CaseController : Controller
    {
        private ICaseService _caseService;
        public CaseController()
        {
            _caseService = new CaseService();
        }

        // GET: Case

        [HttpGet]
        public ActionResult NewCase()
        {
            return View(new Case());
        }

        [HttpPost]
        public ActionResult NewCase(Case newcase)
        {
            if (ModelState.IsValid)
            {
                CaseService caseService = new CaseService();
                caseService.Create(newcase);
            }
            else
            {
                return View(newcase);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCase(int id)
        {
            if (id != null)
            {
                CaseService caseService = new CaseService();
                Case caseToEdit = caseService.GetById(id);
                if (caseToEdit != null)
                    return View(caseToEdit);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCase(Case newcase)
        {
            if (ModelState.IsValid)
            {
                CaseService caseService = new CaseService();
                if (caseService.GetById(newcase.Id) != null)
                {
                    caseService.Update(newcase);
                }
            }
            else
            {
                return View(newcase);
            }
            return RedirectToAction("Index");
        }
    }
}