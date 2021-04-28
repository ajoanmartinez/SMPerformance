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
                    TeamId = model.TeamId,
                    Team = model.TeamId,
                    ScrumMasterId = model.ScrumMasterId,
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

        public TeamMetricDetail GetTeamMetricById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeamMetrics
                        .Single(e => e.TeamId == id && e.OwnerId == _userId);
                return
                    new TeamMetricDetail
                    {
                        EvalId = entity.EvalId,
                        TeamId = entity.TeamId,
                        ScrumMasterId = entity.ScrumMaster,
                        Fiscalyear = entity.Fiscalyear,
                        FiscalQuarter = (Models.Quarter)entity.FiscalQuarter,
                        BurnUp = entity.BurnUp,
                        Velocity = entity.Velocity,
                        ProdSupport = entity.ProdSupport,
                        CustomerRating = entity.CustomerRating,
                        TrustRating = entity.TrustRating,
                        RatingOfPerformance = (Models.PerformanceRating)entity.RatingOfPerformance
                    };


            }
        }

        public bool UpdateTeamMetric(TeamMetricEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .TeamMetrics
                        .Single(e => e.TeamId == model.TeamId && e.OwnerId == _userId);

                entity.TeamId = model.TeamId;
                entity.ScrumMasterId = model.ScrumMasterId;
                entity.Fiscalyear = model.Fiscalyear;
                entity.FiscalQuarter = (Data.Quarter)model.FiscalQuarter;
                entity.BurnUp = entity.BurnUp;
                entity.Velocity = entity.Velocity;
                entity.ProdSupport = entity.ProdSupport;
                entity.CustomerRating = entity.CustomerRating;
                entity.TrustRating = entity.TrustRating;
                entity.RatingOfPerformance = (Data.PerformanceRating)entity.RatingOfPerformance;

                return ctx.SaveChanges() == 1;


            }


        }
    }
}
