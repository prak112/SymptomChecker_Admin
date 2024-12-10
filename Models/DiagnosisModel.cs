using System.ComponentModel.DataAnnotations;

namespace SymptomChecker_Admin2.Models
{
    public class DiagnosisModel
    {
        [Required]
        public string Symptom { get; set; }

        [Required]
        public string Analysis { get; set; }

        [Required]
        public TopResult TopResult { get; set; }
    }

    public class TopResult
    {
        public string Label { get; set; }
        public double Score { get; set; }
        public string Detail { get; set; }
        public string Url { get; set; }
    }
}