using SMPerformance.Data;
using SMPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Services
{
    public class ScrumTeamService
    {
        private readonly Guid _userId;

        public ScrumTeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateScrumTeam(ScrumTeamCreate model)
        {
            var entity =
                new ScrumTeam()
                {
                    OwnerId = _userId,
                    TeamName = model.TeamName,
                    DateCreated = model.DateCreated
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ScrumTeams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ScrumTeamListItem> GetScrumTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ScrumTeams
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ScrumTeamListItem
                                {
                                    TeamId = e.TeamId,
                                    TeamName = e.TeamName,
                                    DateCreated = e.DateCreated
                                }
                            );

                return query.ToArray();
            }
        }

        public IEnumerable<ScrumTeam> GetScrumTeamList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.ScrumTeams.ToList();
            }
        }

        public ScrumTeamDetail GetScrumTeamById(int id)
        {
            using (var  ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ScrumTeams
                        .Single(e => e.TeamId == id && e.OwnerId == _userId);
                return
                    new ScrumTeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        DateCreated = entity.DateCreated
                    };
            }
        }

        public bool UpdateScrumTeam(ScrumTeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ScrumTeams
                        .Single(e => e.TeamId == model.TeamId && e.OwnerId == _userId);

                entity.TeamName = model.TeamName;
                entity.DateCreated = model.DateCreated;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteScrumTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ScrumTeams
                        .Single(e => e.TeamId == teamId && e.OwnerId == _userId);

                ctx.ScrumTeams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
