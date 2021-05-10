using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Models
{
    public class ScrumTeamCreate
    {
        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Display(Name = "Date Team Created")]
        public DateTime DateCreated { get; set; }

    }
}
