using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalID { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public string FullName => $"{Name} {LastName}";
    }
}
