using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Diagnostics;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Consultation Consult;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(Consultation consultation)
        {
            if (consultation.Date < DateTime.Now)
            {
                ModelState.AddModelError("", "Дата повинна бути у майбутньому.");
            }
            if (consultation.Date.DayOfWeek == DayOfWeek.Saturday || consultation.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", "Дата повинна бути не вихідний.");
            }
            if (consultation.Subject == "Основи" && consultation.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "Дата повинна бути не Понеділок.");
            }
            if (ModelState.IsValid)
            {
                return $@"{consultation.Name} - {consultation.Email} - {consultation.Subject} - {consultation.Date}";
            }

            string errorMessages = "";
            foreach (var item in ModelState)
            {
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages = $"{errorMessages}\nПомилки властивості {item.Key}:\n";
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
                    }
                }
            }
            return errorMessages;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}