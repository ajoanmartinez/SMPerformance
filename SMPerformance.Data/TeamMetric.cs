using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Data
{
    public enum Quarter
    {
        Q1, Q2, Q3, Q4
    }

    public enum PerformanceRating
    {
       NotRated, NeedsImprovement, BelowAverage, Average, AboveAverage, ExceedsExpectations
    }
    public class TeamMetric
    {
        [Key]
        public int EvalId { get; set; }

        [Required]
        public int Team { get; set; }

        [Required]
        public int ScrumMaster { get; set; }

        [Required]
        public int Fiscalyear { get; set; }

        [Required]
        public Quarter FiscalQuarter { get; set; }

        [Required]
        public double BurnUp { get; set; }

        [Required]
        public int Velocity { get; set; }

        [Required]
        public double ProdSupport { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Please chose a number between 1 and 5")]
        public int CustomerRating { get; set; }

        [Range(1, 5, ErrorMessage = "Please chose a number between 1 and 5")]
        [Required]
        public int TrustRating { get; set; }

        [Required]
        public PerformanceRating RatingOfPerformance { get; set; }

        [Required]
        [ForeignKey(nameof(scrumMaster))]
        public int ScrumMasterId { get; set; }

        public virtual ScrumMaster scrumMaster{ get; set; }

        [Required]
        [ForeignKey(nameof(scrumTeam))]
        public int TeamId { get; set; }
        public virtual ScrumTeam scrumTeam { get; set; }

    }
}
