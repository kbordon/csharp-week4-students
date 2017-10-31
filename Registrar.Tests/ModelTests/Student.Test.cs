using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registrar.Models;
namespace Registrar.Tests
{
  [TestClass]
  public class StudentTests : IDisposable
  {
    public void Dispose()
    {
      Student.ClearAll();
    }

    public StudentTests()
    {
      // DB.DatabaseTest();
      // Student.ClearAll();
    }

    [TestMethod]
    public void Save_SavesStudentToDatabase_1()
    {
      Student newStudent = new Student("Freddy Krueger");
      newStudent.Save();

      Assert.AreEqual(1, Student.GetCount());

    }

    [TestMethod]
    public void Find_FindStudentInDatabase_True()
    {
      Student newStudent = new Student("Freddy Krueger");
      newStudent.Save();

      Student foundStudent = Student.Find(newStudent.GetId());
      Assert.AreEqual(newStudent.GetId(), foundStudent.GetId());
    }

    [TestMethod]
    public void Update_UpdateStudentInformationInDatabase_false()
    {
      Student newStudent = new Student("Mary Tudor");
      newStudent.Save();

      newStudent.SetName("Bloody Mary");
      newStudent.Update();

      Student foundStudent = Student.Find(newStudent.GetId());
      Assert.AreNotEqual(foundStudent.GetName(), "Mary Tudor");
    }

    [TestMethod]
    public void Delete_DeleteAStudentFromDatabase_0()
    {
      Student newStudent = new Student("Jason Voorhees");
      newStudent.Save();

      newStudent.Delete();
      Assert.AreEqual(0, Student.GetCount());

    }
  }
}
