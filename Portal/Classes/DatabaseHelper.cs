using Portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Classes
{
    public class DatabaseHelper
    {
        private static DatabaseHelper instance;

        private readonly DbContext dbContext;

        private DatabaseHelper(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public static DatabaseHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseHelper(new PortalDbContext());
                }
                return instance;
            }
        }

        public User GetUserByEmail(string email)
        {
            return dbContext.Set<User>().SingleOrDefault(u => u.Email == email);
        }

        public string GetUserRole(int roleId)
        {
            var role = dbContext.Set<Role>().Find(roleId);

            return role?.RoleName;
        }

        public UserAuthenticationResult AuthenticateUser(string email, string hashedPassword)
        {
            var user = GetUserByEmail(email);

            if (user != null && hashedPassword == user.PasswordHash)
            {
                var userRole = GetUserRole(user.RoleId);

                return new UserAuthenticationResult
                {
                    IsAuthenticated = true,
                    FirstName = user.Name,
                    LastName = user.LastName,
                    Role = userRole,
                    Id = user.UserId
                };
            }

            return new UserAuthenticationResult { IsAuthenticated = false };
        }
        public List<Subject> GetEnrolledSubjectsForStudent(int studentId)
        {
            var enrolledSubjects = dbContext.Set<Enrollment>()
                .Where(e => e.UserId == studentId && !e.IsLecturer)
                .Select(e => e.Subject)
                .ToList();

            return enrolledSubjects;
        }
        public List<Subject> GetEnrolledSubjectsForLecturer(int lecturerId)
        {
            var enrolledSubjects = dbContext.Set<Enrollment>()
                .Where(e => e.UserId == lecturerId && e.IsLecturer)
                .Select(e => e.Subject)
                .ToList();

            return enrolledSubjects;
        }
        public List<Lesson> GetLessonsForSubject(int subjectId)
        {
            var lessons = dbContext.Set<Lesson>()
                .Where(l => l.SubjectId == subjectId)
                .ToList();

            return lessons;
        }
        public List<Grade> GetGradesForUserAndLessons(int userId, List<int> lessonIds)
        {
            var grades = dbContext.Set<Grade>()
                .Where(g => g.UserId == userId && lessonIds.Contains(g.LessonId))
                .ToList();

            return grades;
        }
        public List<User> GetEnrolledUsersForSubject(int subjectId)
        {
            var enrolledUsers = dbContext.Set<Enrollment>()
                .Where(e => e.SubjectId == subjectId && !e.IsLecturer)
                .Select(e => e.User)
                .ToList();

            return enrolledUsers;
        }
        public List<Grade> GetGradesForUsersAndLessons(List<int> userIds, List<int> lessonIds)
        {
            var grades = dbContext.Set<Grade>()
                .Where(g => userIds.Contains(g.UserId) && lessonIds.Contains(g.LessonId))
                .ToList();

            return grades;
        }
        public void UpdateOrCreateGrade(int userId, int lessonId, string gradeValue)
        {
            var existingGrade = dbContext.Set<Grade>()
                .FirstOrDefault(g => g.UserId == userId && g.LessonId == lessonId);

            if (existingGrade != null)
            {
                // Update the existing grade
                existingGrade.GradeValue = gradeValue;
            }
            else
            {
                // Create a new grade
                var newGrade = new Grade
                {
                    UserId = userId,
                    LessonId = lessonId,
                    GradeValue = gradeValue
                };

                dbContext.Set<Grade>().Add(newGrade);
            }
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
