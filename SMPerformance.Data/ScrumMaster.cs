using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Data
{
    public class ScrumMaster
    {
        [Key]
        public int ScrumMasterId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<TeamMetric> TeamMetrics { get; set; }

    }
}
