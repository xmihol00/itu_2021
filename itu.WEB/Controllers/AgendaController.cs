using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.Facades;
using Microsoft.AspNetCore.Mvc;

namespace itu.WEB.Controllers
{
    public class AgendaController : BaseController
    {
        private readonly AgendaFacade _facade;
        public AgendaController(AgendaFacade facade, BaseFacade baseFacade) : base(baseFacade)
        {
            _facade = facade;
        }

        public async Task<IActionResult> Overview()
        {
            return View(await _facade.All());
        }

        public async Task<IActionResult> Detail(int id)
        {
            return View(await _facade.Detail(id));
        }
    }
}
