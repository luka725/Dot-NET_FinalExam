﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
