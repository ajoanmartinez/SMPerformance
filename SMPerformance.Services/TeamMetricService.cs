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
                                    ScrumMasterId = e.ScrumMasterId,
                                    TeamId= e.TeamId,
                                    TeamName= e.scrumTeam.TeamName,
                                    ScrumMaster = e.scrumMaster.FirstName + " " + e.scrumMaster.LastName,
                                    Fiscalyear = e.Fiscalyear,
                                    FiscalQuarter = (Models.Quarter)e.FiscalQuarter,
                                    RatingOfPerformance = (Models.PerformanceRating)e.RatingOfPerformance
                                }
                            );
                return query.ToArray();
            }
        }

        public IEnumerable<TeamMetricListItem> GetTeamMetricsByScrumMaster(int scrumMasterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeamMetrics
                        .Where(e => e.ScrumMasterId == scrumMasterId && e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeamMetricListItem
                                {
                                    EvalId = e.EvalId,
                                    ScrumMasterId = e.ScrumMasterId,
                                    TeamName = e.scrumTeam.TeamName,
                                    ScrumMaster = e.scrumMaster.FirstName + " " + e.scrumMaster.LastName,
                                    Fiscalyear = e.Fiscalyear,
                                    FiscalQuarter = (Models.Quarter)e.FiscalQuarter,
                                    RatingOfPerformance = (Models.PerformanceRating)e.RatingOfPerformance
                                }
                            );
                return query.ToArray();
            }
        }

        public IEnumerable<TeamMetricListItem> GetTeamMetricsByScrumTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeamMetrics
                        .Where(e => e.ScrumMasterId == teamId && e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeamMetricListItem
                                {
                                    EvalId = e.EvalId,
                                    ScrumMasterId = e.ScrumMasterId,
                                    TeamId = e.TeamId,
                                    TeamName = e.scrumTeam.TeamName,
                                    ScrumMaster = e.scrumMaster.FirstName + " " + e.scrumMaster.LastName,
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
                        .Single(e => e.EvalId == id && e.OwnerId == _userId);
                return
                    new TeamMetricDetail
                    {
                        EvalId = entity.EvalId,
                        TeamId = entity.TeamId,
                        TeamName = entity.scrumTeam.TeamName,
                        ScrumMasterId = entity.ScrumMaster,
                        ScrumMaster = entity.scrumMaster.FirstName+" "+entity.scrumMaster.LastName,
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
                        .Single(e => e.EvalId == model.EvalId && e.OwnerId == _userId);

                
                entity.TeamId = model.TeamId;
                entity.Team = model.TeamId;
                entity.ScrumMasterId = model.ScrumMasterId;
                entity.ScrumMaster = model.ScrumMasterId;
                entity.Fiscalyear = model.Fiscalyear;
                entity.FiscalQuarter = (Data.Quarter)model.FiscalQuarter;
                entity.BurnUp = model.BurnUp;
                entity.Velocity = model.Velocity;
                entity.ProdSupport = model.ProdSupport;
                entity.CustomerRating = model.CustomerRating;
                entity.TrustRating = model.TrustRating;
                entity.RatingOfPerformance = (Data.PerformanceRating)model.RatingOfPerformance;

                return ctx.SaveChanges() == 1;

            }

        }

        public bool DeleteTeamMetric(int evalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeamMetrics
                        .Single(e => e.EvalId == evalId && e.OwnerId == _userId);

                ctx.TeamMetrics.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
