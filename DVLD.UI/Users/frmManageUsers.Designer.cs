namespace DVLD.UI.Users
{
    partial class frmManageUsers
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
            this.ctrlManageData1 = new DVLD.UI.ctrlManageData();
            this.SuspendLayout();
            // 
            // ctrlManageData1
            // 
            this.ctrlManageData1.btn_AddImage = global::DVLD.UI.Properties.Resources.AddNewUser;
            this.ctrlManageData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageData1.lb_TitleText = "Manage Users";
            this.ctrlManageData1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageData1.Name = "ctrlManageData1";
            this.ctrlManageData1.pb_HeaderImage = global::DVLD.UI.Properties.Resources.ManageUsers;
            this.ctrlManageData1.Size = new System.Drawing.Size(1188, 610);
            this.ctrlManageData1.TabIndex = 0;
            this.ctrlManageData1.CloseClicked += new System.Action(this.ctrlManageData_OnCloseClick);
            this.ctrlManageData1.AddClicked += new System.Action(this.ctrlManageData_OnAddClick);
            this.ctrlManageData1.SearchTextChanged += new System.Action<string, string>(this.ctrlManageData_SearchTextChanged);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 610);
            this.Controls.Add(this.ctrlManageData1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageUsers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlManageData ctrlManageData1;
    }
}