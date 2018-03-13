using StudyGroup.Models;

namespace StudyGroup.Models
{

    public class GroupStatus
    {
        public int GroupStatusID { get; set; }
        public int GroupID { get; set; }
        public int MajorID { get; set; }

        public string Status { get; set; }
        public virtual Group Group { get; set; }
        public virtual Major Major { get; set; }

    
    }
}