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
        public async Task<IActionResult> AddRole(NewRoleDTO role)
        {
            return PartialView("Partial/_Roles", await _facade.AddRole(role));
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditedRoleDTO role)
        {
            return PartialView("Partial/_Roles", await _facade.EditRole(role));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRole(int id)
        {
            return PartialView("Partial/_Roles", await _facade.RemoveRole(id));
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
    }
}
