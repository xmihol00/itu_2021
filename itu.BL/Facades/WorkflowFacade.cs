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

            foreach (var workflow in overview.AllWorkflow)
            {
                workflow.ExpectedEnd = workflow.CurrentTask.End;
                foreach (var task in workflow.ModelWorkflow.WorkflowTasks)
                {
                    workflow.ExpectedEnd.AddDays(task.ModelTask.Difficulty);
                }
            }
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
            bool filterSet = false;
            List<AllWorkflowDTO> allWorkflows = new List<AllWorkflowDTO>();
            if (search.AgendaIds != null && search.AgendaIds.Count > 0)
            {
                allWorkflows.AddRange(_mapper.Map<List<AllWorkflowDTO>>(_workflow.GetWorkflowsByAgenda(search.AgendaIds)));
                filterSet = true;
            }

            if (search.WorkflowModelsIds != null && search.WorkflowModelsIds.Count > 0)
            {
                allWorkflows.AddRange(_mapper.Map<List<AllWorkflowDTO>>(_workflow.GetWorkflowsByModel(search.WorkflowModelsIds)));
                filterSet = true;
            }


            //allWorkflows.AddRange(_workflow.GetWorkflowsByTask(search.TaskNames));
            if(search.SearchString != null && search.SearchString.Length != 0)
            {
                if(filterSet == false)
                {
                    allWorkflows.AddRange(_mapper.Map<List<AllWorkflowDTO>>(_workflow.GetAllWorkflows().Result));
                }   
                allWorkflows = allWorkflows.Where(x => x.Name.Contains(search.SearchString)).ToList();
            }
            else
            {
                if (filterSet == false)
                {
                    allWorkflows.AddRange(_mapper.Map<List<AllWorkflowDTO>>(_workflow.GetAllWorkflows().Result));
                }
            }


            foreach (var workflow in allWorkflows)
            {
                workflow.CurrentTask = workflow.Tasks.FirstOrDefault(x => x.Active == true);
            }
            allWorkflows = allWorkflows.Distinct(new ItemEqualityComparer()).ToList();
            
            foreach(var workflow in allWorkflows)
            {
                workflow.ExpectedEnd = workflow.CurrentTask.End;
                foreach(var task in workflow.ModelWorkflow.WorkflowTasks)
                {
                    workflow.ExpectedEnd.AddDays(task.ModelTask.Difficulty);
                }
            }
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
                if (workflow.CurrentTask != null && !search.ActiveTasks.Contains(new IdTypeTaskDTO() { Id = workflow.CurrentTask.Id }))
                {
                    search.ActiveTasks.Add(_mapper.Map<IdTypeTaskDTO>(workflow.CurrentTask));
                }
                if (workflow.Agenda != null && !search.Agendas.Contains(new IdNameAgendaDTO() { Id = workflow.Agenda.Id }))
                {
                    search.Agendas.Add(_mapper.Map<IdNameAgendaDTO>(workflow.Agenda));
                }
                if(!search.WorkflowModels.Contains(new IdNameModelDTO { Id = workflow.ModelWorkflow.Id }))
                {
                    search.WorkflowModels.Add(_mapper.Map<IdNameModelDTO>(workflow.ModelWorkflow));
                }
            }

            search.ActiveTasks = search.ActiveTasks.Distinct(new IdTypeTaskDTOEqualityComparer()).ToList();
            search.Agendas = search.Agendas.Distinct(new IdNameAgendaDTOEqualityComparer()).ToList();
            search.WorkflowModels= search.WorkflowModels.Distinct(new IdNameModelDTOEqualityComparer()).ToList();

            return search;

        }
    }
}
