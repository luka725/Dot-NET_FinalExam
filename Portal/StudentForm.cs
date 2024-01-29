using Bogus;
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
    public partial class StudentForm : Form
    {
        public UserAuthenticationResult data;
        public StudentForm(UserAuthenticationResult data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"Welcome {data.FirstName} {data.LastName}";
            var enrolledSubjects = DatabaseHelper.Instance.GetEnrolledSubjectsForStudent(data.Id);
            cmbSubjects.DataSource = enrolledSubjects;
            cmbSubjects.DisplayMember = "SubjectName";
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void getGradesBtn_Click(object sender, EventArgs e)
        {
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;

            if (selectedSubject != null)
            {
                // Get lessons for the selected subject
                var lessons = DatabaseHelper.Instance.GetLessonsForSubject(selectedSubject.SubjectId);
                var grades = DatabaseHelper.Instance.GetGradesForUserAndLessons(data.Id, lessons.Select(lesson => lesson.LessonId).ToList());

                dgvGrades.Rows.Clear();
                dgvGrades.Columns.Clear();

                // Add columns for subject names
                dgvGrades.Columns.Add("SubjectName", $"{selectedSubject.SubjectName}");

                // Add columns for lesson names
                foreach (var lesson in lessons)
                {
                    dgvGrades.Columns.Add($"Lesson{lesson.LessonId}", lesson.LessonName);
                }

                // Add rows

                var rowIndexGrades = dgvGrades.Rows.Add();
                dgvGrades.Rows[rowIndexGrades].Cells["SubjectName"].Value = "Grades";

                foreach (var lesson in lessons)
                {
                    foreach (var gradeForLesson in grades)
                    {
                        if (gradeForLesson.LessonId == lesson.LessonId)
                        {
                            dgvGrades.Rows[rowIndexGrades].Cells[$"Lesson{lesson.LessonId}"].Value = gradeForLesson.GradeValue;
                        }
                    }
                }
                dgvGrades.AutoResizeColumns();
            }
        }
    }
}
