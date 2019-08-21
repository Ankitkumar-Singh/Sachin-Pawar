using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Assignment11Controller : Controller
    {
        //Database Object Creation
        private DepartmentNewDataModel db = new DepartmentNewDataModel();
        #region "Index Action Method [HttpGet]"
        /// <summary>
        /// Index Action Method [HttpGet]
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Ass11Emp.ToList());
        }
        #endregion

        #region "Create Action Method [HttpGet]"
        /// <summary>
        ///Create Action Method [HttpGet]
        /// </summary>
        /// <returns></returns>
        // GET: Assignment11/Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region "Create Action Method [HttpPost]"
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Age,Gender,HireDate")] Ass11Emp ass11Emp)
        {
            if (ModelState.IsValid)
            {
                db.Ass11Emp.Add(ass11Emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ass11Emp);
        }
        #endregion

        #region "Delete Action Method to Delete Employee Record [HttpGet]"
        /// <summary>
        /// Delete Action Method to Delete Employee Record [HttpGet]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ass11Emp ass11Emp = db.Ass11Emp.Find(id);
            if (ass11Emp == null)
            {
                return HttpNotFound();
            }
            return View(ass11Emp);
        }
        #endregion

        #region "Delete Action Method to Delete Employee Record [HttpPost]"
        /// <summary>
        /// Delete Action Method to Delete Employee Record [HttpPost]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Assignment11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ass11Emp ass11Emp = db.Ass11Emp.Find(id);
            db.Ass11Emp.Remove(ass11Emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region "Check Email Availability"
        /// <summary>Determines whether [is email available] [the specified email].</summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public JsonResult IsEmailAvailable(string Email)
        {
            return Json(!db.Ass11Emp.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region " Dispose the All Database Objects"
        /// <summary>
        /// Dispose the All Database Objects
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
