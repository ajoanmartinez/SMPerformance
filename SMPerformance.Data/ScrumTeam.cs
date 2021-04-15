using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Data
{
    public class ScrumTeam
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<TeamMetric> TeamMetrics { get; set; }

    }
}
