using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Assignment2Controller : Controller
    {
        // GET: Assignment2
        #region "Index Action Method"
        //Employee List
        public ActionResult Index()
        {
            EmployeeContext employeecontext = new EmployeeContext();
            List<Employee> employee = employeecontext.Employees.ToList();
            return View(employee);
        }
        #endregion

        #region "Details Action Method"
        //Employee Details
        public ActionResult Details(int id)
        {
            EmployeeContext employeecontext = new EmployeeContext();
            Employee employee = employeecontext.Employees.Single(emp => emp.id == id);
            return View(employee);
        }
        #endregion        
    }
}