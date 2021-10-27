using System;
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
        public async Task<IActionResult> Overview()
        {
            return View();
        }
    }
}
