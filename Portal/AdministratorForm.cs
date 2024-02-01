using Bogus.DataSets;
using Portal.Classes;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portal
{
    public partial class AdministratorForm : Form
    {
        public UserAuthenticationResult data;
        private const string UserEntityType = "User";
        private const string SubjectEntityType = "Subject";
        private const string EnrollmentEntityType = "Enrollment";
        public AdministratorForm(UserAuthenticationResult data)
        {
            InitializeComponent();
            this.data = data;
            PopulateCmbSubjects();
        }
        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"Welcome {data.FirstName} {data.LastName}";
            cmbEntityType.Items.AddRange(new string[] { "User", "Subject", "Enrollment" });

            // Set the default selection
            cmbEntityType.SelectedIndex = 0; // Select "Student" by default

            // Event handler for ComboBox selection change
            cmbEntityType.SelectedIndexChanged += cmbEntityType_SelectedIndexChanged;
            PopulateGrid();
        }
        private void PopulateCmbSubjects()
        {
            List<Subject> subjects = DatabaseHelper.Instance.GetAllSubjects();
            cmbSubjects.DisplayMember = "SubjectName";
            cmbSubjects.ValueMember = "SubjectId";
            cmbSubjects.DataSource = subjects;
        }
        private void PopulateGrid()
        {
            dgvStudentsSubjects.Rows.Clear();
            dgvStudentsSubjects.Columns.Clear();
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;
            if (selectedSubject != null)
            {
                dgvStudentsSubjects.Rows.Clear();
                dgvStudentsSubjects.Columns.Clear();
                // Get lessons for the selected subject
                var students = DatabaseHelper.Instance.GetEnrolledUsersForSubject(selectedSubject.SubjectId);
                var lessons = DatabaseHelper.Instance.GetLessonsForSubject(selectedSubject.SubjectId);
                var grades = DatabaseHelper.Instance.GetGradesForUsersAndLessons(students.Select(student => student.UserId).ToList(), lessons.Select(lesson => lesson.LessonId).ToList());

                dgvStudentsSubjects.Columns.Add("StudentName", "Student Name");

                // Add columns for lesson names
                foreach (var lesson in lessons)
                {
                    dgvStudentsSubjects.Columns.Add($"Lesson{lesson.LessonId}", lesson.LessonName);
                }

                // Add rows for each student
                foreach (var student in students)
                {
                    var rowIndex = dgvStudentsSubjects.Rows.Add();
                    dgvStudentsSubjects.Rows[rowIndex].Cells["StudentName"].Value = $"{student.Name} {student.LastName}";

                    foreach (var lesson in lessons)
                    {
                        var gradeForLesson = grades.FirstOrDefault(grade => grade.LessonId == lesson.LessonId && grade.UserId == student.UserId);

                        if (gradeForLesson != null)
                        {
                            dgvStudentsSubjects.Rows[rowIndex].Cells[$"Lesson{lesson.LessonId}"].Value = gradeForLesson.GradeValue;
                        }
                    }
                }

                dgvStudentsSubjects.AutoResizeColumns();
            }

            dgvStudentsSubjects.AutoResizeColumns();
            dgvStudentsSubjects.AutoResizeRows();
        }
        private void PopulateGridSingular()
        {
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;
            User selectedStudent = cmbStudents.SelectedItem as User;

            if (selectedSubject != null & selectedStudent != null)
            {
                // Get lessons for the selected subject
                var lessons = DatabaseHelper.Instance.GetLessonsForSubject(selectedSubject.SubjectId);
                var grades = DatabaseHelper.Instance.GetGradesForUserAndLessons(selectedStudent.UserId, lessons.Select(lesson => lesson.LessonId).ToList());

                dgvStudentsSubjects.Rows.Clear();
                dgvStudentsSubjects.Columns.Clear();

                // Add columns for subject names
                dgvStudentsSubjects.Columns.Add("SubjectName", $"{selectedSubject.SubjectName}");

                // Add columns for lesson names
                foreach (var lesson in lessons)
                {
                    dgvStudentsSubjects.Columns.Add($"Lesson{lesson.LessonId}", lesson.LessonName);
                }

                // Add rows

                var rowIndexGrades = dgvStudentsSubjects.Rows.Add();
                dgvStudentsSubjects.Rows[rowIndexGrades].Cells["SubjectName"].Value = selectedSubject.SubjectName;

                foreach (var lesson in lessons)
                {
                    foreach (var gradeForLesson in grades)
                    {
                        if (gradeForLesson.LessonId == lesson.LessonId)
                        {
                            dgvStudentsSubjects.Rows[rowIndexGrades].Cells[$"Lesson{lesson.LessonId}"].Value = gradeForLesson.GradeValue;
                        }
                    }
                }
                dgvStudentsSubjects.AutoResizeColumns();
            }
        }
        private void AdministratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void cmbEntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEntityType = cmbEntityType.SelectedItem.ToString();

            switch (selectedEntityType)
            {
                case "User":
                    break;
                case "Subject":
                    break;
                case "Enrollment":
                    break;
                default:
                    break;
            }
        }
        private void selectBtn_Click(object sender, EventArgs e)
        {
            string selectedEntityType = cmbEntityType.SelectedItem.ToString();

            // Open the corresponding form based on the selected entity type
            switch (selectedEntityType)
            {
                case UserEntityType:
                    OpenStudentForm();
                    break;
                case EnrollmentEntityType:
                    OpenEnrollmentForm();
                    break;
                case SubjectEntityType:
                    OpenSubjectForm();
                    break;
                default:
                    break;
            }
        }
        private void OpenStudentForm()
        {
            AdminUsersForm studentForm = new AdminUsersForm();
            studentForm.Show();
        }
        private void OpenEnrollmentForm() 
        { 
            AdminEnrollmentsForm enrollmentsForm = new AdminEnrollmentsForm();
            enrollmentsForm.Show();
        }
        private void OpenSubjectForm()
        {
           AdminSubjectsForm subjectForm = new AdminSubjectsForm();
           subjectForm.Show();
        }
        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;

            if (selectedSubject != null)
            {

                PopulateCmbStudents(selectedSubject.SubjectId);
                PopulateDgvLecturers(selectedSubject.SubjectId);
                PopulateGrid();

            }
        }
        private void PopulateCmbStudents(int subjectId)
        {
            cmbStudents.DataSource = null;
            List<User> students = DatabaseHelper.Instance.GetStudentsEnrolledInSubject(subjectId);

            cmbStudents.DisplayMember = "FullName";
            cmbStudents.ValueMember = "UserId";
            cmbStudents.DataSource = students;
        }
        private void PopulateDgvLecturers(int subjectId)
        {
            dgvLecturers.Columns.Clear();
            dgvLecturers.Rows.Clear();
            List<User> enrolledLecturers = DatabaseHelper.Instance.GetEnrolledLecturersForSubject(subjectId);

            // Add a column for Lecturers
            dgvLecturers.Columns.Add("Lecturers", "Lecturers");

            // Add rows for each enrolled lecturer
            foreach (User lecturer in enrolledLecturers)
            {
                dgvLecturers.Rows.Add(lecturer.FullName);
            }
        }
        private void viewGradesBtn_Click(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedItem == null)
            {
                MessageBox.Show("Please select a subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if a student is selected
            if (cmbStudents.SelectedItem == null)
            {
                MessageBox.Show("Please select a student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopulateGridSingular();
        }
        private void callReportBtn_Click(object sender, EventArgs e)
        {
            ReportViewerForm reportViewerForm = new ReportViewerForm();
            reportViewerForm.Show();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            PopulateCmbSubjects();
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;

            if (selectedSubject != null)
            {

                PopulateCmbStudents(selectedSubject.SubjectId);

            }
        }
    }
}
