using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Models
{
    public class TeamMetricCreate
    {
        [Display(Name="Scrum Team Name")]
        [Required]
        public int TeamId { get; set; }

        [Display(Name = "Scrum Master Name")]
        [Required]
        public int ScrumMasterId { get; set; }

        [Display(Name = "Fiscal Year")]
        [Required]
        public int Fiscalyear { get; set; }

        [Display(Name = "Fiscal Quarter")]
        [Required]
        public Quarter FiscalQuarter { get; set; }

        [Display(Name = "Burn Up")]
        [Required]
        public double BurnUp { get; set; }

        [Display(Name = "Velocity")]
        [Required]
        public int Velocity { get; set; }

        [Display(Name = "Production Support")]
        [Required]
        public double ProdSupport { get; set; }

        [Display(Name = "Customer Rating")]
        [Required]
        [Range(1, 5, ErrorMessage = "Please choose a number between 1 and 5")]
        public int CustomerRating { get; set; }

        [Display(Name = "Trust Rating")]
        [Range(1, 5, ErrorMessage = "Please choose a number between 1 and 5")]
        [Required]
        public int TrustRating { get; set; }

        [Display(Name = "Performance Rating")]
        [Required]
        public PerformanceRating RatingOfPerformance { get; set; }
    }
}
