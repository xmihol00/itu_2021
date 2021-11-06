using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.DTOs.File;
using itu.BL.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace itu.WEB.Controllers
{
    [Authorize]
    public class FileController : BaseController
    {
        private readonly FileFacade _facade;

        public FileController(FileFacade facade, BaseFacade baseFacade) : base(baseFacade)
        {
            _facade = facade;
        }

        [Route("/File/Upload/{taskId}")]
        [HttpPost]
        public async Task<IActionResult> Upload(int taskId)
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                return PartialView("Partial/_Files", await _facade.Upload(taskId, file));
            }
            catch (Exception e)
            {
                return Json("Error: " + e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return PartialView("Partial/_Files", await _facade.Delete(id));
            }
            catch (Exception e)
            {
                return Json("Error: " + e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Download(int id)
        {
            try
            {
                DownloadFileDTO file = await _facade.Download(id);
                return File(file.Data, file.MIME, file.Name);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeVersion(VersionChangeDTO data)
        {
            try
            {
                return PartialView("Partial/_Files", await _facade.ChnageVersion(data));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
