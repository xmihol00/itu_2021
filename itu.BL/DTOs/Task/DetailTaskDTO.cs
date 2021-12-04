//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class DetailTaskDTO : IDetailTaskDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string WorkflowName { get; set; }
        public string AgendaName { get; set; }
        public string Note { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PriorityEnum Priority { get; set; }
        public string DelayReason { get; set; }
        public bool Active { get; set; }
        public int WorkflowId { get; set; }
        public int AgendaId { get; set; }
        public List<AllFileDTO> Files { get; set; }

        public string ToAction()
        {
            switch (this)
            {
                case IAcceptationDTO:
                    return "Acceptation";
                
                case IArchivationDTO:
                    return "Archivation";
                
                case IAssessmentDTO:
                    return "Assessment";
                
                case IAssignmentDTO:
                    return "Assignment";

                case IContractDTO:
                    return "Contract";
                
                case IEstimateDTO:
                    return "Estimate";
                
                case IPublishDTO:
                    return "Publication";

                default:
                    return "Unknown";
            }
        }

        public string ToLabel()
        {
            switch (this)
            {
                case IAcceptationDTO:
                    return "Schválení";
                
                case IArchivationDTO:
                    return "Archivace";
                
                case IAssessmentDTO:
                    return "Posouzení";
                
                case IAssignmentDTO:
                    return "Zadání";

                case IContractDTO:
                    return "Tvorba smlouvy";
                
                case IEstimateDTO:
                    return "Odhad ceny";
                
                case IPublishDTO:
                    return "Zveřejnění";

                default:
                    return "Unknown";
            }
        }
    }
}
