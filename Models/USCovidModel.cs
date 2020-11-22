using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using CovidMvc.Helpers;

namespace CovidMvc.Models
{
    public class USCovidModel
    {
        [DisplayName("Int Date")]
        public int Date { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public string DTDate
        {
            get
            {
                var dt = Helper.GetDateFromInt(this.Date);
                return dt.ToString("MM/dd/yyyy");
            }
        }

        [DisplayName("DateChecked")]
        public string DateChecked { get; set; }
        
        [DisplayName("Deaths")]
        public int Death { get; set; }
        
        [DisplayName("New deaths")]
        public int DeathIncrease { get; set; }

        [DisplayName("Hash")]
        public string Hash { get; set; }

        [DisplayName("Hospitalized")]
        public int Hospitalized { get; set; }

        [DisplayName("Cumulative hospitalized")]
        public int HospitalizedCumulative { get; set; }

        [DisplayName("Currently hospitalized/Now hospitalized")]
        public int HospitalizedCurrently { get; set; }

        [DisplayName("New total hospitalizations")]
        public int HospitalizedIncrease { get; set; }

        [DisplayName("Cumulative in ICU/Ever in ICU")]
        public int InICUCumulative { get; set; }

        [DisplayName("Currently in ICU/Now in ICU")]
        public int InICUCurrently { get; set; }

        [DisplayName("LastModified")]
        public DateTime LastModified { get; set; }

        [DisplayName("Negative PCR tests (people)")]
        public int Negative { get; set; } // negative PCR Tests

        [DisplayName("NegativeIncrease")]
        public int NegativeIncrease { get; set; }

        [DisplayName("Cumulative on ventilator/Ever on ventilator")]
        public int OnVentilatorCumulative { get; set; }

        [DisplayName("Currently on ventilator/Now on ventilator")]
        public int OnVentilatorCurrently { get; set; }

        [DisplayName("Pending")]
        public int Pending { get; set; } // tests pending

        [DisplayName("Cases (confirmed plus probable)")]
        public int Positive { get; set; } // 

        [DisplayName("New cases")]
        public int PositiveIncrease { get; set; }

        [DisplayName("PosNeg")]
        public int PosNeg { get; set; }

        [DisplayName("Recovered")]
        public int Recovered { get; set; }

        [DisplayName("States")]
        public int States { get; set; }

        [DisplayName("Total")]
        public int Total { get; set; }

        [DisplayName("Total test results")]
        public int TotalTestResults { get; set; }

        [DisplayName("New tests")]
        public int TotalTestResultsIncrease { get; set; }
    }
}
