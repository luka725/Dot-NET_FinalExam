using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
