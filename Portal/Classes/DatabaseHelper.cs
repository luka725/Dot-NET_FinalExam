using Portal.Models;
using System;
using Portal.Classes;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        public User GetUserById(int userId)
        {
            return dbContext.Set<User>().SingleOrDefault(u => u.UserId == userId);
        }
        public string GetUserRole(int roleId)
        {
            var role = dbContext.Set<Role>().Find(roleId);

            return role?.RoleName;
        }
        public List<User> GetUsersByRoleId(int roleId)
        {
            var users = dbContext.Set<User>().Where(u => u.RoleId == roleId).ToList();

            return users;
        }
        public List<Role> GetAllRoles()
        {
            return dbContext.Set<Role>().ToList();
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
        public List<Subject> GetUnenrolledSubjectsForStudent(int studentId)
        {
            var enrolledSubjectIds = dbContext.Set<Enrollment>()
                .Where(e => e.UserId == studentId && !e.IsLecturer)
                .Select(e => e.SubjectId)
                .ToList();

            var unenrolledSubjects = dbContext.Set<Subject>()
                .Where(s => !enrolledSubjectIds.Contains(s.SubjectId))
                .ToList();

            return unenrolledSubjects;
        }
        public List<Subject> GetUnenrolledSubjectsForUser(int userid)
        {
            var enrolledSubjectIds = dbContext.Set<Enrollment>()
                .Where(e => e.UserId == userid)
                .Select(e => e.SubjectId)
                .ToList();

            var unenrolledSubjects = dbContext.Set<Subject>()
                .Where(s => !enrolledSubjectIds.Contains(s.SubjectId))
                .ToList();

            return unenrolledSubjects;
        }
        public List<Subject> GetEnrolledSubjectsForUser(int userid)
        {
            var enrolledSubjects = dbContext.Set<Enrollment>()
                .Where(e => e.UserId == userid)
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
        public void AddStudent(string name, string lastName, string email, string password, string personalId, DateTime birthDate)
        {
            // Create a new User instance
            var newUser = new User
            {
                Name = name,
                LastName = lastName,
                Email = email,
                PasswordHash = Methods.HashPassword(password),
                PersonalID = personalId,
                BirthDate = birthDate,
                RoleId = GetRoleIdForStudent()
            };

            // Add the user to the database
            dbContext.Set<User>().Add(newUser);

            // Save changes to the database
            SaveChanges();
        }
        public int GetRoleIdForStudent()
        {
            var studentRole = dbContext.Set<Role>().SingleOrDefault(r => r.RoleName == "Student");

            if (studentRole != null)
            {
                return studentRole.RoleId;
            }
            return 0;
        }
        public List<User> GetStudentsByFullName(string fullName)
        {
            return dbContext.Set<User>()
                .Where(u => u.Role.RoleName == "Student" &&
                            (u.Name + " " + u.LastName).Contains(fullName))
                .ToList();
        }
        public void RemoveStudent(User student)
        {
            dbContext.Set<User>().Remove(student);
            SaveChanges();
        }
        public User GetStudentById(int studentId)
        {
            return dbContext.Set<User>().SingleOrDefault(u => u.UserId == studentId);
        }
        public void UpdateStudent(User updatedStudent)
        {
            // Get the existing student from the database
            var existingStudent = dbContext.Set<User>().SingleOrDefault(u => u.UserId == updatedStudent.UserId);

            if (existingStudent != null)
            {
                // Update the existing student's properties
                existingStudent.Name = updatedStudent.Name;
                existingStudent.LastName = updatedStudent.LastName;
                existingStudent.Email = updatedStudent.Email;
                existingStudent.PersonalID = updatedStudent.PersonalID;
                existingStudent.BirthDate = updatedStudent.BirthDate;

                // Check if a new password is provided
                if (!string.IsNullOrEmpty(updatedStudent.PasswordHash))
                {
                    // Update the password if a new one is provided
                    existingStudent.PasswordHash = updatedStudent.PasswordHash;
                }

                // Save changes to the database
                SaveChanges();
            }
            else
            {
            }
        }
        public List<User> GetLecturers()
        {
            // Replace "Lecturer" with the actual role name for lecturers
            string lecturerRoleName = "Lecturer";

            // Retrieve a list of lecturers based on their role name
            return dbContext.Set<User>()
                .Where(u => u.Role.RoleName == lecturerRoleName)
                .ToList();
        }
        public List<User> GetStudents()
        {
            // Replace "Student" with the actual role name for students
            string studentRoleName = "Student";

            // Retrieve a list of students based on their role name
            return dbContext.Set<User>()
                .Where(u => u.Role.RoleName == studentRoleName)
                .ToList();
        }
        public void EnrollUserForSubject(int userId, int subjectId, bool isLecturer)
        {
            // Check if the user is already enrolled for the subject
            if (!IsUserEnrolledForSubject(userId, subjectId, isLecturer))
            {
                // Create a new enrollment
                var enrollment = new Enrollment
                {
                    UserId = userId,
                    SubjectId = subjectId,
                    IsLecturer = isLecturer
                };

                // Add the enrollment to the context
                dbContext.Set<Enrollment>().Add(enrollment);

                // Save changes to the database
                SaveChanges();
            }
        }
        private bool IsUserEnrolledForSubject(int userId, int subjectId, bool isLecturer)
        {
            // Check if the user is already enrolled for the subject
            return dbContext.Set<Enrollment>().Any(e =>
                e.UserId == userId &&
                e.SubjectId == subjectId &&
                e.IsLecturer == isLecturer
            );
        }
        public void UnenrollUserFromSubject(int userId, int subjectId, bool isLecturer)
        {
            // Find the enrollment to unenroll the user
            var enrollment = dbContext.Set<Enrollment>().FirstOrDefault(e =>
                e.UserId == userId &&
                e.SubjectId == subjectId &&
                e.IsLecturer == isLecturer
            );

            // Check if the user is enrolled before attempting to unenroll
            if (enrollment != null)
            {
                // Remove the enrollment from the context
                dbContext.Set<Enrollment>().Remove(enrollment);

                // Save changes to the database
                SaveChanges();
            }
        }
        public void AddUser(string name, string lastName, string email, string password, DateTime birthDate, string personalId, int roleId)
        {
            if (IsEmailUnique(email))
            {
                // Create a new user instance
                var newUser = new User
                {
                    Name = name,
                    LastName = lastName,
                    Email = email,
                    PasswordHash = Methods.HashPassword(password),
                    BirthDate = birthDate,
                    PersonalID = personalId,
                    RoleId = roleId
                };

                // Add the new user to the context
                dbContext.Set<User>().Add(newUser);

                // Save changes to the database
                SaveChanges();
            }
            else
            {
                // Handle the case where the email is not unique (e.g., throw an exception, return an error)
                throw new InvalidOperationException("Email is already in use.");
            }
        }
        public void DeleteUser(int userId)
        {
            var userToDelete = dbContext.Set<User>().Find(userId);

            if (userToDelete != null)
            {
                dbContext.Set<User>().Remove(userToDelete);
                SaveChanges();
            }
        }
        public void AddSubjectWithDefaultLessons(string subjectName)
        {
            var existingSubject = dbContext.Set<Subject>().SingleOrDefault(s => s.SubjectName == subjectName);

            if (existingSubject != null)
            {
                // Subject with the same name already exists
                throw new InvalidOperationException("Subject with the same name already exists.");
            }

            // Create a new subject
            var newSubject = new Subject
            {
                SubjectName = subjectName
            };

            // Add the subject to the context
            dbContext.Set<Subject>().Add(newSubject);

            // Save changes to get the SubjectId
            SaveChanges();

            // Add default lessons for the subject
            for (int i = 1; i <= 14; i++)
            {
                var newLesson = new Lesson
                {
                    LessonName = $"Week {i}",
                    SubjectId = newSubject.SubjectId
                };

                // Add the lesson to the context
                dbContext.Set<Lesson>().Add(newLesson);
            }

            // Save changes to add default lessons
            SaveChanges();
        }
        public List<Subject> GetAllSubjects()
        {
            return dbContext.Set<Subject>().ToList();
        }
        public List<Lesson> GetLessonsForSubject(int subjectId)
        {
            return dbContext.Set<Lesson>().Where(lesson => lesson.SubjectId == subjectId).ToList();
        }
        public void UpdateLessonNames(List<Lesson> lessons)
        {
            foreach (var lesson in lessons)
            {
                // Find the lesson in the database
                var existingLesson = dbContext.Set<Lesson>().Find(lesson.LessonId);

                if (existingLesson != null)
                {
                    // Update the lesson name
                    existingLesson.LessonName = lesson.LessonName;

                    // Mark the lesson as modified
                    dbContext.Entry(existingLesson).State = EntityState.Modified;
                }
            }

            SaveChanges();
        }
        public void UpdateLessonName(Lesson updatedLesson)
        {
            var existingLesson = dbContext.Set<Lesson>().Find(updatedLesson.LessonId);

            if (existingLesson != null)
            {
                existingLesson.LessonName = updatedLesson.LessonName;
                dbContext.SaveChanges();
            }
            else
            {
                // Handle the case where the lesson with the given LessonId is not found
                throw new Exception($"Lesson with LessonId {updatedLesson.LessonId} not found.");
            }
        }
        public void DeleteSubject(int subjectId)
        {
            Subject subjectToDelete = dbContext.Set<Subject>().Find(subjectId);

            if (subjectToDelete != null)
            {
                dbContext.Set<Subject>().Remove(subjectToDelete);
                SaveChanges();
            }
        }
        public List<int> GetAllSubjectIds()
        {
            // Retrieve all subject IDs from the Subjects table
            List<int> subjectIds = dbContext.Set<Subject>().Select(s => s.SubjectId).ToList();

            return subjectIds;
        }
        public List<User> GetStudentsEnrolledInSubject(int subjectId)
        {
            List<User> enrolledStudents = new List<User>();

                    enrolledStudents = dbContext.Set<Enrollment>()
                        .Where(enrollment => enrollment.SubjectId == subjectId && !enrollment.IsLecturer)
                        .Select(enrollment => enrollment.User)
                        .ToList();

            return enrolledStudents;
        }
        public List<User> GetEnrolledLecturersForSubject(int subjectId)
        {
            var enrolledLecturers = dbContext.Set<Enrollment>()
                .Where(enrollment => enrollment.SubjectId == subjectId && enrollment.IsLecturer)
                .Select(enrollment => enrollment.User)
                .ToList();

            return enrolledLecturers;
        }
        public List<Lesson> GetLessonsBySubjectId(int subjectId)
        {
            List<Lesson> lessons = dbContext.Set<Lesson>()
                .Where(lesson => lesson.SubjectId == subjectId)
                .ToList();

            return lessons;
        }
        public List<Grade> GetGradesByLessonAndUserId(int lessonId, int userId)
        {
            List<Grade> grades = dbContext.Set<Grade>()
                .Where(grade => grade.LessonId == lessonId && grade.UserId == userId)
                .ToList();

            return grades;
        }
        private bool IsEmailUnique(string email)
        {
            // Check if there is any user with the given email in the database
            return !dbContext.Set<User>().Any(u => u.Email == email);
        }
        public List<Grade> GetGradesByLessonId(int lessonId)
        {
            // Assuming you have a DbSet<Grade> named "Grades" in your DbContext
            return dbContext.Set<Grade>()
                .Where(g => g.LessonId == lessonId)
                .ToList();
        }
        public List<SubjectAverage> GetSubjectAverages()
        {

               var subjectAverages = dbContext.Database.SqlQuery<SubjectAverage>("GetSubjectAverages").ToList();

            return subjectAverages;
        }
        public List<SubjectUserGradesSummary> GetSubjectUserGradeSummary()
        {
            var result = dbContext.Database.SqlQuery<SubjectUserGradesSummary>("GetSubjectUserGradeSummary").ToList();
            return result;
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
