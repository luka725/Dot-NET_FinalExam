using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public bool IsLecturer { get; set; }
    }

}
