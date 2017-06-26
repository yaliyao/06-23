using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using test_0623_A.Models;
using test_0623_A.Models.DirectoryDataSetTableAdapters;


namespace test_0623_A.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index() {
            //DataSet ds = GetData();
            //DirectoryDataSet ds = new DirectoryDataSet();
            //employeeTableAdapter da = new employeeTableAdapter();
            //da.Fill(ds.employee);
            //return View("AdoNetIndex", ds.employee);

            directoryEntities db = new directoryEntities();
            //var query = from emp in db.employees
            //            select emp;
            //var data = query.ToList();
            //var data = db.employees.ToList();
            List<employee> data = db.employees.ToList();
            return View("EdmIndex", data);
        }

        // TODO: GetData move into DBService Class
        //private static DataSet GetData() {
        //    SqlConnection cn = new SqlConnection("server=(local)\\SQLExpress; database=directory; integrated security=true");
        //    cn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter("select * from employee", cn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "emp");
        //    return ds;
        //}


        public ActionResult Update(int id) {
            directoryEntities db = new directoryEntities();  // DBContext
            employee emp = db.employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Update(employee empForm) {
            directoryEntities db = new directoryEntities();  // DBContext
            employee emp = db.employees.Find(empForm.id);
            emp.firstName = empForm.firstName;
            emp.lastName = empForm.lastName;
            emp.email = empForm.email;

            db.SaveChanges();
            return RedirectToAction("index");
        }









        public ActionResult Details() {


            return View();
        }


    }
}