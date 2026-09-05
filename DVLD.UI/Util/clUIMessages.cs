using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UI.Util
{
    internal class clUIMessages
    {
        public static void ShowFeatureNotImplemented() => MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        public static void ShowNotFound(string EntityName, object ID) => MessageBox.Show($"No {EntityName} with ID = {ID} was found in the system.", $"{EntityName} Not Found",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        public static void ShowValidationError() => MessageBox.Show("Some fields are not valid. Please check the red error icons.", "Validation Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowSaveError() => MessageBox.Show("Error: Data was not saved successfully.", "Error",
           MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowImageProcessingError(string message) => MessageBox.Show(message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowSaveSuccess() => MessageBox.Show("Data Saved Successfully.", "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowDeleteSuccess(string EntityName) => MessageBox.Show($"{EntityName} Deleted Successfully.", "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowDeleteFailedLinkedData(string EntityName) => MessageBox.Show($"{EntityName} was not deleted because it has data linked to it.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool ShowConfirmDelete(string EntityName, object ID) => MessageBox.Show($"Are you sure you want to delete {EntityName} [{ID}]?", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK;

        public static void ShowSelectPersonRequired() => MessageBox.Show("Please select or add a person first before proceeding to Login Information.", "Select Person Required",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void ShowDuplicateUserAccount() => MessageBox.Show("Selected person already has an associated user account. Please choose another person.", "Duplicate User",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowPasswordChangedSuccess() => MessageBox.Show("Password changed successfully.", "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowPasswordChangeFailed() => MessageBox.Show("Failed to change password. Please try again.", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowCannotDeleteCurrentUser() => MessageBox.Show("You cannot delete the currently logged-in user.", "Action Not Allowed",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
