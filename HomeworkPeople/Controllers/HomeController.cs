using HomeworkPeople.Data;
using HomeworkPeople.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkPeople.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
   @"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=true;";

        public IActionResult Index()
        {
            PeopleManager mngr = new PeopleManager(_connectionString);
            ErrorViewModel vm = new ErrorViewModel();
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            vm.People = mngr.GetAllPeople();
            return View(vm);
        }
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {
            PeopleManager mngr = new PeopleManager(_connectionString);

            foreach (Person person in people)
            {
                mngr.AddPerson(person);
            }
            if(people.Count==1 && people!=null)
            {
                TempData["message"] = "Person added successfully!";
            }
            else
            {
                TempData["message"] = "People added successfully!";
            }
            
            return Redirect("/");

        }
        public ActionResult DeletePerson(int id)
        {
            PeopleManager manager = new PeopleManager(_connectionString);
            manager.DeletePerson(id);
            return Redirect("/");
        }

    }
}
