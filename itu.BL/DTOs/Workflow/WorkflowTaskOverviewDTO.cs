//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================
using itu.DAL.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Workflow
{
    public class WorkflowTaskOverviewDTO
    {
        public int Id { get; set; }
        public DateTime End { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string ToLabel()
        {
            Type type = this.GetType();

            if (type == typeof(AcceptationEntity))
            {
                return "Schválení";
            }
            else if (type == typeof(AssignmentEntity))
            {
                return "Zadání";
            }
            else if (type == typeof(AssessmentEntity))
            {
                return "Posouzení";
            }
            else if (type == typeof(ArchivationEntity))
            {
                return "Archivace";
            }
            else if (type == typeof(PublishEntity))
            {
                return "Zveřejnění";
            }
            else if (type == typeof(ContractEntity))
            {
                return "Tvorba smlouvy";
            }
            else if (type == typeof(EstimateEntity))
            {
                return "Odhad ceny";
            }
            else
            {
                return "";
            }
        }
    }
}
