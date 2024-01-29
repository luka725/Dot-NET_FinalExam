namespace Portal.Migrations
{
    using Portal.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using Bogus;
    using Portal.Classes;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<PortalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(PortalDbContext context)
        {
            SeedAsync(context).Wait();
        }
        private async Task SeedAsync(PortalDbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    await SeedRolesAsync(context);
                    await SeedUsersAsync(context);
                    await SeedSubjectsAsync(context);
                    await SeedEnrollmentsAsync(context);
                    await SeedLessonsAsync(context);
                    await SeedGradesAsync(context);

                    await context.SaveChangesAsync();

                    transaction.Commit(); // Commit the transaction if everything succeeds
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during seeding: {ex.Message}");
                    transaction.Rollback(); // Rollback the transaction in case of an exception
                }
            }
        }
        private async Task SeedRolesAsync(PortalDbContext context)
        {
            var roles = new List<Role>
            {
            new Role { RoleName = "Student" },
            new Role { RoleName = "Lecturer" },
            new Role { RoleName = "Administrator" }
            };
            context.Roles.AddRange(roles);
            await context.SaveChangesAsync();
        }
        private async Task SeedUsersAsync(PortalDbContext context)
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Name, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName)
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.PasswordHash, f => Methods.HashPassword("password"))
                .RuleFor(u => u.BirthDate, f => f.Person.DateOfBirth)
                .RuleFor(u => u.PersonalID, f => f.Random.AlphaNumeric(11))
                .RuleFor(u => u.RoleId, context.Roles.First(r => r.RoleName == "Student").RoleId);

            var administrator = new User
            {
                Name = "Admin",
                LastName = "Admin",
                Email = "admin@example.com",
                PasswordHash = Methods.HashPassword("adminadmin"),
                BirthDate = DateTime.UtcNow,
                PersonalID = "1234567890",
                RoleId = context.Roles.First(r => r.RoleName == "Administrator").RoleId // Set the role for the administrator
            };

            var studentUsers = userFaker.Generate(200);
            var lecturerUsers = userFaker.Generate(20);

            // Manually set the RoleId for lecturer users to 2 (Lecturer)
            lecturerUsers.ForEach(lecturer => lecturer.RoleId = context.Roles.First(r => r.RoleName == "Lecturer").RoleId);

            var allUsers = studentUsers.Concat(lecturerUsers).Concat(new[] { administrator }).ToList();

            context.Users.AddRange(allUsers);
            await context.SaveChangesAsync();
        }
        private async Task SeedSubjectsAsync(PortalDbContext context)
        {
            var subjectFaker = new Faker<Subject>()
                .RuleFor(s => s.SubjectName, f => f.Name.JobTitle());

            var subjects = subjectFaker.Generate(20); // Generate 20 subjects

            context.Subjects.AddRange(subjects);
            await context.SaveChangesAsync();
        }
        private async Task SeedEnrollmentsAsync(PortalDbContext context)
        {
            var lecturerRoleName = "Lecturer";
            var studentRoleName = "Student";

            var subjects = context.Subjects.ToList();

            var lecturers = context.Users
                .Where(u => u.Role.RoleName == lecturerRoleName)
                .Take(subjects.Count)
                .ToList();

            var students = context.Users
                .Where(u => u.Role.RoleName == studentRoleName)
                .ToList();

            var enrollments = new List<Enrollment>();

            // Assign one unique lecturer to each subject
            for (int i = 0; i < subjects.Count; i++)
            {
                var lecturer = lecturers[i % lecturers.Count]; // Use modulo to cycle through lecturers

                var enrollment = new Enrollment
                {
                    SubjectId = subjects[i].SubjectId,
                    UserId = lecturer.UserId,
                    IsLecturer = true
                };

                enrollments.Add(enrollment);
            }

            foreach (var student in students)
            {
                // Shuffle the subjects to randomly select them
                var shuffledSubjects = subjects.OrderBy(s => Guid.NewGuid()).ToList();

                // Take at least 5 subjects
                var selectedSubjects = shuffledSubjects.Take(5).ToList();

                foreach (var subject in selectedSubjects)
                {
                    var enrollment = new Enrollment
                    {
                        SubjectId = subject.SubjectId,
                        UserId = student.UserId,
                        IsLecturer = false
                    };

                    enrollments.Add(enrollment);
                }
            }


            context.Enrollments.AddRange(enrollments);
            await context.SaveChangesAsync();
        }
        private async Task SeedLessonsAsync(PortalDbContext context)
        {
            var subjects = context.Subjects.ToList();
            var lessons = new List<Lesson>();

            foreach (var subject in subjects)
            {
                for (int weekNumber = 1; weekNumber <= 14; weekNumber++)
                {
                    var lesson = new Lesson
                    {
                        LessonName = $"Week{weekNumber}",
                        SubjectId = subject.SubjectId
                    };

                    lessons.Add(lesson);
                }
            }

            context.Lessons.AddRange(lessons);
            await context.SaveChangesAsync();
        }
        private async Task SeedGradesAsync(PortalDbContext context)
        {
            var random = new Random();
            var enrollments = await context.Enrollments
             .Include(e => e.Subject)
             .Include(e => e.User)
             .ToListAsync();

            var grades = new List<Grade>();

            foreach (var enrollment in enrollments)
            {
                var lessonsForSubject = await context.Lessons
                    .Where(l => l.SubjectId == enrollment.SubjectId)
                    .ToListAsync();

                foreach (var lesson in lessonsForSubject)
                {
                    var grade = new Grade
                    {
                        LessonId = lesson.LessonId,
                        UserId = enrollment.UserId,
                        GradeValue = random.Next(0, 20).ToString()
                    };

                    grades.Add(grade);
                }
            }

            context.Grades.AddRange(grades);
            await context.SaveChangesAsync();
        }   
    }
}
