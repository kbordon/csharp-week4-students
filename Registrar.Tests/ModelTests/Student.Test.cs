
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registrar.Models;
namespace Registrar.Tests
{
  [TestClass]
  public class StudentTests : IDisposable
  {
    public Dispose()
    {
      //
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
  }
}
