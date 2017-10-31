using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registrar.Models;
namespace Registrar.Tests
{
  [TestClass]
  public class CourseTests : IDisposable
  {

    public CourseTests()
    {
      DB.DatabaseTest();
    }

    public void Dispose()
    {
      Course.ClearAll();
      Student.ClearAll();
    }


    [TestMethod]
    public void Save_SavesCourseToDatabase_1()
    {
      Course newCourse = new Course("Carpentry: Chainsaw Maintenance");
      newCourse.Save();

      Assert.AreEqual(1, Course.GetCount());
    }

    [TestMethod]
    public void Find_FindsCourseInDatabase_True()
    {
      Course newCourse = new Course("Metalworking: Stakes and More");
      newCourse.Save();

      Course foundCourse = Course.Find(newCourse.GetId());
      Assert.AreEqual(newCourse.GetId(), foundCourse.GetId());
    }

    [TestMethod]
    public void Update_UpdatesCourseInformationInDatabase_false()
    {
      Course newCourse = new Course("Dark Psychology: Fight Your Demons");
      newCourse.Save();

      newCourse.SetName("Dark Psychology: How to Love Your Demons");
      newCourse.Update();

      Course foundCourse = Course.Find(newCourse.GetId());
      Assert.AreNotEqual(foundCourse.GetName(), "Dark Psychology: Fight Your Demons");
    }

    [TestMethod]
    public void Delete_DeletesACourseFromDatabase_0()
    {
      Course newCourse = new Course("Career Planning: Beyond the Knife");
      newCourse.Save();

      newCourse.Delete();
      Assert.AreEqual(0, Course.GetCount());
    }

    [TestMethod]
    public void GetStudents_GetStudentsByCourseId_1()
    {
      Course newCourse = new Course("Shadow Travel 101");
      newCourse.Save();

      Course newCourse2 = new Course("Biology");
      newCourse2.Save();

      Student newStudent = new Student("Michael Myers");
      newStudent.Save();
      newCourse.Enroll(newStudent.GetId());

      Student newStudent2 = new Student("Frankenstien");
      newStudent2.Save();
      newCourse2.Enroll(newStudent2.GetId());

      List<Student> courseStudents = newCourse.GetStudents();

      Assert.AreEqual(1, courseStudents.Count);
    }

  }
}
