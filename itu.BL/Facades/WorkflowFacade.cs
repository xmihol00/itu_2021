//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================

using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.Task;
using itu.BL.DTOs.Workflow;
using itu.BL.DTOs.Workflow.Search;
using itu.Common.Enums;
using itu.DAL.Entities;
using itu.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.Facades
{
    public class WorkflowFacade
    {
        private readonly WorkflowRepository _workflow;
        private readonly AgendaRepository _agendas;
        private readonly TaskRepository _tasks;
        private readonly ModelWorkflowRepository _modelWorkflow;
        private readonly IMapper _mapper;
        public WorkflowFacade(WorkflowRepository workflow, TaskRepository tasks, AgendaRepository agendas, 
                              ModelWorkflowRepository modelWorkflow, IMapper mapper)
        {
            _workflow = workflow;
            _tasks = tasks;
            _agendas = agendas;
            _modelWorkflow = modelWorkflow;
            _mapper = mapper;
        }
        public async Task<OverviewWorkflowDTO> GetOverview()
        {
            OverviewWorkflowDTO overview = new OverviewWorkflowDTO();

            overview.AllWorkflow = _mapper.Map<List<AllWorkflowDTO>>(await _workflow.GetAllWorkflows());
            overview.SearchOptions = new SearchDTO();

            foreach (var workflow in overview.AllWorkflow)
            {
                workflow.CurrentTask = workflow.Tasks.FirstOrDefault(x => x.Active == true);
            }
          
            overview.SearchOptions.States = new List<WorkflowStateEnum>(){ 
                WorkflowStateEnum.Active, 
                WorkflowStateEnum.Stopped, 
                WorkflowStateEnum.Finished, 
                WorkflowStateEnum.Canceled 
            };
            overview.SearchOptions.Agendas = _mapper.Map<List<IdNameAgendaDTO>>(await _agendas.All());
            overview.SearchOptions.WorkflowModels = _mapper.Map<List<IdNameModelDTO>>(await _workflow.GetAllModels());

            return overview;
        }

        public async Task<DetailWorkflowDTO> GetDetail(int id)
        {
            DetailWorkflowDTO detail = new DetailWorkflowDTO();
            WorkflowEntity wf = await _workflow.GetDetail(id);
            detail = _mapper.Map<DetailWorkflowDTO>(wf);

            List<int> taskIds = new List<int>();
            detail.Tasks.ForEach(x => taskIds.Add(x.Id));
            detail.Tasks = new List<DetailTaskDTO>();
            detail.CurrentTask = (await _workflow.GetCurrentTask(id));
            detail.ModelWorkflowIdName = new IdNameModelDTO() { Id= detail.ModelWorkflow.Id, Name = detail.ModelWorkflow.Name };
            detail.ExpectedEnd = detail.CurrentTask?.End.AddDays(_modelWorkflow.RemainingDificulty(wf.ModelWorkflowId, detail.CurrentTask.Order)) ?? DateTime.MaxValue; 

            foreach (int taskId in taskIds)
            {
                detail.Tasks.Add(_mapper.Map<DetailTaskDTO>(await _tasks.Detail(taskId)));
            }
            return detail;
        }

        public async Task<List<AllWorkflowDTO>> GetOverviewFiltered(WorkflowSearchDTO search)
        {
            IEnumerable<AllWorkflowDTO> allWorkflows;
            if (search.AgendaIds != null && search.AgendaIds.Count > 0 && search.WorkflowModelsIds != null && search.WorkflowModelsIds.Count > 0)
            {
                allWorkflows = _mapper.Map<List<AllWorkflowDTO>>(_workflow.GetWorkflowsByAgenda(search.AgendaIds));
                allWorkflows = allWorkflows.Where(x => search.WorkflowModelsIds.Contains(x.ModelWorkflow.Id));
            }
            else if (search.AgendaIds != null && search.AgendaIds.Count > 0)
            {
                allWorkflows = _mapper.Map<List<AllWorkflowDTO>>(_workflow.GetWorkflowsByAgenda(search.AgendaIds));
            }
            else if (search.WorkflowModelsIds != null && search.WorkflowModelsIds.Count > 0)
            {
                allWorkflows = _mapper.Map<List<AllWorkflowDTO>>(_workflow.GetWorkflowsByModel(search.WorkflowModelsIds));
            }
            else
            {
                allWorkflows = _mapper.Map<List<AllWorkflowDTO>>(await _workflow.GetAllWorkflows());
            }

            if (search.SearchString != null && search.SearchString.Length != 0)
            {
                allWorkflows = allWorkflows.Where(x => x.Name.Contains(search.SearchString));
            }
            
            if (search.States != null && search.States.Count != 0)
            {
                allWorkflows = allWorkflows.Where(x => search.States.Contains(x.State));
            }

            foreach (var workflow in allWorkflows)
            {
                workflow.CurrentTask = workflow.Tasks.FirstOrDefault(x => x.Active == true);
            }

            return allWorkflows.ToList();
        }

        public async Task<SearchDTO> GetFilters()
        {
            SearchDTO search = new SearchDTO();
            search.States = new List<WorkflowStateEnum>(){ 
                WorkflowStateEnum.Active, 
                WorkflowStateEnum.Stopped, 
                WorkflowStateEnum.Finished, 
                WorkflowStateEnum.Canceled 
            };
            search.Agendas = _mapper.Map<List<IdNameAgendaDTO>>(await _agendas.All());
            search.WorkflowModels = _mapper.Map<List<IdNameModelDTO>>(await _workflow.GetAllModels());

            return search;
        }
    }
}
