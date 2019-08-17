using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Assignment3Controller : Controller
    {
        #region "Index Action Method Returns Department Table Details"
        // Index Action Method Returns The Index View With Department Table Details.
        public ActionResult Index()
        {
            Department obj = new Department();
            List<DepartmentAccess> dept = obj.GetData();
            return View(dept);
        }
        #endregion
    }       
}