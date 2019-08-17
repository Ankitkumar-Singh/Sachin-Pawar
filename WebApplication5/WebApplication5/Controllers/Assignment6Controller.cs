using System.Linq;
using System.Web.Mvc;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class Assignment6Controller : Controller
    {
       public EmployeeContext employeeContext = new EmployeeContext();
        // GET: Assignment6
        public ActionResult Index()
        {
            return View(employeeContext.Employees.ToList());
        }      
    }
}
