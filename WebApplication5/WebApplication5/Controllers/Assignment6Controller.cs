using System.Linq;
using System.Web.Mvc;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class Assignment6Controller : Controller
    {
       public EmployeeContext employeeContext = new EmployeeContext();

        #region "Index Action Method Returns the List of Employees"
        /// GET: Assignment6
        /// <summary>Indexes this instance.</summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(employeeContext.Employees.ToList());
        }
        #endregion
    }
}