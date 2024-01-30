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
    public partial class AdminStudentForm : Form
    {
        public AdminStudentForm()
        {
            InitializeComponent();
        }
        private void addStudentSingularBtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string personalId = txtPersonalId.Text;
            DateTime birthDate = dateTimePickerBirthDate.Value;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(personalId))
            {
                MessageBox.Show("All fields must be filled in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DatabaseHelper.Instance.AddStudent(name, lastName, email, password, personalId, birthDate);

                MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxStudents_DropDown(object sender, EventArgs e)
        {
            string searchText = comboBoxStudents.Text.Trim();

            // Filter items based on the entered text
            var filteredStudents = GetFilteredStudents(searchText);

            // Update the ComboBox items
            UpdateComboBoxItems(filteredStudents);
        }
        private List<string> GetFilteredStudents(string searchText)
        {
            // Query the database to get students whose full name contains the searchText
            var filteredStudents = DatabaseHelper.Instance.GetStudentsByFullName(searchText);

            // Extract full names from the filtered students
            var studentNames = filteredStudents.Select(student => $"{student.Name} {student.LastName}").ToList();

            return studentNames;
        }
        private void UpdateComboBoxItems(List<string> items)
        {
            // Clear existing items
            comboBoxStudents.Items.Clear();

            // Add the filtered items to the ComboBox
            comboBoxStudents.Items.AddRange(items.ToArray());
        }
        private void deleteStudentBtn_Click(object sender, EventArgs e)
        {
            // Ensure a student is selected in the comboBoxStudents
            if (comboBoxStudents.SelectedItem != null)
            {
                // Get the selected student's full name
                string selectedStudentFullName = comboBoxStudents.SelectedItem.ToString();

                // Use the DatabaseHelper to get the student by full name
                var studentToDelete = DatabaseHelper.Instance.GetStudentsByFullName(selectedStudentFullName).FirstOrDefault();

                // Check if the student exists
                if (studentToDelete != null)
                {
                    // Remove the student from the context
                    DatabaseHelper.Instance.RemoveStudent(studentToDelete);
                    MessageBox.Show("Student Removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Selected student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updateStudentBtn_Click(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem != null)
            {
                // Get the selected student's full name
                string selectedStudentFullName = comboBoxStudents.SelectedItem.ToString();

                // Use the DatabaseHelper to get the student by full name
                var studentToUpdate = DatabaseHelper.Instance.GetStudentsByFullName(selectedStudentFullName).FirstOrDefault();

                // Check if the student exists
                if (studentToUpdate != null)
                {
                    UpdateStudent(studentToUpdate);
                }
                else
                {
                    MessageBox.Show("Selected student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a student to Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateStudent(User student)
        {

            if (student != null)
            {
                // Create an instance of the UpdateStudentForm passing the student details
                using (UpdateStudentForm updateStudentForm = new UpdateStudentForm(student))
                {
                    // Show the form as a dialog
                    DialogResult result = updateStudentForm.ShowDialog();

                    // Check if the user clicked OK in the dialog
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("Student Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

    }
}
