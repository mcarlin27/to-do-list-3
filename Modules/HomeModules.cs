using Nancy;
using ToDo.Objects;
using System.Collections.Generic;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/tasks"] = _ => {
        List<Task> allTasks = Task.GetAll();
        return View["view_all_tasks.cshtml", allTasks];
      };
      Get["/tasks/new"] = _ => {
        return View["add_new_task.cshtml"];
      };
      Post["/tasks"] = _ => {
        Task newTask = new Task(Request.Form["new-task"]);
        List<Task> allTasks = Task.GetAll();
        return View["view_all_tasks.cshtml", allTasks];
      };
      Get["/tasks/{id}"] = parameters => {
        Task task = Task.Find(parameters.id);
        return View["/task_added.cshtml", task];
      };
    }
  }
}
