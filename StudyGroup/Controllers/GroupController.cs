using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudyGroup.DAL;
using StudyGroup.Models;

namespace StudyGroup.Controllers
{
    public class GroupController : Controller
    {
        private GroupContext db = new GroupContext();
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Leader" ? "leader_desc" : "Date";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var groups = from s in db.Groups
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                groups = groups.Where(s => s.GroupName.Contains(searchString)
                                       || s.GroupLeader.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    groups = groups.OrderByDescending(s => s.GroupName);
                    break;
                case "Leader":
                    groups = groups.OrderBy(s => s.GroupLeader);
                    break;
                case "leader_desc":
                    groups = groups.OrderByDescending(s => s.GroupLeader);
                    break;
                case "Date":
                    groups = groups.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    groups = groups.OrderByDescending(s => s.Date);
                    break;
                default:
                    groups = groups.OrderBy(s => s.GroupName);
                    break;
            }
            return View(groups.ToList());
        }
      

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Group/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupName,GroupLeader")] Group group)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(group);
        }

        // GET: Group/Edit/5
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var groupToUpdate = db.Groups.Find(id);
            if (TryUpdateModel(groupToUpdate, "",
               new string[] { "GroupName", "GroupLeader", "Date" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(groupToUpdate);
        }


        // GET: Group/Delete/5
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Delete/5
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]
        public ActionResult Delete(int id)
        {
            try
            {
                Group group = db.Groups.Find(id);
                db.Groups.Remove(group);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
