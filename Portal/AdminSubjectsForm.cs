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
    public partial class AdminSubjectsForm : Form
    {
        public AdminSubjectsForm()
        {
            InitializeComponent();
        }
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the subject name from the TextBox
                string subjectName = txtSubjectName.Text;

                // Ensure the subject name is not empty
                if (string.IsNullOrWhiteSpace(subjectName))
                {
                    MessageBox.Show("Please enter a valid subject name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Use the DatabaseHelper to add a new subject with default lessons
                DatabaseHelper.Instance.AddSubjectWithDefaultLessons(subjectName);

                // Display a success message
                MessageBox.Show("Subject added successfully with default lessons.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the TextBox after adding the subject
                txtSubjectName.Clear();
                UpdateSubjectsDropdown();
            }
            catch (InvalidOperationException ex)
            {
                // Handle the case where a subject with the same name already exists
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Subject> GetAllSubjects()
        {
            return DatabaseHelper.Instance.GetAllSubjects().OrderBy(subject => subject.SubjectName).ToList();
        }
        private void UpdateSubjectsDropdown()
        {
            // Get all subjects from the database
            List<Subject> subjects = GetAllSubjects();

            cmbSubjects.DataSource = null;
            cmbSubjects.Items.Clear();

            // Populate the ComboBox with subject names
            cmbSubjects.DisplayMember = "SubjectName";
            cmbSubjects.ValueMember = "SubjectId";
            cmbSubjects.DataSource = subjects;
        }
        private void AdminSubjectsForm_Load(object sender, EventArgs e)
        {
            UpdateSubjectsDropdown();
        }
        private void btnLoadLessons_Click(object sender, EventArgs e)
        {
            FillLessonsGridView();
        }
        private void FillLessonsGridView()
        {
            Subject selectedSubject = (Subject)cmbSubjects.SelectedItem;

            // Assuming dataGridViewLessons is the DataGridView instance
            dataGridViewLessons.Rows.Clear();
            dataGridViewLessons.Columns.Clear(); // Clear existing columns

            // Use the GetLessonsForSubject method from DatabaseHelper to get lessons
            List<Lesson> lessons = DatabaseHelper.Instance.GetLessonsForSubject(selectedSubject.SubjectId);

            // Add columns for each lesson
            foreach (var lesson in lessons)
            {
                var column = new DataGridViewTextBoxColumn();

                // Set the column header (lesson name)
                column.HeaderText = lesson.LessonName;

                // Set the custom property to store LessonId
                column.Tag = lesson.LessonId;

                // Add the column to the DataGridView
                dataGridViewLessons.Columns.Add(column);
            }

            // Add a new row for lesson names
            dataGridViewLessons.Rows.Add();

            // Set lesson names in the second row (cells)
            for (int i = 0; i < lessons.Count; i++)
            {
                dataGridViewLessons.Rows[0].Cells[i].Value = lessons[i].LessonName;
            }
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            // Assuming dataGridViewLessons is the DataGridView instance
            List<Lesson> updatedLessons = new List<Lesson>();

            // Iterate through columns to get lesson names
            foreach (DataGridViewColumn column in dataGridViewLessons.Columns)
            {
                // Retrieve LessonId from the custom property
                int lessonId = (int)column.Tag;

                // Retrieve LessonName from the DataGridViewColumn header (first row)
                string lessonNameToUpdate = dataGridViewLessons.Rows[0].Cells[column.Index].Value?.ToString();

                // Create Lesson objects with updated names
                Lesson lesson = new Lesson { LessonId = lessonId, LessonName = lessonNameToUpdate };
                updatedLessons.Add(lesson);
            }

            // Update lesson names in the database
            DatabaseHelper.Instance.UpdateLessonNames(updatedLessons);

            MessageBox.Show("Lesson names updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FillLessonsGridView();
        }
        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedItem != null)
            {
                Subject selectedSubject = (Subject)cmbSubjects.SelectedItem;

                // Delete the selected subject
                DatabaseHelper.Instance.DeleteSubject(selectedSubject.SubjectId);

                UpdateSubjectsDropdown();

                MessageBox.Show("Subject deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a subject to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
