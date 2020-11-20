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

        //private List<StateModel> states = new List<StateModel>();

        //private AllStates allStates = new AllStates();
        //private StatesModel singleState = null;

        //CurrentModel> currentUSCovid = new List<CurrentModel>(); 


        public CovidController(ILogger<USCovidModel> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._baseUrl = this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.BASEURL));
            this._usUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.US)));
            this._usHistoricUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.USHISTORIC)));
            this._statesUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.STATES)));
            //var url = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.SINGLESTATE)));
            this._statesHistoricUrl = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.STATESHISTORIC)));

        }

        // GET: CovidCurrentUS
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                this.usCovidList = Helper.HttpRequestUS(this._usUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(this.usCovidList);
        }

        [HttpGet]
        public ActionResult Historic()
        {
            try
            {
                this.usCovidList = Helper.HttpRequestUS(this._usHistoricUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(this.usCovidList);
        }

        [HttpGet]
        public ActionResult States()
        {
            try
            {
                this.statesCovidList = Helper.HttpRequestStates(this._statesUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(this.statesCovidList);
        }

        [HttpGet]
        public ActionResult MyStates()
        {
            this.allStates = Helper.HttpRequestAllStates(this._statesUrl);
            return View(allStates);
        }

        [HttpPost]
        public ActionResult MyStates(string state)
        {
            this.allStates = Helper.HttpRequestAllStates(this._statesUrl);
            if(!string.IsNullOrEmpty(state) && !state.ToUpper().Equals(Constant.ALL))
            {
                StatesCovidModel s = this.allStates.StatesCovid.First(x => x.State.Equals(state));
                this.allStates.StatesCovid.Clear();
                this.allStates.StatesCovid.Add(s);
            }
            return View(allStates);
        }

        //[HttpGet]
        //public ActionResult StateHistoric()
        //{
        //    return this.MyStates();
        //}

        //[HttpPost]
        //public ActionResult StateHistoric(string state)
        //{
        //    if (!string.IsNullOrEmpty(state) && !state.ToUpper().Equals(Constant.ALL))
        //    {
        //        var url = string.Concat(this._baseUrl, this._configuration.GetValue<string>(string.Format("{0}:{1}", Constant.WEBAPI, Constant.SINGLESTATEHISTORIC)));
        //        this._singleStateHistoricUrl = string.Concat(this._baseUrl, string.Format(url, state));
        //        this.allStates = Helper.HttpRequestHistoricStates(this._singleStateHistoricUrl);
        //        var s = from sc in this.allStates.StatesCovid where sc.State == state select sc;
        //        this.allStates.StatesCovid.Clear();
        //        if (s != null && s.Count<StatesCovidModel>() > 0)
        //        {
        //            this.allStates.StatesCovid = s.ToList<StatesCovidModel>();
        //        }
        //        else
        //        {
        //            this.MyStates();
        //            this.allStates.StatesCovid.Clear();
        //        }
        //    }
        //    else
        //    {
        //        this.MyStates();
        //    }
        //    return View(allStates);
        //}
    }
}
