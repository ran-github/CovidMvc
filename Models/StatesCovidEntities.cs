using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CovidMvc.Models
{
    public class StatesCovidEntities
    {
        public List<StatesCovidModel> StatesCovid = new List<StatesCovidModel>();
        public List<SelectListItem> USStates = new List<SelectListItem>();

        //private DateTime startDate = DateTime.Now;
        //private DateTime endDate = DateTime.Now;

        public string SelectedState { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
