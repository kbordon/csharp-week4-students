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

      [HttpGet("/students/delete/{id}")]
      public ActionResult StudentDelete(int id)
      {
        Student.DeleteById(id);
        return Redirect("/students");
      }

      [HttpGet("/students")]
      public ActionResult Students()
      {
        List<Student> allStudents = Student.GetAll();
        return View("Students", allStudents);
      }

      [HttpGet("/students/{id}")]
      public ActionResult ViewStudent(int id)
      {
        Student student = Student.Find(id);
        return View(student);
      }

      [HttpGet("/courses/")]
      public ActionResult Courses()
      {
        List<Course> allCourses = Course.GetAll();
        return View(allCourses);
      }

      [HttpGet("/courses/new")]
      public ActionResult CourseForm()
      {
        return View();
      }

      [HttpPost("/courses/new")]
      public ActionResult CourseAdd()
      {
        Course newCourse = new Course(Request.Form["course-name"]);
        newCourse.Save();
        List<Course> allCourses = Course.GetAll();
        return View("Courses", allCourses);
      }

      [HttpGet("/courses/{id}")]
      public ActionResult ViewCourse(int id)
      {
        Course course = Course.Find(id);
        return View(course);
      }

      [HttpPost("/courses/delete/{id}")]
      public ActionResult CourseDelete(int id)
      {
        Course.DeleteById(id);
        List<Course> allCourses = Course.GetAll();
        return View("Courses", allCourses);
      }

      [HttpGet("/departments/new")]
      public ActionResult DepartmentForm()
      {
        return View();
      }

      [HttpPost("/departments/new")]
      public ActionResult DepartmentAdd()
      {
        Department newDepartment = new Department(Request.Form["department-name"]);
        newDepartment.Save();
        List<Department> allDepartments = Department.GetAll();
        return View("Departments", allDepartments);
      }

      [HttpGet("/departments/delete/{id}")]
      public ActionResult DepartmentDelete(int id)
      {
        Department.DeleteById(id);
        return Redirect("/departments");
      }

      [HttpGet("/departments")]
      public ActionResult Departments()
      {
        List<Department> allDepartments = Department.GetAll();
        return View("Departments", allDepartments);
      }

      [HttpGet("/departments/{id}")]
      public ActionResult ViewDepartment(int id)
      {
        Department department = Department.Find(id);
        return View(department);
      }



    }
}
