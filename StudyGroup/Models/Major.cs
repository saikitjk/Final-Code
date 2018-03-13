using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudyGroup.Models
{
    public class Major
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int MajorID { get; set; }
    
        public string MajorName { get; set; }

        public virtual ICollection<GroupStatus> GroupStatuses { get; set; }

    }
}