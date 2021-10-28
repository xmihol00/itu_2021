﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itu.WEB.Controllers
{
    [Authorize]
    public class TaskController : BaseController
    {
        private readonly TaskFacade _facade;

        public TaskController(TaskFacade facade)
        {
            _facade = facade;
        }

        public async Task<IActionResult> Overview()
        {
            return View(await _facade.AllOfUser(ViewBag.Id));
        }

        public async Task<IActionResult> Detail(int id)
        {
            return PartialView(await _facade.Detail(ViewBag.Id, id));
        }
    }
}
