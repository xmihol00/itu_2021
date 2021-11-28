//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
//=================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.DTOs.Agenda;
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

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            return View(await _facade.All());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _facade.Detail(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgendaCreateDTO model)
        {
            await _facade.Create(model, ViewBag.Id);
            return Redirect("/Agenda/Overview");
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(NewRoleDTO role)
        {
            return PartialView("Partial/_Roles", await _facade.AddRole(role, ViewBag.Id));
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditedRoleDTO role)
        {
            return PartialView("Partial/_Roles", await _facade.EditRole(role, ViewBag.Id));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRole(int id)
        {
            return PartialView("Partial/_Roles", await _facade.RemoveRole(id, ViewBag.Id));
        }

        [HttpPost]
        public async Task<IActionResult> EditData(EditDataDTO data)
        {
            await _facade.EditData(data);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> EditAdmin(EditAdminDTO admin)
        {
            await _facade.EditAdmin(admin);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> NewModels(int id)
        {
            return PartialView("Partial/_AddModel", await _facade.NewModels(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(AddModelDTO dto)
        {
            await _facade.AddModel(dto);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RunWorkflow(RunWorkflowDTO dto)
        {
            await _facade.RunWorkflow(dto);
            return Redirect($"/Agenda/Detail/{dto.AgendaId}");
        }

        [HttpGet]
        public IActionResult ModelDetail(int id)
        {
            return PartialView("../Model/svg", _facade.ModelDetail(id));
        }

        [HttpGet]
        [Route("Agenda/RemoveModel/{modelId}/{agendaId}")]
        public async Task<IActionResult> RemoveModel(int modelId, int agendaId)
        {
            await _facade.RemoveModel(modelId, agendaId);
            return Ok();
        }
    }
}
