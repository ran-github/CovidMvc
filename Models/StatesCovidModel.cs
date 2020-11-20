using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CovidMvc.Models
{
    public class StatesCovidModel
    {
        [DisplayName("CheckTimeEt")]
        public string CheckTimeEt { get; set; }
        [DisplayName("CommercialScore")]
        public int CommercialScore { get; set; }
        [DisplayName("DataQualityGrade")]
        public string DataQualityGrade { get; set; }
        [DisplayName("Date")]
        public int Date { get; set; }
        [DisplayName("DateChecked")]
        public string DateChecked { get; set; }
        [DisplayName("DateModified")]
        public string DateModified { get; set; }
        [DisplayName("Death")]
        public int Death { get; set; }
        [DisplayName("DeathConfirmed")]
        public int DeathConfirmed { get; set; }
        [DisplayName("DeathIncrease")]
        public int DeathIncrease { get; set; }
        [DisplayName("DeathProbable")]
        public int DeathProbable { get; set; }
        [DisplayName("Fips")]
        public string Fips { get; set; }
        [DisplayName("Grade")]
        public string Grade { get; set; }
        [DisplayName("Hash")]
        public string Hash { get; set; }
        [DisplayName("Hospitalized")]
        public int Hospitalized { get; set; }
        [DisplayName("HospitalizedCumulative")]
        public int HospitalizedCumulative { get; set; }
        [DisplayName("HospitalizedCurrently")]
        public int HospitalizedCurrently { get; set; }
        [DisplayName("HospitalizedIncrease")]
        public int HospitalizedIncrease { get; set; }
        [DisplayName("InIcuCumulative")]
        public int InIcuCumulative { get; set; }
        [DisplayName("In Icu")]
        public int InIcuCurrently { get; set; }
        [DisplayName("LastUpdateEt")]
        public string LastUpdateEt { get; set; }
        [DisplayName("Negative")]
        public int Negative { get; set; }
        [DisplayName("NegativeIncrease")]
        public int NegativeIncrease { get; set; }
        [DisplayName("NegativeRegularScore")]
        public int NegativeRegularScore { get; set; }
        [DisplayName("NegativeScore")]
        public int NegativeScore { get; set; }
        [DisplayName("NegativeTestsAntibody")]
        public int NegativeTestsAntibody { get; set; }
        [DisplayName("NegativeTestsPeopleAntibody")]
        public int NegativeTestsPeopleAntibody { get; set; }
        [DisplayName("NegativeTestsViral")]
        public int NegativeTestsViral { get; set; }
        [DisplayName("OnVentilatorCumulative")]
        public int OnVentilatorCumulative { get; set; }
        [DisplayName("On Ventilator")]
        public int OnVentilatorCurrently { get; set; }
        [DisplayName("Pending")]
        public int Pending { get; set; }
        [DisplayName("Positive")]
        public int Positive { get; set; }
        [DisplayName("PositiveCasesViral")]
        public int PositiveCasesViral { get; set; }
        [DisplayName("PositiveIncrease")]
        public int PositiveIncrease { get; set; }
        [DisplayName("PositiveScore")]
        public int PositiveScore { get; set; }
        [DisplayName("PositiveTestsAntibody")]
        public int PositiveTestsAntibody { get; set; }
        [DisplayName("PositiveTestsAntigen")]
        public int PositiveTestsAntigen { get; set; }
        [DisplayName("PositiveTestsPeopleAntibody")]
        public int PositiveTestsPeopleAntibody { get; set; }
        [DisplayName("PositiveTestsPeopleAntigen")]
        public int PositiveTestsPeopleAntigen { get; set; }
        [DisplayName("PositiveTestsViral")]
        public int PositiveTestsViral { get; set; }
        [DisplayName("PosNeg")]
        public int PosNeg { get; set; }
        [DisplayName("ProbableCases")]
        public int ProbableCases { get; set; }
        [DisplayName("Recovered")]
        public int Recovered { get; set; }
        [DisplayName("Score")]
        public int Score { get; set; }
        [DisplayName("State")]
        public string State { get; set; }
        [DisplayName("Total")]
        public int Total { get; set; }
        [DisplayName("TotalTestEncountersViral")]
        public int TotalTestEncountersViral { get; set; }
        [DisplayName("TotalTestResults")]
        public int TotalTestResults { get; set; }
        [DisplayName("TotalTestResultsIncrease")]
        public int TotalTestResultsIncrease { get; set; }
        [DisplayName("TotalTestResultsSource")]
        public string TotalTestResultsSource { get; set; }
        [DisplayName("TotalTestsAntibody")]
        public int TotalTestsAntibody { get; set; }
        [DisplayName("TotalTestsAntigen")]
        public int TotalTestsAntigen { get; set; }
        [DisplayName("TotalTestsPeopleAntibody")]
        public int TotalTestsPeopleAntibody { get; set; }
        [DisplayName("TotalTestsPeopleAntigen")]
        public int TotalTestsPeopleAntigen { get; set; }
        [DisplayName("TotalTestsPeopleViral")]
        public int TotalTestsPeopleViral { get; set; }
        [DisplayName("TotalTestsViral")]
        public int TotalTestsViral { get; set; }

        public bool IsPopulated { get; set; }
    }
}
