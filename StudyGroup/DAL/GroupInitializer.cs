using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudyGroup.Models;
namespace StudyGroup.DAL
{
    public class GroupInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GroupContext>
    {

        protected override void Seed(GroupContext context)
        {
            var groups = new List<Group>
            {
            new Group{GroupName="Carson",GroupLeader="Alexander",Date=DateTime.Parse("2005-09-01")},
             new Group{GroupName="Carson",GroupLeader="Alexander",Date=DateTime.Parse("2005-09-01")},
           new Group{GroupName="Carson",GroupLeader="Alexander",Date=DateTime.Parse("2005-09-01")},
            new Group{GroupName="Carson",GroupLeader="Alexander",Date=DateTime.Parse("2005-09-01")},
             new Group{GroupName="Carson",GroupLeader="Alexander",Date=DateTime.Parse("2005-09-01")},
           new Group{GroupName="Carson",GroupLeader="Alexander",Date=DateTime.Parse("2005-09-01")},
            };

            groups.ForEach(s => context.Groups.Add(s));
            context.SaveChanges();

            var majors = new List<Major> {

                new Major{MajorID = 1, MajorName = "IT",},
                new Major{MajorID = 2, MajorName = "CSS",},
                new Major{MajorID = 3, MajorName = "Business",},
                new Major{MajorID = 4, MajorName = "Finance",},
                new Major{MajorID = 5, MajorName = "Electrical Engineer",},
                new Major{MajorID = 6, MajorName = "Other",},
            };
            majors.ForEach(s => context.Majors.Add(s));
            context.SaveChanges();


            var groupstatuses = new List<GroupStatus>
            {
                new GroupStatus {GroupID = 1111, MajorID = 1, Status = "Active",},
                new GroupStatus {GroupID = 1112, MajorID = 2, Status = "Active",},
                new GroupStatus {GroupID = 1113, MajorID = 3, Status = "Active",},
                new GroupStatus {GroupID = 1114, MajorID = 4, Status = "Active",},
                new GroupStatus {GroupID = 1115, MajorID = 5, Status = "Active",},
                new GroupStatus {GroupID = 1116, MajorID = 6, Status = "Active",},

            };
            groupstatuses.ForEach(s => context.GroupStatuses.Add(s));
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
            groupstatuses.ForEach(s => context.GroupStatuses.Add(s));
            context.SaveChanges();
        }
    }



}







