using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using CovidMvc.Helpers;

namespace CovidMvc.Models
{
    public class StatesCovidEntities
    {
        public List<StatesCovidModel> StatesCovid = new List<StatesCovidModel>();
        public List<SelectListItem> USStates = new List<SelectListItem>();

        //private DateTime startDate = DateTime.Now;
        //private DateTime endDate = DateTime.Now;

        public string SelectedState { get; set; }

        [Display(Name = "Start Date:")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date:")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime MinDate
        {
            get
            {
                DateTime date;
                if (this.StartDate == DateTime.MinValue)
                {
                    date = Helper.GetDateFromInt(this.StatesCovid.Min(x => x.Date));
                }
                else
                {
                    date = this.StartDate;
                }
                return date;
            }
        }

        [DataType(DataType.Date)]
        public DateTime MaxDate
        {
            get
            {
                DateTime date;
                if (this.EndDate == DateTime.MinValue)
                {
                    date = Helper.GetDateFromInt(this.StatesCovid.Max(x => x.Date));
                }
                else
                {
                    date = this.EndDate;
                }
                return date;
            }
        }
    }
}
