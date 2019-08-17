using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Assignment7Controller : Controller
    {
        //Comments table object is created
        private Comments db = new Comments();

        #region "Index Action Method HttpGet"
        // Index Action Method HTTPGET: Assignment7
        public ActionResult Index()
        {
            return View(db.Commentsc.ToList());
        }
        #endregion

        #region "Details Action Method HttpGet"
        // Details Action Method GET: Assignment7/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Commentsc.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        #endregion

        #region "Create Action Method HttpGet"
        //Create Action Method: HTTPGET Assignment7/Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region "Create Action Method HttpPost"
        // POST: Assignment7/Create Action Method
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // Input validation is disabled, so the users can submit HTML
        [ValidateInput(false)]
        public ActionResult Create(Comment comment)
        {
            StringBuilder sbComments = new StringBuilder();

            // Encode the text that is coming from comments textbox
            sbComments.Append(HttpUtility.HtmlEncode(comment.Comments));

            // Only decode bold and underline tags
            sbComments.Replace("&lt;b&gt;", "<b>");
            sbComments.Replace("&lt;/b&gt;", "</b>");
            sbComments.Replace("&lt;u&gt;", "<u>");
            sbComments.Replace("&lt;/u&gt;", "</u>");
            comment.Comments = sbComments.ToString();

            // HTML encode the text that is coming from name textbox
            string strEncodedName = HttpUtility.HtmlEncode(comment.Name);
            comment.Name = strEncodedName;

            if (ModelState.IsValid)
            {
                db.Commentsc.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }
        #endregion

        #region "Edit Action Method HttpGet"
        // Edit Action Method HttpGet GET: Assignment7/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Commentsc.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        #endregion

        #region " Edit Action Method  HttpPost"
        // Edit Action Method  HTTPPOST: Assignment7/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Comments")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }
        #endregion

        #region "Delete Action Method HttpGet"      
        //Delete Action Method HttpGet GET: Assignment7/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Commentsc.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        #endregion

        #region "Delete Action Method HttpPost"
        //Delete Action Method HTTPPOST: Assignment7/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Commentsc.Find(id);
            db.Commentsc.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region "Dispose Action Method"
        //Dispose Action Method to Dispose Database Object
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
