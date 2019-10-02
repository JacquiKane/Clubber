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
    public class ClubMemberService
    {
        private readonly Guid _userId;

        public ClubMemberService(Guid userId)
        {
            _userId = userId;
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
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                   ctx
                       .StudentClubs
                       .Where(e => e.ClubID == id);

                IEnumerable<Student> studentsInClub = 
                    new Collection<Student>();
                foreach (StudentAndClub member in query)
                {
                    Student student = GetStudentById(member.StudentID);
                    student.StudentFirstName = student.StudentFirstName;
                    student.StudentLastName = student.StudentLastName;
                    studentsInClub.Append(student);
                }

                return studentsInClub.ToArray();
            }
    }
    }
}
