﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Leads;
using Services.Services;

namespace Admin.Controllers
{
    public class LeadController : Controller
    {
        private ILeadService _leadService;
        public LeadController()
        {
            _leadService = new LeadService();
        }

        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }
    }
}