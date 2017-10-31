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

		private int _deptId;
		public void SetDeptId(int deptId) {_deptId = deptId;}
		public int GetDeptId() {return _deptId;}

    public Student(string name, int id = 0, int deptId = 0)
    {
      SetName(name);
      SetId(id);
			SetDeptId(deptId);
    }
    public void Save()
    {
      Query saveStudent = new Query("INSERT INTO students (name) VALUES (@Name)");
      saveStudent.AddParameter("@Name", GetName());
      saveStudent.Execute();
      SetId((int)saveStudent.GetCommand().LastInsertedId);
    }

    public static int GetCount()
    {
      Query countStudents = new Query("SELECT COUNT(*) FROM students");
      var rdr = countStudents.Read();
      while (rdr.Read())
      {
        return rdr.GetInt32(0);
      }
      return 0;
    }

    public static void ClearAll()
    {
      Query clearStudents = new Query("DELETE FROM students");
      clearStudents.Execute();
    }

    public static Student Find(int id)
    {
      Query matchedStudent = new Query("SELECT * FROM students WHERE student_id = @searchId");
      matchedStudent.AddParameter("@searchId", id.ToString());
      var rdr = matchedStudent.Read();
      int matchId = 0;
      string matchName = "";
      while (rdr.Read())
      {
        matchId = rdr.GetInt32(0);
        matchName = rdr.GetString(1);
      }
      Student studentMatch = new Student(matchName, matchId);
      return studentMatch;
    }

    public void Update()
    {
      Query updateStudent = new Query(@"
			SET foreign_key_checks = 0;
			UPDATE students SET name = @updateName, department_id = @updateDeptId
			WHERE student_id = @studentId;
			SET foreign_key_checks = 1;");
      updateStudent.AddParameter("@updateName", GetName());
			updateStudent.AddParameter("@updateDeptId", GetDeptId().ToString());
      updateStudent.AddParameter("@studentId", GetId().ToString());
      updateStudent.Execute();
    }

    public static void DeleteById(int id)
    {
      Query deleteStudent = new Query("DELETE FROM students WHERE student_id = @studentId");
      deleteStudent.AddParameter("@studentId", id.ToString());
      deleteStudent.Execute();
    }

    public void Delete()
    {
      DeleteById(GetId());
    }

		public static List<Student>GetAll()
		{
			List<Student> allStudents = new List<Student> {};
			Query getAllStudents = new Query("SELECT * FROM students");
			var rdr = getAllStudents.Read();
			while(rdr.Read())
			{
				int id = rdr.GetInt32(0);
				string name = rdr.GetString(1);
				Student newStudent = new Student(name, id);
				allStudents.Add(newStudent);
			}
			return allStudents;
		}
  }
}
