using System;
using System.Collections.Generic;

namespace Registrar.Models
{
	public class Course
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

    public Course(string name, int id = 0, int deptId = 0)
    {
      SetName(name);
      SetId(id);
			SetDeptId(deptId);
    }

    public void Save()
    {
      Query saveCourse = new Query("INSERT INTO courses (name) VALUES (@name)");
      saveCourse.AddParameter("@name", GetName());
      saveCourse.Execute();
      SetId((int)saveCourse.GetCommand().LastInsertedId);
    }

    public static int GetCount()
    {
      Query countCourses = new Query("SELECT COUNT(*) FROM courses");
      var rdr = countCourses.Read();
      while (rdr.Read())
      {
        return rdr.GetInt32(0);
      }
      return 0;
    }

    public static void ClearAll()
    {
      Query clearCourses = new Query("DELETE FROM courses_students; DELETE FROM courses");
      clearCourses.Execute();
    }

    public static Course Find(int id)
    {
      Query matchedCourse = new Query("SELECT * FROM courses WHERE course_id = @searchId");
      matchedCourse.AddParameter("@searchId", id.ToString());
      var rdr = matchedCourse.Read();
      int matchId = 0;
      string matchName = "";
      while (rdr.Read())
      {
        matchId = rdr.GetInt32(0);
        matchName = rdr.GetString(1);
      }
      Course courseMatch = new Course(matchName, matchId);
      return courseMatch;
    }

    public void Update()
    {
      Query updateCourse = new Query(@"
			SET foreign_key_checks = 0;
			UPDATE courses SET name = @updateName, department_id = @updateDeptId
			WHERE course_id = @courseId;
			SET foreign_key_checks = 1;");
      updateCourse.AddParameter("@updateName", GetName());
			updateCourse.AddParameter("@updateDeptId", GetDeptId().ToString());
      updateCourse.AddParameter("@courseId", GetId().ToString());
      updateCourse.Execute();
    }

    public static void DeleteById(int id)
    {
      Query deleteCourse = new Query("DELETE FROM courses WHERE course_id = @courseId");
      deleteCourse.AddParameter("@courseId", id.ToString());
      deleteCourse.Execute();
    }
    public void Delete()
    {
      DeleteById(GetId());
    }

		public void Enroll(int studentId)
		{
			Query enrollStudent = new Query("INSERT INTO courses_students VALUES(@courseId, @studentId, 100, 0)");
			enrollStudent.AddParameter("@courseId", GetId().ToString());
			enrollStudent.AddParameter("@studentId", studentId.ToString());
			enrollStudent.Execute();
		}

		public List<Student> GetStudents()
		{
			Query getStudents = new Query(@"
			SELECT students.*
				FROM courses_students JOIN (students)
				ON students.student_id = courses_students.student_id
			WHERE course_id = @courseId");
			getStudents.AddParameter("@courseId", GetId().ToString());

			List<Student> courseStudents = new List<Student> {};

			var rdr = getStudents.Read();
			while (rdr.Read()) {
				Student courseStudent = new Student(rdr.GetString(1), rdr.GetInt32(0));
				courseStudents.Add(courseStudent);
			}
			return courseStudents;
		}
  }
}
