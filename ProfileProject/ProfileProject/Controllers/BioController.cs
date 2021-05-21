using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileProject.Models;
using ProfileProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileProject.Controllers
{
    public class BioController : Controller
    {
        private IRepo<Bio> _repo;
        private ILogger<BioController> _logger;

        public BioController(IRepo<Bio> repo, ILogger<BioController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Bio> profiles = _repo.GetAll().ToList(); ;
            return View(profiles);

        }

        public IActionResult Details(int id)
        {
            Bio profile = _repo.Get(id);
            return View(profile);
        }
        [HttpPost]
        public IActionResult Details(Bio profile)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Bio profile)
        {
            _repo.Add(profile);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Bio profile = _repo.Get(id);
            return View(profile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Bio profile)
        {
            _repo.Update(id, profile);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Bio profile = _repo.Get(id);
            return View(profile);

        }
        [HttpPost]
        public IActionResult Delete(Bio profile)
        {
            _repo.Delete(profile);
            return RedirectToAction("Index");
        }

    }
}
