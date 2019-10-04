using Clubber.Data;
using Clubber.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.services
{
    public class ClubService
    {
        private readonly Guid _userId;

        public ClubService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNewClubMember(int clubId, int studentId)
        {
            var entity =
                new StudentAndClub() {
                    // Should there be a student id related to the login?
                    //StudentID = UserId? Enabled this by creating
                    // a student profile

                    ClubID = clubId,
                    StudentID = studentId
                    };
                using (var ctx = new ApplicationDbContext())
                    {
                        ctx.StudentClubs.Add(entity);
                        return ctx.SaveChanges() == 1;
                    }
        }


        public bool CreateClub(ClubCreate model)
        {
            var entity =
                new Club() {
                    Title = model.Title,
                    MeetingDay = model.MeetingDay,
                    MeetingTime = model.Time,
                    SponsorId = model.SponsorId,
                 //   Sponsor= model.Sponsor
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clubs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public Sponsor GetSponsorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sponsors
                        .Single(e => e.SponsorId == id);
                return
                    new Sponsor
                    {
                        SponsorId = entity.SponsorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        BackGroundCheck = entity.BackGroundCheck
                    };
            }
        }


        public IEnumerable<ClubListItem> GetClubs()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .Clubs
                        .Select(
                            e =>
                                new ClubListItem
                                {
                                    ClubId = e.ClubId,
                                    Title = e.Title,
                                    MeetingDay = e.MeetingDay,
                                    MeetingTime = e.MeetingTime,
                                    SponsorName = e.Sponsor.FirstName + " " + e.Sponsor.LastName,
                                    // IsMemberOf NEEDS TO BE DONE
                                }
                        );
                var allItems = query.ToArray();
                return query.ToArray();
            }
        }

        public bool UpdateClub(ClubEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clubs
                        .Single(e => e.ClubId == model.ClubId);

                    entity.Title = model.Title;
                    entity.MeetingDay = model.MeetingDay;
                    entity.MeetingTime = model.MeetingTime;
                entity.SponsorId = model.SponsorId;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteClub(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clubs
                        .Single(e => e.ClubId == Id);

                ctx.Clubs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        // For details
        public ClubDetail GetClubById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clubs
                        .Single(e => e.ClubId == id);
                return
                    new ClubDetail
                    {
                        ClubId = entity.ClubId,
                        Title = entity.Title,
                        MeetingDay = entity.MeetingDay,
                        MeetingTime = entity.MeetingTime,
                        SponsorId = entity.SponsorId,
                        Sponsor = entity.Sponsor
                    };
            }
        }

        public IEnumerable<Sponsor> GetSponsors()
        {
            List<Sponsor> sponsors = new List<Sponsor>();
            Sponsor admin = new Sponsor();
            admin.SponsorId = 1;
            admin.FirstName = "Julia";
            admin.LastName = "Brady";

            sponsors.Add(admin);

            Sponsor admin1 = new Sponsor();
            admin.SponsorId = 2;
            admin.FirstName = "Liam";
            admin.LastName = "Brady";
            sponsors.Add(admin1);

            return sponsors.ToArray();
        }


        // Absolutely in the wrong place!! Just a convenience method
        // Clubs should not be able to add new students, as this is central to admin
        public bool CreateStudent(Student model)
        {
            var entity =
                new Student()
                {
                    StudentFirstName = model.StudentFirstName,
                    StudentLastName = model.StudentLastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }



        private Student GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var hasEntity =
                    ctx
                        .Students
                        .Any(e => e.StudentId == id);

                if (!(hasEntity))
                    return null;

                var entity =
                    ctx
                     .Students
                     .Single(e => e.StudentId == id);



                return entity;

            }
        }

        public IEnumerable<Student> GetMembersOfClub(int id)
        {
            var ctx = new ApplicationDbContext();

            var query =
               ctx
                   .StudentClubs
                   .Where(e => e.ClubID == id).ToArray();
            var query2 = ctx.StudentClubs.ToArray(); ;


            List<Student> studentsInClub =
                    new List<Student>();
                foreach (StudentAndClub member in query)
                {
                Student student = member.Student;
                studentsInClub.Add(member.Student);
                }
            return studentsInClub;
        }

        public bool isAMember(int StudentId, int ClubId)
        {
            var ctx = new ApplicationDbContext();

            var query =
               ctx
                   .StudentClubs
                   .Single(e => e.ClubID == ClubId && e.StudentID == StudentId);

            return (query == null);
        }
    }

  
}
    

