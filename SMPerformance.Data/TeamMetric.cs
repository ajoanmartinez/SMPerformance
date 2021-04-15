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

    public enum CustomerRating
    {
        NeedsImprovement, BelowAverage, Average, AboveAverage, ExceedsExpectations
    }

    public enum TrustRating
    {
        NoTrust, LowTrust, NeutralTrust, EstablishingTrust, HighTrust
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
        public CustomerRating RatingFromCustomer { get; set; }

        [Required]
        public TrustRating RatingOfTrust { get; set; }

        [Required]
        public PerformanceRating RatingOfPerformance { get; set; }
        

    }
}
