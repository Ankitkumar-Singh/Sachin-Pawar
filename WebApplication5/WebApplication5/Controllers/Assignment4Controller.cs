using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Assignment4Controller : Controller
    {
        #region "Index Action Method"
        /// <summary>
        /// Index Action Method Returns The View With Employee List
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        #endregion

        #region "Create_Get Action Method with HttpGet Request"
        /// <summary>
        /// Create_Get Action Method with HttpGet Request
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        #endregion

        #region "Crete_Post Action Methos with HttpPost Request"
        /// <summary>
        /// Crete_Post Action Methos with HttpPost Request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

            Employee employee = new Employee();
            TryUpdateModel(employee);

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region "Edit Action Method with HttpGet Request"
        /// <summary>
        /// Edit Action Method with HttpGet Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.id == id);

            return View(employee);
        }
        #endregion

        #region "Edit_Post Action Method With HttpPost Action Method"
        /// <summary>
        /// Edit_Post Action Method With HttpPost Action Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

            Employee employee = employeeBusinessLayer.Employees.Single(x => x.id == id);
            UpdateModel(employee, null, null, new string[] { "Name" });

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }
        #endregion

        #region "Delete Action Method with HttpPost Request"
        /// <summary>
        /// Delete Action Method with HttpPost Request to Delete Employee Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}