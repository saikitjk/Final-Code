using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudyGroup.DAL;
using StudyGroup.Models;

namespace StudyGroup.Controllers
{
    public class MajorController : Controller
    {
        private GroupContext db = new GroupContext();

        // GET: Major
        public ActionResult Index()
        {
            return View(db.Majors.ToList());
        }

        // GET: Major/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        // GET: Major/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Major/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MajorID,MajorName")] Major major)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Majors.Add(major);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(major);
        }

        // GET: Major/Edit/5
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        // POST: Major/Edit/5
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
            var majorToUpdate = db.Rooms.Find(id);
            if (TryUpdateModel(majorToUpdate, "",
               new string[] { "MajorID", "MajorName" }))
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
            return View(majorToUpdate);
        }

        // GET: Major/Delete/5
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
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        // POST: Major/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]
        public ActionResult Delete(int id)
        {
            try
            {
                Major major = db.Majors.Find(id);
                db.Majors.Remove(major);
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
