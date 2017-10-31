using System;
using System.Collections.Generic;

namespace Registrar.Models
{
	public class Department
	{
    private int _id;
    public void SetId(int id) {_id = id;}
    public int GetId() {return _id;}

    private string _name;
    public void SetName(string name) {_name = name;}
    public string GetName() {return _name;}

    public Department(string name, int id = 0)
    {
      SetName(name);
      SetId(id);
    }

  }
}
