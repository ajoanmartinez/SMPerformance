using SMPerformance.Data;
using SMPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Services
{
    public class ScrumMasterService
    {
        private readonly Guid _userId;

        public ScrumMasterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateScrumMaster(ScrumMasterCreate model)
        {
            var entity =
                new ScrumMaster()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ScrumMasters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ScrumMasterListItem> GetScrumMasters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ScrumMasters
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                              e =>
                                new ScrumMasterListItem
                                {
                                    ScrumMasterId = e.ScrumMasterId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName
                                }
                        );
                return query.ToArray();
            }
        }

        public ScrumMasterDetail GetScrumMasterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ScrumMasters
                        .Single(e => e.ScrumMasterId == id && e.OwnerId == _userId);
                return
                    new ScrumMasterDetail
                    {
                        ScrumMasterId = entity.ScrumMasterId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName
                    };
            }
        }

        public bool UpdateScrumMaster(ScrumMasterEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ScrumMasters
                        .Single(e => e.ScrumMasterId == model.ScrumMasterId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
