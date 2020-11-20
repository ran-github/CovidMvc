using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidMvc.Models
{
    public class StatesCovidEntities
    {
        public List<StatesCovidModel> StatesCovid = new List<StatesCovidModel>();
        public List<SelectListItem> USStates = new List<SelectListItem>();
    }
}
