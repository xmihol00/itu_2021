using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

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

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            return View(await _facade.AllOfUser(ViewBag.Id));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            return PartialView(await _facade.Detail(ViewBag.Id, id));
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int id)
        {
            try
            {
                IDbContextTransaction transaction = await _facade.Transaction();
                foreach(IFormFile file in Request.Form.Files)
                {
                    await _facade.Upload(id, file.FileName, file.OpenReadStream());
                }
                await transaction.CommitAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return Json("error" + e.Message);
            }
        }
    }
}
