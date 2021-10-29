using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;
using itu.DAL.Entities.Tasks;

namespace itu.DAL.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PriorityEnum Priority { get; set; }
        public string DelayReason { get; set; }
        public bool Active { get; set; }
        public int? PreviousId { get; set; }
        public TaskEntity Previous { get; set; }
        public int? NextId { get; set; }
        public TaskEntity Next { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int WorkflowId { get; set; }
        public WorkflowEntity Workflow { get; set; }
        public List<FileEntity> Files { get; set; }

        public static TaskEntity Factory(TaskTypeEnum type)
        {
            switch (type)
            {
                case TaskTypeEnum.Acceptation:
                    return new AcceptationEntity();
                
                case TaskTypeEnum.Archivation:
                    return new ArchivationEntity();
                
                case TaskTypeEnum.Assessment:
                    return new AssessmentEntity();

                case TaskTypeEnum.Assignment:
                    return new AssignmentEntity();
                
                case TaskTypeEnum.Contract:
                    return new ContractEntity();
                
                case TaskTypeEnum.Estimate:
                    return new EstimateEntity();

                case TaskTypeEnum.Publish:
                    return new PublishEntity();
                
                default:
                    return new TaskEntity();
            }
        }

        public static string ToLabel(Type type)
        {
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
