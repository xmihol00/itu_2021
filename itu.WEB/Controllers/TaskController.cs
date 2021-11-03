using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task;
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
        public async Task<IActionResult> AssignmentSolve(AssignmentPostDTO assignment)
        {
            try
            {
                await _facade.AssignmentSolve(ViewBag.Id, assignment);
                return Redirect($"/Task/Overview/");
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignmentSave(AssignmentPostDTO assignment)
        {
            try
            {
                return PartialView("Detail", await _facade.AssignmentSave(ViewBag.Id, assignment));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AcceptationSolve(AcceptationPostDTO acceptation)
        {
            try
            {
                await _facade.AcceptationSolve(ViewBag.Id, acceptation);
                return Redirect($"/Task/Overview/");
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AcceptationSave(AcceptationPostDTO acceptation)
        {
            try
            {
                return PartialView("Detail", await _facade.AcceptationSave(ViewBag.Id, acceptation));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssessmentSolve(AssessmentPostDTO assessment)
        {
            try
            {
                await _facade.AssessmentSolve(ViewBag.Id, assessment);
                return Redirect($"/Task/Overview/");
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssessmentSave(AssessmentPostDTO assessment)
        {
            try
            {
                return PartialView("Detail", await _facade.AssessmentSave(ViewBag.Id, assessment));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> EstimateSolve(EstimatePostDTO estimate)
        {
            try
            {
                await _facade.EstimateSolve(ViewBag.Id, estimate);
                return Redirect($"/Task/Overview/");
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> EstimateSave(EstimatePostDTO estimate)
        {
            try
            {
                return PartialView("Detail", await _facade.EstimateSave(ViewBag.Id, estimate));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ContractSolve(ContractPostDTO contract)
        {
            try
            {
                await _facade.ContractSolve(ViewBag.Id, contract);
                return Redirect($"/Task/Overview/");
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ContractSave(ContractPostDTO contract)
        {
            try
            {
                return PartialView("Detail", await _facade.ContractSave(ViewBag.Id, contract));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PublicationSolve(PublishPostDTO publish)
        {
            try
            {
                await _facade.PublicationSolve(ViewBag.Id, publish);
                return Redirect($"/Task/Overview/");
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PublicationSave(PublishPostDTO publish)
        {
            try
            {
                return PartialView("Detail", await _facade.PublicationSave(ViewBag.Id, publish));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ArchivationSolve(ArchivationPostDTO archivation)
        {
            try
            {
                await _facade.ArchivationSolve(ViewBag.Id, archivation);
                return Redirect($"/Task/Overview/");
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ArchivationSave(ArchivationPostDTO archivation)
        {
            try
            {
                return PartialView("Detail", await _facade.ArchivationSave(ViewBag.Id, archivation));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
