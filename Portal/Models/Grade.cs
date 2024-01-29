using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeValue { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
