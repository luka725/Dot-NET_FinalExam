using Portal.Classes;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portal
{
    public partial class LecturerForm : Form
    {
        public UserAuthenticationResult data;
        public LecturerForm(UserAuthenticationResult data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"Welcome {data.FirstName} {data.LastName}";
            var enrolledSubjects = DatabaseHelper.Instance.GetEnrolledSubjectsForLecturer(data.Id);
            cmbSubjects.DataSource = enrolledSubjects;
            cmbSubjects.DisplayMember = "SubjectName";
        }

        private void subjectBtn_Click(object sender, EventArgs e)
        {
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;
            if (selectedSubject != null)
            {
                dgvSubject.Rows.Clear();
                dgvSubject.Columns.Clear();
                // Get lessons for the selected subject
                var students = DatabaseHelper.Instance.GetEnrolledUsersForSubject(selectedSubject.SubjectId);
                var lessons = DatabaseHelper.Instance.GetLessonsForSubject(selectedSubject.SubjectId);
                var grades = DatabaseHelper.Instance.GetGradesForUsersAndLessons(students.Select(student => student.UserId).ToList(), lessons.Select(lesson => lesson.LessonId).ToList());

                dgvSubject.Columns.Add("StudentName", "Student Name");

                // Add columns for lesson names
                foreach (var lesson in lessons)
                {
                    dgvSubject.Columns.Add($"Lesson{lesson.LessonId}", lesson.LessonName);
                }

                // Add rows for each student
                foreach (var student in students)
                {
                    var rowIndex = dgvSubject.Rows.Add();
                    dgvSubject.Rows[rowIndex].Cells["StudentName"].Value = $"{student.Name} {student.LastName}";

                    foreach (var lesson in lessons)
                    {
                        var gradeForLesson = grades.FirstOrDefault(grade => grade.LessonId == lesson.LessonId && grade.UserId == student.UserId);

                        if (gradeForLesson != null)
                        {
                            dgvSubject.Rows[rowIndex].Cells[$"Lesson{lesson.LessonId}"].Value = gradeForLesson.GradeValue;
                        }
                    }
                }

                dgvSubject.AutoResizeColumns();
            }
        }

        private void LecturerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;
            var students = DatabaseHelper.Instance.GetEnrolledUsersForSubject(selectedSubject.SubjectId);
            var lessons = DatabaseHelper.Instance.GetLessonsForSubject(selectedSubject.SubjectId);
            // Iterate through DataGridView rows and update grades
            foreach (DataGridViewRow row in dgvSubject.Rows)
            {
                // Skip the row with column headers
                if (row.IsNewRow) continue;
                
                var studentName = row.Cells["StudentName"].Value.ToString();
                var student = students.FirstOrDefault(s => $"{s.Name} {s.LastName}" == studentName);

                if (student != null)
                {
                    foreach (var lesson in lessons)
                    {
                        var gradeCell = row.Cells[$"Lesson{lesson.LessonId}"];
                        var newGradeValue = gradeCell.Value?.ToString();

                        if (!string.IsNullOrEmpty(newGradeValue))
                        {
                            // Update or create a new grade record in the database
                            DatabaseHelper.Instance.UpdateOrCreateGrade(student.UserId, lesson.LessonId, newGradeValue);
                        }
                    }
                }
            }

            // Save changes to the database
            DatabaseHelper.Instance.SaveChanges();

            MessageBox.Show("Changes saved successfully!");
        }
    }
}
