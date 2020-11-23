using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using CovidMvc.Constants;
using CovidMvc.Helpers;
using CovidMvc.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CovidMvc.Controllers
{
    public class CovidController : Controller
    {
        private readonly ILogger<USCovidModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        private readonly string _usUrl;
        private readonly string _usHistoricUrl;
        private readonly string _statesUrl;
        private string _singleStateHistoricUrl;
        private readonly string _statesHistoricUrl;

        private List<USCovidModel> usCovidList = new List<USCovidModel>();
        private List<StatesCovidModel> statesCovidList = new List<StatesCovidModel>();
        private StatesCovidModel singleState = new StatesCovidModel();

        private StatesCovidEntities allStates = new StatesCovidEntities();
        private USCovidEntities allUS = new USCovidEntities();

        public CovidController(ILogger<USCovidModel> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._baseUrl = this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.BASEURL));
            this._usUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.US)));
            this._usHistoricUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.USHISTORIC)));
            this._statesUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.STATES)));
            this._statesHistoricUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.STATESHISTORIC)));

        }

        // GET: CovidCurrentUS
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                this.usCovidList = HtmlHelper.HttpRequestUS(this._usUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(this.usCovidList);
        }

        [HttpGet]
        public ActionResult AllUS()
        {
            this.allUS = HtmlHelper.HttpRequestAllUS(this._usHistoricUrl);
            return View(this.allUS);
        }

        [HttpPost]
        public ActionResult AllUs(USCovidEntities covidEntities)
        {
            var getAllUS = HtmlHelper.HttpRequestAllUS(this._usHistoricUrl);
            this.allUS.USCovid = getAllUS.USCovid.Where(x => (x.Date >= Helper.GetIntFromDate(covidEntities.StartDate) && x.Date <= Helper.GetIntFromDate(covidEntities.EndDate))).Select(x => x).ToList<USCovidModel>();
            return View(this.allUS);
        }

        [HttpGet]
        public ActionResult AllStates()
        {
            this.allStates = HtmlHelper.HttpRequestAllStates(this._statesUrl);
            return View(allStates);
        }


        [HttpPost]
        public ActionResult AllStates(StatesCovidEntities covidEntities)
        {
            var getAllStates = HtmlHelper.HttpRequestAllStates(this._statesUrl);
            if (!string.IsNullOrEmpty(covidEntities.SelectedState) && !covidEntities.SelectedState.ToUpper().Equals(Constant.ALL))
            {
                var url = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.SINGLESTATEHISTORIC)));
                this._singleStateHistoricUrl = string.Format(url, covidEntities.SelectedState);
                var singleStateHistoric = HtmlHelper.HttpRequestHistoricSingleState(this._singleStateHistoricUrl);

                this.allStates.StatesCovid = singleStateHistoric.StatesCovid.Where(x => (x.Date >= Helper.GetIntFromDate(covidEntities.StartDate) && x.Date <= Helper.GetIntFromDate(covidEntities.EndDate))).Select(x => x).ToList<StatesCovidModel>();
                this.allStates.USStates.Clear();
                this.allStates.USStates = getAllStates.USStates.ToList<SelectListItem>();
            }
            else
            {
                this.allStates = getAllStates;
            }
            return View(this.allStates);
        }
    }
}
