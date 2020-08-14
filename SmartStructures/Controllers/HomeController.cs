using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartStructures.Models;

namespace SmartStructures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;

        public HomeController(ILogger<HomeController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var model = _studentRepository.GetAllStudents();                            
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Details(string id)
        {  
            Student student = _studentRepository.GetStudent(Convert.ToInt32(id));
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id);
            }            

            return View(student);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                

                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    Standard = model.Standard,                 
                };
                _studentRepository.Add(newStudent);
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _studentRepository.GetStudent(id);            
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                //Student student = _studentRepository.GetStudent(model.Id);
                //student.Name = model.Name;
                //student.Email = model.Email;
                //student.Standard = model.Standard;

                _studentRepository.Update(model);
                return RedirectToAction("index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            _studentRepository.Delete(id);
            return RedirectToAction("index");
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
