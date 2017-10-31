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

    // private int _departmentId;
    // public void SetDepartmentId(string name) {_departmentId = departmentId;}
    // public string GetDepartmentId() {return _departmentId;}

    public Course(string name, int id = 0)
    {
      SetName(name);
      SetId(id);
      // SetDepartmentId(deptId);
    }




  }
}
