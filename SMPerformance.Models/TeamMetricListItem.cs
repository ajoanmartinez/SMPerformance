using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Models
{
    public enum Quarter
    {
        Q1, Q2, Q3, Q4
    }

    public enum PerformanceRating
    {
        NotRated, NeedsImprovement, BelowAverage, Average, AboveAverage, ExceedsExpectations
    }
    public class TeamMetricListItem
    {
        [Display(Name = "Evaluation Id")]
        public int EvalId { get; set; }

        [Display(Name = "Scrum Team")]
        public int Team { get; set; }

        [Display(Name = "Scrum Master")]
        public int ScrumMaster { get; set; }

        [Display(Name = "Fiscal Year")]
        public int Fiscalyear { get; set; }

        [Display(Name = "Fiscal Quarter")]
        public Quarter FiscalQuarter { get; set; }

        [Display(Name = "Performance Rating")]
        public PerformanceRating RatingOfPerformance { get; set; }
    }
}
