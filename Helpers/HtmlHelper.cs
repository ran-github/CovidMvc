using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using CovidMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CovidMvc.Helpers
{
    public class HtmlHelper
    {
        public static string HttpRequestData(string url)
        {
            string data = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        data = response.Content.ReadAsStringAsync().Result;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public static List<USCovidModel> HttpRequestUS(string url)
        {
            List<USCovidModel> usCovidList = new List<USCovidModel>();

            string data = HttpRequestData(url);
            JsonSerializerSettings jSettings = new JsonSerializerSettings();
            jSettings.NullValueHandling = NullValueHandling.Ignore;
            usCovidList = JsonConvert.DeserializeObject<List<USCovidModel>>(data, jSettings);
            return usCovidList;
        }

        public static List<StatesCovidModel> HttpRequestStates(string url)
        {
            List<StatesCovidModel> statesCovidList = new List<StatesCovidModel>();

            string data = HttpRequestData(url);
            JsonSerializerSettings jSettings = new JsonSerializerSettings();
            jSettings.NullValueHandling = NullValueHandling.Ignore;
            statesCovidList = JsonConvert.DeserializeObject<List<StatesCovidModel>>(data, jSettings);
            return statesCovidList;
        }

        public static List<StatesCovidModel> HttpRequestSingleState(string url, int index)
        {
            var statesList = HttpRequestStates(url);
            List<StatesCovidModel> indivState = new List<StatesCovidModel>();
            indivState.Add(statesList[index]);
            return indivState;
        }

        public static StatesCovidEntities HttpRequestAllStates(string url)
        {
            StatesCovidEntities stateEntities = new StatesCovidEntities();
            string data = HttpRequestData(url);
            JsonSerializerSettings jSettings = new JsonSerializerSettings();
            jSettings.NullValueHandling = NullValueHandling.Ignore;
            stateEntities.StatesCovid = JsonConvert.DeserializeObject<List<StatesCovidModel>>(data, jSettings);
            stateEntities.USStates = (from s in stateEntities.StatesCovid
                                      select new SelectListItem { Text = s.State, Value = s.State }).Distinct().ToList();
            return stateEntities;
        }

        public static StatesCovidEntities HttpRequestHistoricSingleState(string url)
        {
            StatesCovidEntities stateEntities = new StatesCovidEntities();
            string data = HttpRequestData(url);
            JsonSerializerSettings jSettings = new JsonSerializerSettings();
            jSettings.NullValueHandling = NullValueHandling.Ignore;

            stateEntities.StatesCovid = JsonConvert.DeserializeObject<List<StatesCovidModel>>(data, jSettings);
            stateEntities.USStates = (from s in stateEntities.StatesCovid
                                      select new SelectListItem { Text = s.State, Value = s.State }).Distinct().ToList();
            return stateEntities;
        }

        public static StatesCovidEntities HttpRequestHistoricStates(string url)
        {
            StatesCovidEntities stateEntities = new StatesCovidEntities();
            string data = HttpRequestData(url);
            JsonSerializerSettings jSettings = new JsonSerializerSettings();
            jSettings.NullValueHandling = NullValueHandling.Ignore;
            stateEntities.StatesCovid = JsonConvert.DeserializeObject<List<StatesCovidModel>>(data, jSettings);
            stateEntities.USStates = (from s in stateEntities.StatesCovid
                                      select new SelectListItem { Text = s.State, Value = s.State }).Distinct().ToList();
            return stateEntities;
        }

    }
}
