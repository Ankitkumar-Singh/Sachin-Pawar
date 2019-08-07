using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Assignment5Controller : Controller
    {
        //Object of EmployeeContext is created
        private EmployeeContext db = new EmployeeContext();

        #region "Index Action Method"
        //Index Action Method
        // GET: Assignment5
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        #endregion

        #region "Fetches all Details of the employee"
        /// <summary>
        /// Fetches all Data of the employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Assignment5/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        #endregion

        #region "Create New Employee Record"
        /// <summary>
        /// Create New Employee Record
        /// </summary>
        /// <returns></returns>
        // GET: Assignment5/Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region "Create New Employee Record using HttpPost request"
        // Create New Employee Record using HttpPost request
        // POST: Assignment5/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Gender,City,DOB")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        #endregion

        #region "Editing The Employees Records"
        //Editing The Employees Records
        // GET: Assignment5/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        #endregion

        #region "Editing The Employees Record Using HttpPost Request"
        //Editing The Employees Record Using HttpPost Request
        // POST: Assignment5/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Gender,City,DOB")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        #endregion

        #region "Delete Action Method Deletes The Complete Record of Employee"
        //Delete Action Method Deletes The Complete Record of Employee
        // GET: Assignment5/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        #endregion

        #region "DeleteConfirmed Action Method Confirms to Employee to Delete Record"
        //DeleteConfirmed Action Method Confirms to Employee to Delete Record.
        // POST: Assignment5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region "Dispose Method For Releasing Unmanaged Resources"
        /// <summary>
        /// Dispose method for releasing "unmanaged" resources 
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