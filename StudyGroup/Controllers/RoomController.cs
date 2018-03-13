using System;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudyGroup.DAL;
using StudyGroup.Models;

namespace StudyGroup.Controllers
{
    public class RoomController : Controller
    {
        private GroupContext db = new GroupContext();

        // GET: Room
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Room/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,RoomName")] Room room)
        {
            try
            { 
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(room);
        }

        // GET: Room/Edit/5
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Room/Edit/5
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
            var roomToUpdate = db.Rooms.Find(id);
            if (TryUpdateModel(roomToUpdate, "",
               new string[] { "RoomID", "RoomName"}))
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
            return View(roomToUpdate);
        }


        // GET: Room/Delete/5
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
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Room/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "saikitjk@uw.edu, kangb3@uw.edu")]
        public ActionResult Delete(int id)
        {
            try
            {
                Room room = db.Rooms.Find(id);
                db.Rooms.Remove(room);
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
