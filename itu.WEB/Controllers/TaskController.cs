using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.Facades;
using Microsoft.AspNetCore.Mvc;

namespace itu.WEB.Controllers
{
    public class TaskController : BaseController
    {
        public async Task<IActionResult> Overview()
        {
            return View();
        }
    }
}
