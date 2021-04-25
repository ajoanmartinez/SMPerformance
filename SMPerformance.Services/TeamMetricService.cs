using SMPerformance.Data;
using SMPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Services
{
    public class TeamMetricService
    {
        private readonly Guid _userId;

        public TeamMetricService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeamMetric(TeamMetricCreate model)
        {
            var entity =
                new TeamMetric()
                {
                    OwnerId = _userId,
                    Team = model.TeamId,
                    ScrumMaster = model.ScrumMasterId,
                    Fiscalyear = model.Fiscalyear,
                    FiscalQuarter = (Data.Quarter)model.FiscalQuarter,
                    BurnUp = model.BurnUp,
                    Velocity = model.Velocity,
                    ProdSupport = model.ProdSupport,
                    CustomerRating = model.CustomerRating,
                    TrustRating = model.TrustRating,
                    RatingOfPerformance = (Data.PerformanceRating)model.RatingOfPerformance
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TeamMetrics.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamMetricListItem> GetTeamMetrics()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeamMetrics
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeamMetricListItem
                                {
                                    EvalId = e.EvalId,
                                    Team = e.Team,
                                    ScrumMaster = e.ScrumMaster,
                                    Fiscalyear = e.Fiscalyear,
                                    FiscalQuarter = (Models.Quarter)e.FiscalQuarter,
                                    RatingOfPerformance = (Models.PerformanceRating)e.RatingOfPerformance
                                }
                            );
                return query.ToArray();
            }
        }
    }
}
