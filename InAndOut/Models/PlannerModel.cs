using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class PlannerModel
    {
        [Key]
        public int Id { get; set; }
        public string PlannedWork { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
