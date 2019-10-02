using Clubber.Data;
using Clubber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// What is a student profile for?
// Later, maybe for highlihting clubs that correspond to hobbies, maybe for restricting parent access?
//
namespace Clubber.services
{
    public class StudentProfileService
    {
        private readonly Guid _userId;

        public StudentProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProfile(StudentProfileCreate model)
        {
            var entity =
                new StudentProfile()
                {
                    UserId = model.UserId,
                    StudentId = model.StudentId,
                    Hobby1 = model.Hobby1,
                    Hobby2 = model.Hobby2,
                    Hobby3 = model.Hobby3
                };

            var ctx = new ApplicationDbContext();
            ctx.StudentProfiles.Add(entity);
            bool ret = (ctx.SaveChanges() == 1);

            return ret;
            
        }

        public bool hasStudentProfile(Guid userId)
        {
            StudentProfile studentProfile = GetStudentProfileById(userId);
            if (!(studentProfile == null))
                return true;
            else
                return false;
        }

        public StudentProfile GetStudentProfileById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var hasEntity =
                    ctx
                        .StudentProfiles
                        .Any(e => e.UserId == id);

                if (!(hasEntity))
                    return null;

                var entity =
                    ctx
                     .StudentProfiles
                     .Single(e => e.UserId == id);
                new StudentProfile
                {
                    UserId = entity.UserId,
                    StudentId = entity.StudentId,
                    Hobby1 = entity.Hobby1,
                    Hobby2 = entity.Hobby2,
                    Hobby3 = entity.Hobby3
                };

                return entity;

            }
        }
    }
}
