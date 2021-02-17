using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoManagement.Models;

namespace VideoManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VideoDataContext _db;
        public HomeController(ILogger<HomeController> logger, VideoDataContext context)
        {
            _logger = logger;
            this._db = context;
        }

        public IActionResult Index()
        {
            var allvideos = _db.Videos.ToList();
            return View(allvideos);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            @ViewBag.Title = "Create New Video";
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Video model)
        {
            if (ModelState.IsValid)
            {
                _db.Videos.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet("update")]
        public IActionResult Update(int id)
        {
            Video video = _db.Videos.Where(x => x.Id == id).FirstOrDefault();
            @ViewBag.Title = "Update Video";
            return View(video);
        }

        [HttpPost("update")]
        public IActionResult Update(Video model)
        {
            if (ModelState.IsValid)
            {
                _db.Videos.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            Video video = _db.Videos.Where(x => x.Id == id).FirstOrDefault();
            @ViewBag.Title = "Update Video";
            return View(video);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Video model)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
                //Video v = _db.Videos.Where(x => x.Id == id).FirstOrDefault();
                //if (v != default(Video))
                //{
                    _db.Videos.Remove(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                //}
            //}
            //return View(v);
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
