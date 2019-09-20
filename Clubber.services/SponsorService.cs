using Clubber.Data;
using Clubber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.services
{
    public class SponsorService
    {
        private readonly Guid _userId;

        public SponsorService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateSponsor(SponsorCreateView model)
        {
            var entity =
                new Sponsor()
                {
                    BackGroundCheck = model.BackGroundCheck,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sponsors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SponsorListItem> GetSponsors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sponsors
                        .Select(
                            e =>
                               new SponsorListItem
                               {
                                   SponsorId = e.SponsorId,
                                   FirstName = e.FirstName,
                                   LastName = e.LastName,
                                   BackGroundCheck = e.BackGroundCheck
                               }
                            );

                return query.ToArray();
            }

        }

    }
}
