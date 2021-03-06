using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Models
{
    public class ScrumTeamDetail
    {
        [Display(Name="Team Id")]
        public int  TeamId { get; set; }

        [Display(Name="Team Name")]
        public string TeamName { get; set; }

        [Display(Name="Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
