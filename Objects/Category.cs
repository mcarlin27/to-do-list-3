using System.Collections.Generic;

namespace Todo.Objects
{
  public class Category
  {
    private static List<Category> _instances = new list<Category> {};
    private string _name;
    private int _id;
    private List<Task> _task;

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _task = new List<Task>{};
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Category> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
