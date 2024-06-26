using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todolist.Models;
using TodoList.Domain.Interface;


namespace Todolist.Controllers
{
    public class HomeController(ITodoService service) : Controller
    { 
	public class IActionResult Index(strimg id)
    {
        var temp = ServiceCollection.GetAll();

            //var filters = new Filters(id);
            //VeiwBag.Filters = filters;
            ViewBag.Categories = Enum.GetValues(typeof(Category)).OfType<dynamic>().Select(x => new { Key = x, Value = Enum.GetName(x) });
            ViewBag.Statuses = Enum.GetValues(typeof(Status));
            //VeiwBag.DueFilters = Filter.DueFilterValues;
            var query = service.GetAll();
            //IQueryable<ToDO> query = context.ToDoS
            // .Include(t => t.category)
            // .Include(t => t.status)

            //if (filters.HasCategory)
            //{
            //}

        }

        public class HomeController(ITodoSevice sevice) : Controller
        {
            private ToDoContext context;
            private ITodoRepository _todoRepository;

            public HomeController(ToDoContext ctx,
                ITodoRepository todoRepository)
            {
                context = ctx;
                _todoRepository = todoRepository;
            }

        }

        public IActionResult Index(string id)
        {
            var temp = _todoRepository.GetAll();
            //var filters = new Filters(id);
            //ViewBag.Filters = filters;
            //ViewBag.Categories = context.Categories.ToList();
            //ViewBag.Statuses = context.Statuses.ToList();
            //ViewBag.DueFilters = Filters.DueFilterValues;

            //IQueryable<ToDo> query = context.ToDoS
            //    .Include(t => t.Category)
            //    .Include(t => t.Status);

            //if (filters.HasCategory)
            //{
            //    query = query.Where(t => t.CategoryId == filters.CategoryId);
            //}

            //if (filters.HasStatus)
            //{
            //    query = query.Where(t => t.StatusId == filters.StatusId);
            //}

            //if (filters.HasDue)
            //{
            //    var today = DateTime.Today;
            //    if (filters.IsPast)
            //    {
            //        query = query.Where(t => t.DueDate < today);
            //    }
            //    else if (filters.IsFuture)
            //    {
            //        query = query.Where(t => t.DueDate > today);

            //    }
            //    else if (filters.IsToday)
            //    {
            //        query = query.Where(t => t.DueDate == today);
            //    }
            //}
            //var tasks = query.OrderBy(t => t.DueDate).ToList();

            //return View(tasks);

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            var task = new ToDo { StatusId = "open" };
            return View(task);
        }

        [HttpPost]
        public IActionResult Add(ToDo task)
        {
            if (ModelState.IsValid)
            {
                context.ToDoS.Add(task);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Statuses = context.Statuses.ToList();
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join("-", filter);
            return RedirectToAction("Index", new { ID = id });
        }
        [HttpPost]
        public IActionResult MarkComplete([FromRoute] string id, ToDo selected)
        {
            selected = context.ToDoS.Find(selected.Id);

            if (selected != null)
            {
                selected.StatusId = "closed";
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { ID = id });
        }
        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var toDelete = context.ToDoS.Where(t => t.StatusId == "closed").ToList();

            foreach (var task in toDelete)
            {
                context.ToDoS.Remove(task);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}
