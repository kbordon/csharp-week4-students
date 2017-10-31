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

    public Course(string name, int id = 0)
    {
      SetName(name);
      SetId(id);
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
      Query clearCourses = new Query("DELETE FROM courses");
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
      Query updateCourse = new Query("UPDATE courses SET name = @updateName WHERE course_id = @courseId");
      updateCourse.AddParameter("@updateName", GetName());
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
			Query enrollStudent = new Query("INSERT INTO courses_students VALUES(@courseId, @studentId)");
			enrollStudent.AddParameter("@courseId", GetId().ToString());
			enrollStudent.AddParameter("@studentId", studentId.ToString());
			enrollStudent.Execute();
		}

		public List<Student> GetStudents()
		{
			Query getStudents = new Query("SELECT students.* FROM courses_students JOIN (courses_students, students) WHERE course_id = @courseId");
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
