using StudyGroup.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudyGroup.DAL
{
    public class GroupContext : DbContext
    {

        public GroupContext() : base("GroupContext")
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupStatus> GroupStatuses { get; set; }
        public DbSet<Major> Majors { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}