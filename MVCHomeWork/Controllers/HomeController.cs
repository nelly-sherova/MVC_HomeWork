using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace MVCHomeWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _conString = "Data source = NILUFARSHEROVA; Initial catalog = MVCHomeWorkdb; Integrated Security = True";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Person> persons = new List<Person>();
            using (IDbConnection conn = new SqlConnection(_conString))
            {
                persons = conn.Query<Person>("SELECT * FROM Person").ToList();
            }
            return View(persons);
 
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
