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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itu.WEB.Controllers
{
    [Authorize]
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
            var response = new RolesResponseDTO();
            AgendaDetailDTO dto = await _facade.AddRole(role, ViewBag.Id);
            response.Roles = await this.RenderViewAsync("Partial/_Roles", dto, true);
            response.Workflows = await this.RenderViewAsync("Partial/_AgendaWorkflows", dto, true);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditedRoleDTO role)
        {
            var response = new RolesResponseDTO();
            AgendaDetailDTO dto = await _facade.EditRole(role, ViewBag.Id);
            response.Roles = await this.RenderViewAsync("Partial/_Roles", dto, true);
            response.Workflows = await this.RenderViewAsync("Partial/_AgendaWorkflows", dto, true);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRole(int id)
        {
            var response = new RolesResponseDTO();
            AgendaDetailDTO dto = await _facade.RemoveRole(id, ViewBag.Id);
            response.Roles = await this.RenderViewAsync("Partial/_Roles", dto, true);
            response.Workflows = await this.RenderViewAsync("Partial/_AgendaWorkflows", dto, true);
            return Ok(response);
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
        [Route("Agenda/ModelDetail/{id}/{order}")]
        public IActionResult ModelDetail(int id, int order)
        {
            return PartialView("../Model/svg", _facade.ModelDetail(id, order));
        }

        [HttpGet]
        [Route("Agenda/RemoveModel/{modelId}/{agendaId}")]
        public async Task<IActionResult> RemoveModel(int modelId, int agendaId)
        {
            await _facade.RemoveModel(modelId, agendaId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeWorfklowState(WorkflowStateDTO change)
        {
            return PartialView("Partial/_AgendaWorkflows", await _facade.ChangeWorfklowState(change));
        }
    }
}
