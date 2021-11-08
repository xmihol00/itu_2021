using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task;
using itu.BL.Facades;
using itu.WEB.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;

namespace itu.WEB.Controllers
{
    [Authorize]
    public class TaskController : BaseController
    {
        private readonly TaskFacade _facade;
        private readonly IHubContext<TaskNotificationHub> _hubContext;

        public TaskController(TaskFacade facade, IHubContext<TaskNotificationHub> hubContext, BaseFacade baseFacade) : base(baseFacade)
        {
            _hubContext = hubContext;
            _facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> Overview(int id)
        {
            return View(await _facade.ActiveOfUser(ViewBag.Id, id));
        }

        [HttpGet]
        public async Task<IActionResult> Solved(int id)
        {
            return View(await _facade.SolvedOfUser(ViewBag.Id, id));
        }

        [HttpGet]
        public async Task<IActionResult> Delayed()
        {
            throw new NotImplementedException();
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
                SolvedDTO solved = await _facade.AssignmentSolve(ViewBag.Id, assignment);
                if (solved.NextUserId != 0)
                {
                    await _hubContext.Clients
                                    .Group(solved.NextUserId.ToString())
                                    .SendAsync("NewTask", await this.RenderViewAsync("Partial/_TaskAlert", solved.CreatedTask));
                }
                return PartialView("Overview", solved.Overview);
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
                SolvedDTO solved = await _facade.AcceptationSolve(ViewBag.Id, acceptation);
                if (solved.NextUserId != 0)
                {
                    await _hubContext.Clients
                                    .Group(solved.NextUserId.ToString())
                                    .SendAsync("NewTask", await this.RenderViewAsync("Partial/_TaskAlert", solved.CreatedTask));
                }
                return PartialView("Overview", solved.Overview);
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
                SolvedDTO solved = await _facade.AssessmentSolve(ViewBag.Id, assessment);
                if (solved.NextUserId != 0)
                {
                    await _hubContext.Clients
                                    .Group(solved.NextUserId.ToString())
                                    .SendAsync("NewTask", await this.RenderViewAsync("Partial/_TaskAlert", solved.CreatedTask));
                }
                return PartialView("Overview", solved.Overview);
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
                SolvedDTO solved = await _facade.EstimateSolve(ViewBag.Id, estimate);
                if (solved.NextUserId != 0)
                {
                    await _hubContext.Clients
                                    .Group(solved.NextUserId.ToString())
                                    .SendAsync("NewTask", await this.RenderViewAsync("Partial/_TaskAlert", solved.CreatedTask));
                }
                return PartialView("Overview", solved.Overview);
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
                SolvedDTO solved = await _facade.ContractSolve(ViewBag.Id, contract);
                if (solved.NextUserId != 0)
                {
                    await _hubContext.Clients
                                    .Group(solved.NextUserId.ToString())
                                    .SendAsync("NewTask", await this.RenderViewAsync("Partial/_TaskAlert", solved.CreatedTask));
                }
                return PartialView("Overview", solved.Overview);
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
                SolvedDTO solved = await _facade.PublicationSolve(ViewBag.Id, publish);
                if (solved.NextUserId != 0)
                {
                    await _hubContext.Clients
                                    .Group(solved.NextUserId.ToString())
                                    .SendAsync("NewTask", await this.RenderViewAsync("Partial/_TaskAlert", solved.CreatedTask));
                }
                return PartialView("Overview", solved.Overview);
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
                SolvedDTO solved = await _facade.ArchivationSolve(ViewBag.Id, archivation);
                if (solved.NextUserId != 0)
                {
                    await _hubContext.Clients
                                    .Group(solved.NextUserId.ToString())
                                    .SendAsync("NewTask", await this.RenderViewAsync("Partial/_TaskAlert", solved.CreatedTask));
                }
                return PartialView("Overview", solved.Overview);
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
