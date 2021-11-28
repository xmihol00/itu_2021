using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.DTOs.Workflow;
using itu.BL.DTOs.Workflow.Search;
using itu.BL.Facades;
using Microsoft.AspNetCore.Mvc;
using OpenData_BL.DTOs.DataSet.Search;

namespace itu.WEB.Controllers
{
    public class WorkflowController : BaseController
    {
        private readonly WorkflowFacade _workflow;
        public WorkflowController(BaseFacade baseFacade, WorkflowFacade workflow) : base(baseFacade)
        {
            _workflow = workflow;
        }

        public async Task<IActionResult> Overview()
        {
            OverviewWorkflowDTO overview = await _workflow.GetOverview();
            return View(overview);
        }

        [HttpGet]
        [Route("Workflow/Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            DetailWorkflowDTO detail = new DetailWorkflowDTO();

            detail = await _workflow.GetDetail(id);
            return View(detail);
        }

        [HttpPost]
        public async Task<IActionResult> FilterSelected(WorkflowSearchDTO filters)
        {
            SearchResultDTO result = new SearchResultDTO();
            OverviewWorkflowDTO overview = new OverviewWorkflowDTO();
            overview.AllWorkflow =  await _workflow.GetOverviewFiltered(filters);
            overview.SearchOptions = await _workflow.GetFiltersFiltered(overview.AllWorkflow);

            Task<string> filtersTask = this.RenderViewAsync("Partial/_FilterLists", overview.SearchOptions);
            Task<string> workflowTask = this.RenderViewAsync("Partial/_Workflows", overview.AllWorkflow);

            result.WorkflowsHTML = await workflowTask;
            result.FiltersHTML = await filtersTask;
            return Ok(result);

        }

    }
}
