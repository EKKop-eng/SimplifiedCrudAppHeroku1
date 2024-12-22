
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SimpleCrudApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> Records = new List<string>(); // In-memory data storage

        public IActionResult Index()
        {
            return View(Records); // Show all records
        }

        public IActionResult Create()
        {
            return View(); // Show create form
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Records.Add(name); // Add new record
            }
            return RedirectToAction("Index"); // Redirect to the records list
        }

        public IActionResult Edit(int id)
        {
            if (id >= 0 && id < Records.Count)
            {
                ViewBag.Id = id;
                ViewBag.Name = Records[id]; // Get record by id
                return View();
            }
            return RedirectToAction("Index"); // Redirect if record not found
        }

        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            if (id >= 0 && id < Records.Count && !string.IsNullOrEmpty(name))
            {
                Records[id] = name; // Update record
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id >= 0 && id < Records.Count)
            {
                Records.RemoveAt(id); // Remove record
            }
            return RedirectToAction("Index");
        }
    }
}
