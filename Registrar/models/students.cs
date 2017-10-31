using System;
using System.Collections.Generic;

namespace Registrar.Models
{
	public class Student
	{
    private int _id;
    public void SetId(int id) {_id = id;}
    public int GetId() {return _id;}

    private string _name;
    public void SetName(string name) {_name = name;}
    public string GetName() {return _name;}

    public Student(string name, int id = 0)
    {
      SetName(name);
      SetId(id);
    }
    public void Save()
    {
      Query saveStudent = new Query("INSERT INTO students (name) VALUES (@Name)");
      saveStudent.AddParameter("@Name", GetName());
      saveStudent.Execute();
    }

    public static int GetCount()
    {
      Query countStudents = new Query("SELECT COUNT(*) FROM students");
      var rdr = countStudents.Read();
      while (rdr.Read())
      {
        return rdr.GetInt32(0);
      }
    }
  }
}
