using Nancy;
using Todo.Objects;
using System.Collections.Generic;

namespace TodoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/categories"] = _ => {
        List<Category> allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/new"] = _ => {
        return View["category_form.cshtml"];
      };
      Post["/categories"] = _ => {
        Category newCategory = new Category(Request.Form["category-name"]);
        List<Category> allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Tasks> categoryTasks = selectedCategory.GetTasks();
        model.Add("category", selectedCategory);
        model.Add("tasks", categoryTasks);
        return View["category.cshtml", model];
      };
      Get["/categories/{id}/tasks/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Task> allTasks = selectedCategory.GetTasks();
        model.Add("category", selectedCategory);
        model.Add("tasks", allTasks);
        return View["category_tasks_form.cshtml", model];
      };
      Post["/tasks"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<Task> categoryTasks = selectedCategory.GetTasks();
        string taskDescription = Request.Form["task-description"];
        Task newTask = new Task(taskDescription);
        categoryTasks.Add(newTask);
        model.Add("tasks", categoryTasks);
        model.Add("category", selectedCategory);
        return View["category.cshtml", model];
      };
    }
  }
}
