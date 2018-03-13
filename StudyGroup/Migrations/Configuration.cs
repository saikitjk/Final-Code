namespace StudyGroup.Migrations
{
    using StudyGroup.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudyGroup.DAL.GroupContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudyGroup.DAL.GroupContext context)
        {
            var groups = new List<Group>
            {
            new Group{GroupName="Team A",GroupLeader="Alexander",Date=DateTime.Parse("2005-09-01")},
             new Group{GroupName="Fantastic",GroupLeader="Ryn",Date=DateTime.Parse("2005-09-01")},
           new Group{GroupName="Never Give Up",GroupLeader="Thuan",Date=DateTime.Parse("2005-09-01")},
            new Group{GroupName="Cry Until Die",GroupLeader="Baldeep",Date=DateTime.Parse("2005-09-01")},
             new Group{GroupName="Smile Is Live",GroupLeader="Jason",Date=DateTime.Parse("2005-09-01")},
           new Group{GroupName="Way To Heaven",GroupLeader="Boss",Date=DateTime.Parse("2005-09-01")},
            };

            groups.ForEach(s => context.Groups.AddOrUpdate(p => p.GroupName, s));
            context.SaveChanges();

            var majors = new List<Major> {

                new Major{MajorID = 1, MajorName = "IT",},
                new Major{MajorID = 2, MajorName = "CSS",},
                new Major{MajorID = 3, MajorName = "Business",},
                new Major{MajorID = 4, MajorName = "Finance",},
                new Major{MajorID = 5, MajorName = "Electrical Engineer",},
                new Major{MajorID = 6, MajorName = "Other",},
            };
            majors.ForEach(s => context.Majors.AddOrUpdate(p => p.MajorName, s));
            context.SaveChanges();

            var groupstatuses = new List<GroupStatus>
            {
                  new GroupStatus {
                    GroupID = groups.Single(s => s.GroupName == "Team A").GroupID,
                    MajorID = majors.Single(c => c.MajorName == "IT" ).MajorID,
                   Status = "Active",
                },
              new GroupStatus {
                    GroupID = groups.Single(s => s.GroupName == "Fantastic").GroupID,
                    MajorID = majors.Single(c => c.MajorName == "CSS" ).MajorID,
                   Status = "Active",
                },
              new GroupStatus {
                    GroupID = groups.Single(s => s.GroupName == "Never Give Up").GroupID,
                    MajorID = majors.Single(c => c.MajorName == "Business" ).MajorID,
                   Status = "Active",
                },
              new GroupStatus {
                    GroupID = groups.Single(s => s.GroupName == "Smile Is Live").GroupID,
                    MajorID = majors.Single(c => c.MajorName == "IT" ).MajorID,
                   Status = "Active",
                },
              new GroupStatus {
                    GroupID = groups.Single(s => s.GroupName == "Way To Heaven").GroupID,
                    MajorID = majors.Single(c => c.MajorName == "Finance" ).MajorID,
                   Status = "Active",
                },

            };
            foreach (GroupStatus e in groupstatuses)
            {
                var groupStatusInDataBase = context.GroupStatuses.Where(
                    s =>
                         s.Group.GroupID == e.GroupID &&
                         s.Major.MajorID == e.MajorID).SingleOrDefault();
                if (groupStatusInDataBase == null)
                {
                    context.GroupStatuses.Add(e);
                }
            }
            context.SaveChanges();
            var rooms = new List<Room>
            {
                new Room {RoomID = 100, RoomName = "JOY009",},
                new Room {RoomID = 1001, RoomName = "CP205",},
                 new Room {RoomID = 102, RoomName = "JOY205",},
                  new Room {RoomID = 103, RoomName = "TLB100",},
                   new Room {RoomID = 104, RoomName = "SNO102",},
                    new Room {RoomID = 150, RoomName = "JOY129",},
            };
            rooms.ForEach(s => context.Rooms.AddOrUpdate(p => p.RoomName, s));
            context.SaveChanges();





        }



    }
}
