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
    public partial class AdminUsersForm : Form
    {
        public AdminUsersForm()
        {
            InitializeComponent();
            PopulateRolesCmb();
            PopulateNewlyRoles();
        }
        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedItem != null)
            {
                int selectedUserId = (int)comboBoxUsers.SelectedValue;

                DatabaseHelper.Instance.DeleteUser(selectedUserId);

                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateUser(User user)
        {
            if (user != null)
            {
                // Create an instance of the UpdateStudentForm passing the student details
                using (UpdateUserForm updateUsertForm = new UpdateUserForm(user))
                {
                    // Show the form as a dialog
                    DialogResult result = updateUsertForm.ShowDialog();

                    // Check if the user clicked OK in the dialog
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("User Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void PopulateRolesCmb()
        {
            // Assuming you have an instance of DatabaseHelper named databaseHelper
            var userroles = DatabaseHelper.Instance.GetAllRoles();

            // Sort roles alphabetically by RoleName
            userroles = userroles.OrderBy(r => r.RoleName).ToList();

            // Fill cmbNewlyUser with roles

            cmbUserRoles.DisplayMember = "RoleName";
            cmbUserRoles.ValueMember = "RoleId";
            cmbUserRoles.DataSource = userroles;
        }
        private void PopulateNewlyRoles()
        {
            var roles = DatabaseHelper.Instance.GetAllRoles();

            // Sort roles alphabetically by RoleName
            roles = roles.OrderBy(r => r.RoleName).ToList();

            cmbNewlyUser.DisplayMember = "RoleName";
            cmbNewlyUser.ValueMember = "RoleId";
            cmbNewlyUser.DataSource = roles;
        }
        private void addUserSingularBtn_Click(object sender, EventArgs e)
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

            // Get the selected role ID from cmbNewlyUser
            if (cmbNewlyUser.SelectedItem is Role selectedRole)
            {
                try
                {
                    // Pass the selected role ID to the AddStudent method
                    DatabaseHelper.Instance.AddUser(name, lastName, email, password, birthDate, personalId, selectedRole.RoleId);

                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a role for the User.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbUserRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbUserRoles.SelectedValue != null)
            {
                int selectedRoleId = (int)cmbUserRoles.SelectedValue;
                UpdateComboBoxUsers(selectedRoleId);
            }
        }
        private void UpdateComboBoxUsers(int roleId)
        {
            // Get users based on the selected role ID using your DatabaseHelper method
            var users = DatabaseHelper.Instance.GetUsersByRoleId(roleId);

            users = users.OrderBy(u => u.FullName).ToList();

            comboBoxUsers.DisplayMember = "FullName";
            comboBoxUsers.ValueMember = "UserId";
            comboBoxUsers.DataSource = users;
        }
        private void updateUserBtn_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedItem != null)
            {
                // Get the selected user's ID
                int selectedUserId = (int)comboBoxUsers.SelectedValue;

                // Use the DatabaseHelper to get the user by ID
                var userToUpdate = DatabaseHelper.Instance.GetUserById(selectedUserId);

                // Check if the user exists
                if (userToUpdate != null)
                {
                    // Call the UpdateUser method passing the userToUpdate
                    UpdateUser(userToUpdate);

                    // Optionally, refresh or update your user interface
                    // UpdateComboBoxUsers(selectedRoleId); // You may need to update the combo boxes
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Selected user not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
