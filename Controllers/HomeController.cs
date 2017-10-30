using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using DbConnection;
using Microsoft.EntityFrameworkCore;
using quotingDojo.Models;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private QuotesContext _context;

        public HomeController(QuotesContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult QuotesGet()
        {
            List<Quote> AllQuotes = _context.Quotes.ToList();
            ViewBag.Quotes = AllQuotes;
            return View("Quotes");
        }

        [HttpPost]
        [Route("/quotes")]
        public IActionResult QuotesPost(Quote quote)
        {
            if (ModelState.IsValid)
            {
                // quote.created_at = DateTime.Now;
                // quote.updated_at = DateTime.Now;
                _context.Quotes.Add(quote);
                _context.SaveChanges();
            }
            return RedirectToAction("QuotesGet");
        }
    }
}
