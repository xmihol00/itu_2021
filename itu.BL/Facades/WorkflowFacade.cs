using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.Task;
using itu.BL.DTOs.Workflow;
using itu.BL.DTOs.Workflow.Search;
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
        private readonly IMapper _mapper;
        public WorkflowFacade(WorkflowRepository workflow, TaskRepository tasks, AgendaRepository agendas, IMapper mapper)
        {
            _workflow = workflow;
            _tasks = tasks;
            _agendas = agendas;
            _mapper = mapper;
        }
        public async Task<OverviewWorkflowDTO> GetOverview()
        {
            OverviewWorkflowDTO overview = new OverviewWorkflowDTO();

            overview.AllWorkflow = _mapper.Map<List<AllWorkflowDTO>>(await _workflow.GetAllWorkflows());

            foreach (var workflow in overview.AllWorkflow)
            {
                workflow.CurrentTask = workflow.Tasks.FirstOrDefault(x => x.Active == true);
            }

            overview.SearchOptions = new SearchDTO();
            overview.SearchOptions.ActiveTasks = _mapper.Map<List<IdTypeTaskDTO>>(await _tasks.GetActive());
            overview.SearchOptions.Agendas = _mapper.Map<List<IdNameAgendaDTO>>(await _agendas.All());
            overview.SearchOptions.WorkflowModels = _mapper.Map<List<IdNameModelDTO>>(await _workflow.GetAllModels());

            return overview;
        }


        public async Task<DetailWorkflowDTO> GetDetail(int id)
        {
            DetailWorkflowDTO detail = new DetailWorkflowDTO();
            detail = _mapper.Map<DetailWorkflowDTO>(await _workflow.GetDetail(id));

            List<int> taskIds = new List<int>();
            detail.Tasks.ForEach(x => taskIds.Add(x.Id));
            detail.Tasks = new List<DetailTaskDTO>();

            foreach (int taskId in taskIds)
            {
                detail.Tasks.Add(_mapper.Map<DetailTaskDTO>(await _tasks.Detail(taskId)));
            }
            return detail;
        }

        public List<AllWorkflowDTO> GetOverviewFiltered(WorkflowSearchDTO search)
        {
            List<AllWorkflowDTO> allWorkflows = new List<AllWorkflowDTO>();
            if (search.AgendaNames != null && search.AgendaNames.Count > 0)
            {
                allWorkflows.AddRange(_mapper.Map<List<AllWorkflowDTO>>(_workflow.GetWorkflowsByAgenda(search.AgendaNames)));
            }

            if (search.WorkflowModelsNames != null && search.WorkflowModelsNames.Count > 0)
            {
                allWorkflows.AddRange(_mapper.Map<List<AllWorkflowDTO>>(_workflow.GetWorkflowsByModel(search.WorkflowModelsNames)));
            }

            foreach(var workflow in allWorkflows)
            {
                workflow.CurrentTask = workflow.Tasks.FirstOrDefault(x => x.Active == true);
            }

            //allWorkflows.AddRange(_workflow.GetWorkflowsByTask(search.TaskNames));

            return allWorkflows;
        }

        public async Task<SearchDTO> GetFiltersFiltered(List<AllWorkflowDTO> workflows)
        {
            SearchDTO search = new SearchDTO();
            search.ActiveTasks = new List<IdTypeTaskDTO>();
            search.Agendas = new List<IdNameAgendaDTO>();
            search.WorkflowModels = new List<IdNameModelDTO>();
            foreach (var workflow in workflows)
            {
                if (workflow.CurrentTask != null)
                {
                    search.ActiveTasks.Add(_mapper.Map<IdTypeTaskDTO>(workflow.CurrentTask));
                }
                if (workflow.Agenda != null)
                {
                    search.Agendas.Add(_mapper.Map<IdNameAgendaDTO>(workflow.Agenda));
                }
                search.WorkflowModels.Add(_mapper.Map<IdNameModelDTO>(await _workflow.GetWorkflowModel(workflow.Id)));
            }

            return search;

        }
    }
}
