using Microsoft.AspNetCore.Mvc;
using MvcCoreTutorial.Models.Domain;

namespace MvcCoreTutorial.Controllers
{
    public class Employee : Controller
    {
        private readonly EmployeeDatabase _ctx;
            public Employee(EmployeeDatabase ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.say = "\'Hello guys.!\'";
            ViewData["hi"] = "How you all ?";
            TempData["a"] = "I hope you all are fine. ";
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Models.Domain.Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.employee.Add(employee);
                _ctx.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("AddPerson");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added!!!"+ex.Message;
                return View();
            }

        }
        public IActionResult DisplayPersons()
        {
            var persons = _ctx.employee.ToList();
            return View(persons);
        }
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var employee = _ctx.employee.Find(id);
                if (employee != null)
                {
                    _ctx.employee.Remove(employee);
                    _ctx.SaveChanges();
                }
            }
            catch(Exception)
            {
                
            }
            return RedirectToAction("DisplayPersons");
        }
        public IActionResult EditPerson(int id)
        {
                var person = _ctx.employee.Find(id);
               
            return View(person);
        }
        [HttpPost]
        public IActionResult EditPerson(Models.Domain.Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.employee.Update(employee);
                _ctx.SaveChanges();
                return RedirectToAction("DisplayPersons");

            }
            catch (Exception e)
            {
                TempData["msg"] = "Could not added !!"+e.Message;
                return View();
            }

        }

    }
 
}
