using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyGroup.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupLeader { get; set; }
       
   
        public DateTime Date { get; set; }
 

        public virtual ICollection<GroupStatus> GroupStatuses { get; set; }
    }
}