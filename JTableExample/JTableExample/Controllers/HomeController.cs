using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JTableExample.Models;
using Newtonsoft.Json;

namespace JTableExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Added as an example to populate our dummy list
        [HttpPost]
        public JsonResult GetItems()
        {
            try
            {
                //Add to our list
                List<Student> studentList = new List<Student>()
                {
                  new Student(){ StudentID=1, StudentName="Bill"},
                  new Student(){ StudentID=2, StudentName="Steve"},
                  new Student(){ StudentID=3, StudentName="Ram"},
                  new Student(){ StudentID=4, StudentName="Moin"}
                };
                //var json = JsonConvert.SerializeObject(studentList);
                return Json(new { Result = "OK", Records = studentList, TotalRecordCount = studentList.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
