using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Models
{
    public class TeamMetricEdit
    {
        [Display(Name="Evaluation Id")]
        public int EvalId { get; set; }

        [Display(Name = "Scrum Team Name")]
        public int TeamId { get; set; }

        [Display(Name = "Scrum Master Name")]
        public int ScrumMasterId { get; set; }

        [Display(Name = "Fiscal Year")]
        public int Fiscalyear { get; set; }

        [Display(Name = "Fiscal Quarter")]
        public Quarter FiscalQuarter { get; set; }

        [Display(Name = "Burn Up")]
        public double BurnUp { get; set; }

        [Display(Name = "Velocity")]
        public int Velocity { get; set; }

        [Display(Name = "Production Support")]
        public double ProdSupport { get; set; }

        [Display(Name = "Customer Rating")]
        [Range(1, 5, ErrorMessage = "Please choose a number between 1 and 5")]
        public int CustomerRating { get; set; }

        [Display(Name = "Trust Rating")]
        [Range(1, 5, ErrorMessage = "Please choose a number between 1 and 5")]
        public int TrustRating { get; set; }

        [Display(Name = "Performance Rating")]
        public PerformanceRating RatingOfPerformance { get; set; }
    }
}
