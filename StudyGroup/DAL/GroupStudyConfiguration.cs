using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace StudyGroup.DAL
{
    public class GroupStudyConfiguration : DbConfiguration
    {
        public GroupStudyConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
          
        }
    }
}