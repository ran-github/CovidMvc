using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidMvc.Models
{
    public class USCovidEntities
    {
        public List<USCovidModel> USCovid = new List<USCovidModel>();

        [Display(Name = "Start Date:")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date:")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
