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
        public AgendaController(BaseFacade baseFacade) : base(baseFacade)
        {
            
        }

        public async Task<IActionResult> Overview()
        {
            return View();
        }
    }
}
