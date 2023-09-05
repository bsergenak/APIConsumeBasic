using APIConsumeBasic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIConsumeBasic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Miami()
        {
            string jsonData = new WebClient().DownloadString("https://api.weatherapi.com/v1/current.json?key=82e866db7bfe4ec79f873900231701&q=Miami&aqi=yes");

            //Root weather = JsonConvert.SerializeObject(jsonData); => Json'a çevirme yöntemi
            Root weather = JsonConvert.DeserializeObject<Root>(jsonData); //=> Deserialize yöntemi

            return View(weather);
        }

        public IActionResult Istanbul()
        {
            string jsonData = new WebClient().DownloadString("https://api.weatherapi.com/v1/current.json?key=82e866db7bfe4ec79f873900231701&q=Istanbul&aqi=yes");

            Root weather = JsonConvert.DeserializeObject<Root>(jsonData);

            return View(weather);
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
