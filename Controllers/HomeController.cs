using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidMvc.Models;
using Microsoft.Extensions.Configuration;
using CovidMvc.ApiDTO;
using CovidMvc.Constants;
using System.Net.Http;
using Newtonsoft.Json;

namespace CovidMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        private List<USCovidModel> currentUSList = new List<USCovidModel>();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult TodoItem()
        {
            TodoItemEntity todoItems = new TodoItemEntity();
            return View(todoItems);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult CurrentUS()
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            var response = client.GetAsync(this._currentUSUrl).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string data = response.Content.ReadAsStringAsync().Result;
        //                this.currentUSList = JsonConvert.DeserializeObject<List<CurrentUSModel>>(data);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return View(this.currentUSList);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
