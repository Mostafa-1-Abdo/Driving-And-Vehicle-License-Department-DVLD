namespace DVLD.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.msi_Applications = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_DrivingLicensesServices = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_NewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_LocalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_InternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_RenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.msi_ReplacementForLostOrDamagedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.msi_ReleaseDetainedDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_RetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.msi_ManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_LocalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.msi_DetainLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_ManageApplicationsTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_ManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_People = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_Drivers = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_Users = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_AccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.msi_CurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.White;
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_Applications,
            this.msi_People,
            this.msi_Drivers,
            this.msi_Users,
            this.msi_AccountSettings});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.MenuStrip.Size = new System.Drawing.Size(800, 56);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // msi_Applications
            // 
            this.msi_Applications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_DrivingLicensesServices,
            this.toolStripMenuItem1,
            this.msi_ManageApplications,
            this.toolStripMenuItem2,
            this.msi_DetainLicenses,
            this.msi_ManageApplicationsTypes,
            this.msi_ManageTestTypes});
            this.msi_Applications.Image = global::DVLD.UI.Properties.Resources.Applications;
            this.msi_Applications.Name = "msi_Applications";
            this.msi_Applications.Size = new System.Drawing.Size(118, 36);
            this.msi_Applications.Text = "Applications";
            // 
            // msi_DrivingLicensesServices
            // 
            this.msi_DrivingLicensesServices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_NewDrivingLicense,
            this.msi_RenewDrivingLicense,
            this.toolStripMenuItem3,
            this.msi_ReplacementForLostOrDamagedLicense,
            this.toolStripMenuItem4,
            this.msi_ReleaseDetainedDrivingLicense,
            this.msi_RetakeTest});
            this.msi_DrivingLicensesServices.Image = global::DVLD.UI.Properties.Resources.DriverLicenseServices;
            this.msi_DrivingLicensesServices.Name = "msi_DrivingLicensesServices";
            this.msi_DrivingLicensesServices.Size = new System.Drawing.Size(238, 38);
            this.msi_DrivingLicensesServices.Text = "Driving Licenses Services";
            // 
            // msi_NewDrivingLicense
            // 
            this.msi_NewDrivingLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_LocalLicense,
            this.msi_InternationalLicense});
            this.msi_NewDrivingLicense.Image = global::DVLD.UI.Properties.Resources.NewDrivingLicense;
            this.msi_NewDrivingLicense.Name = "msi_NewDrivingLicense";
            this.msi_NewDrivingLicense.Size = new System.Drawing.Size(325, 38);
            this.msi_NewDrivingLicense.Text = "New Driving License";
            // 
            // msi_LocalLicense
            // 
            this.msi_LocalLicense.Image = global::DVLD.UI.Properties.Resources.LocalLicense;
            this.msi_LocalLicense.Name = "msi_LocalLicense";
            this.msi_LocalLicense.Size = new System.Drawing.Size(206, 38);
            this.msi_LocalLicense.Text = "Local License";
            // 
            // msi_InternationalLicense
            // 
            this.msi_InternationalLicense.Image = global::DVLD.UI.Properties.Resources.InternationalLicense;
            this.msi_InternationalLicense.Name = "msi_InternationalLicense";
            this.msi_InternationalLicense.Size = new System.Drawing.Size(206, 38);
            this.msi_InternationalLicense.Text = "International License";
            // 
            // msi_RenewDrivingLicense
            // 
            this.msi_RenewDrivingLicense.Image = global::DVLD.UI.Properties.Resources.RenewDrivingLicense;
            this.msi_RenewDrivingLicense.Name = "msi_RenewDrivingLicense";
            this.msi_RenewDrivingLicense.Size = new System.Drawing.Size(325, 38);
            this.msi_RenewDrivingLicense.Text = "Renew Driving License";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(322, 6);
            // 
            // msi_ReplacementForLostOrDamagedLicense
            // 
            this.msi_ReplacementForLostOrDamagedLicense.Image = global::DVLD.UI.Properties.Resources.ReplacementForLostOrDamagedLicense;
            this.msi_ReplacementForLostOrDamagedLicense.Name = "msi_ReplacementForLostOrDamagedLicense";
            this.msi_ReplacementForLostOrDamagedLicense.Size = new System.Drawing.Size(325, 38);
            this.msi_ReplacementForLostOrDamagedLicense.Text = "Replacement for Lost or Damaged License";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(322, 6);
            // 
            // msi_ReleaseDetainedDrivingLicense
            // 
            this.msi_ReleaseDetainedDrivingLicense.Image = global::DVLD.UI.Properties.Resources.ReleaseDetainedDrivingLicense;
            this.msi_ReleaseDetainedDrivingLicense.Name = "msi_ReleaseDetainedDrivingLicense";
            this.msi_ReleaseDetainedDrivingLicense.Size = new System.Drawing.Size(325, 38);
            this.msi_ReleaseDetainedDrivingLicense.Text = "Release Detained Driving License";
            // 
            // msi_RetakeTest
            // 
            this.msi_RetakeTest.Image = global::DVLD.UI.Properties.Resources.RetakeTest;
            this.msi_RetakeTest.Name = "msi_RetakeTest";
            this.msi_RetakeTest.Size = new System.Drawing.Size(325, 38);
            this.msi_RetakeTest.Text = "Retake Test";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(235, 6);
            // 
            // msi_ManageApplications
            // 
            this.msi_ManageApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_LocalDrivingLicenseApplications,
            this.toolStripMenuItem7});
            this.msi_ManageApplications.Image = global::DVLD.UI.Properties.Resources.ManageApplications;
            this.msi_ManageApplications.Name = "msi_ManageApplications";
            this.msi_ManageApplications.Size = new System.Drawing.Size(238, 38);
            this.msi_ManageApplications.Text = "Manage Applications";
            // 
            // msi_LocalDrivingLicenseApplications
            // 
            this.msi_LocalDrivingLicenseApplications.Image = global::DVLD.UI.Properties.Resources.LocalDrivingLicenseApplications;
            this.msi_LocalDrivingLicenseApplications.Name = "msi_LocalDrivingLicenseApplications";
            this.msi_LocalDrivingLicenseApplications.Size = new System.Drawing.Size(276, 38);
            this.msi_LocalDrivingLicenseApplications.Text = "Local Driving License Applications";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::DVLD.UI.Properties.Resources.InternationalLicense;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(276, 38);
            this.toolStripMenuItem7.Text = "International License Applications";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(235, 6);
            // 
            // msi_DetainLicenses
            // 
            this.msi_DetainLicenses.Image = global::DVLD.UI.Properties.Resources.DetainLicenses;
            this.msi_DetainLicenses.Name = "msi_DetainLicenses";
            this.msi_DetainLicenses.Size = new System.Drawing.Size(238, 38);
            this.msi_DetainLicenses.Text = "Detain Licenses";
            // 
            // msi_ManageApplicationsTypes
            // 
            this.msi_ManageApplicationsTypes.Image = global::DVLD.UI.Properties.Resources.ManageApplicationTypes;
            this.msi_ManageApplicationsTypes.Name = "msi_ManageApplicationsTypes";
            this.msi_ManageApplicationsTypes.Size = new System.Drawing.Size(238, 38);
            this.msi_ManageApplicationsTypes.Text = "Manage Applications Types";
            // 
            // msi_ManageTestTypes
            // 
            this.msi_ManageTestTypes.Image = global::DVLD.UI.Properties.Resources.ManageTestTypes;
            this.msi_ManageTestTypes.Name = "msi_ManageTestTypes";
            this.msi_ManageTestTypes.Size = new System.Drawing.Size(238, 38);
            this.msi_ManageTestTypes.Text = "Manage Test Types";
            // 
            // msi_People
            // 
            this.msi_People.Image = global::DVLD.UI.Properties.Resources.People;
            this.msi_People.Name = "msi_People";
            this.msi_People.Size = new System.Drawing.Size(89, 36);
            this.msi_People.Text = "People";
            this.msi_People.Click += new System.EventHandler(this.msi_People_Click);
            // 
            // msi_Drivers
            // 
            this.msi_Drivers.Image = global::DVLD.UI.Properties.Resources.Drivers;
            this.msi_Drivers.Name = "msi_Drivers";
            this.msi_Drivers.Size = new System.Drawing.Size(92, 36);
            this.msi_Drivers.Text = "Drivers";
            this.msi_Drivers.Click += new System.EventHandler(this.msi_Drivers_Click);
            // 
            // msi_Users
            // 
            this.msi_Users.Image = global::DVLD.UI.Properties.Resources.Users;
            this.msi_Users.Name = "msi_Users";
            this.msi_Users.Size = new System.Drawing.Size(82, 36);
            this.msi_Users.Text = "Users";
            this.msi_Users.Click += new System.EventHandler(this.msi_Users_Click);
            // 
            // msi_AccountSettings
            // 
            this.msi_AccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_CurrentUserInfo,
            this.changePasswordToolStripMenuItem,
            this.toolStripMenuItem5,
            this.signOutToolStripMenuItem});
            this.msi_AccountSettings.Image = global::DVLD.UI.Properties.Resources.AccountSettings;
            this.msi_AccountSettings.Name = "msi_AccountSettings";
            this.msi_AccountSettings.Size = new System.Drawing.Size(146, 36);
            this.msi_AccountSettings.Text = "Account Settings";
            // 
            // msi_CurrentUserInfo
            // 
            this.msi_CurrentUserInfo.Image = global::DVLD.UI.Properties.Resources.CurrentUserInfo;
            this.msi_CurrentUserInfo.Name = "msi_CurrentUserInfo";
            this.msi_CurrentUserInfo.Size = new System.Drawing.Size(188, 38);
            this.msi_CurrentUserInfo.Text = "Current User Info";
            this.msi_CurrentUserInfo.Click += new System.EventHandler(this.msi_CurrentUserInfo_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLD.UI.Properties.Resources.ChangePassword;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(185, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::DVLD.UI.Properties.Resources.SignOut;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD.UI.Properties.Resources.MainBackground;
            this.pictureBox1.Location = new System.Drawing.Point(0, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 394);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVLD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem msi_Applications;
        private System.Windows.Forms.ToolStripMenuItem msi_People;
        private System.Windows.Forms.ToolStripMenuItem msi_Drivers;
        private System.Windows.Forms.ToolStripMenuItem msi_Users;
        private System.Windows.Forms.ToolStripMenuItem msi_AccountSettings;
        private System.Windows.Forms.ToolStripMenuItem msi_DrivingLicensesServices;
        private System.Windows.Forms.ToolStripMenuItem msi_NewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem msi_LocalLicense;
        private System.Windows.Forms.ToolStripMenuItem msi_InternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem msi_RenewDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem msi_ReplacementForLostOrDamagedLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem msi_ReleaseDetainedDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem msi_RetakeTest;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem msi_ManageApplications;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem msi_DetainLicenses;
        private System.Windows.Forms.ToolStripMenuItem msi_ManageApplicationsTypes;
        private System.Windows.Forms.ToolStripMenuItem msi_ManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem msi_CurrentUserInfo;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msi_LocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

