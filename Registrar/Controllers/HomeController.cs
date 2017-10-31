using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Registrar.Models;

namespace Registrar.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpGet("/students/new")]
      public ActionResult StudentForm()
      {
        return View();
      }

      [HttpPost("/students/new")]
      public ActionResult StudentAdd()
      {
        Student newStudent = new Student(Request.Form["student-name"]);
        newStudent.Save();
        List<Student> allStudents = Student.GetAll();
        return View("Students", allStudents);
      }

      [HttpGet("/courses/new")]
      public ActionResult CourseForm()
      {
        return View();
      }

      [HttpGet("/departments/new")]
      public ActionResult DepartmentForm()
      {
        return View();
      }
    }
}
