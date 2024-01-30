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
    public partial class AdminEnrollmentsForm : Form
    {
        public AdminEnrollmentsForm()
        {
            InitializeComponent();
            PopulateEnrollmentActionComboBox();
            PopulateCmbUsers();
        }
        private void PopulateCmbUsers()
        {
            cmbUsers.DataSource = null;
            cmbUsers.Items.Clear();
            cmbUsers.DisplayMember = "";
            cmbUsers.ValueMember = "";

            if (radioLecturer.Checked)
            {
                List<User> lecturers = DatabaseHelper.Instance.GetLecturers();
                lecturers = lecturers.OrderBy(u => u.FullName).ToList();
                cmbUsers.DisplayMember = "FullName";
                cmbUsers.ValueMember = "UserId";
                cmbUsers.DataSource = lecturers;
            }
            else if (radioStudent.Checked)
            {
                List<User> students = DatabaseHelper.Instance.GetStudents();
                students = students.OrderBy(u => u.FullName).ToList();
                cmbUsers.DisplayMember = "FullName";
                cmbUsers.ValueMember = "UserId";
                cmbUsers.DataSource = students;
            }
        }
        private void PopulateEnrollmentActionComboBox()
        {
            // Populate the ComboBox with enrollment actions
            cmbEnrollmentAction.Items.AddRange(new string[] { "Enroll", "Unenroll" });
            cmbEnrollmentAction.SelectedIndex = 0; // Default to "Enroll"
        }
        private void PopulateSubjectsBasedOnSelection()
        {
            // Get the selected user
            User selectedUser = cmbUsers.SelectedItem as User;

            // Check if a user is selected
            if (selectedUser != null)
            {
                // Get the action (Enroll or Unenroll)
                string action = cmbEnrollmentAction.SelectedItem.ToString();

                // Get the subjects based on the selected user and action
                List<Subject> subjects;

                if (action == "Enroll")
                {
                    subjects = DatabaseHelper.Instance.GetUnenrolledSubjectsForUser(selectedUser.UserId);
                }
                else if (action == "Unenroll")
                {
                    subjects = DatabaseHelper.Instance.GetEnrolledSubjectsForUser(selectedUser.UserId);
                }
                else
                {
                    return;
                }
                subjects = subjects.OrderBy(u => u.SubjectName).ToList();
                cmbSubjects.DisplayMember = "SubjectName";
                cmbSubjects.ValueMember = "SubjectId";
                cmbSubjects.DataSource = subjects;
            }
            else
            {
                // Reset cmbSubjects if no user is selected
                cmbSubjects.DataSource = null;
            }
        }
        private void radioLecturer_CheckedChanged(object sender, EventArgs e)
        {
            PopulateCmbUsers();
        }
        private void radioStudent_CheckedChanged(object sender, EventArgs e)
        {
            PopulateCmbUsers();
        }
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSubjectsBasedOnSelection();
        }
        private void cmbEnrollmentAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSubjectsBasedOnSelection();
        }
        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            int selectedUserId = (int)cmbUsers.SelectedValue;

            // Determine if the selected user is a lecturer based on the radio button
            bool isLecturer = radioLecturer.Checked;

            // Determine the action (Enroll or Unenroll)
            string selectedAction = cmbEnrollmentAction.SelectedItem.ToString();

            // Get the selected subject's ID
            int selectedSubjectId = (int)cmbSubjects.SelectedValue;

            // Enroll or unenroll based on the selected action
            if (selectedAction == "Enroll")
            {
                DatabaseHelper.Instance.EnrollUserForSubject(selectedUserId, selectedSubjectId, isLecturer);
                MessageBox.Show("User enrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedAction == "Unenroll")
            {
                DatabaseHelper.Instance.UnenrollUserFromSubject(selectedUserId, selectedSubjectId, isLecturer);
                MessageBox.Show("User unenrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
