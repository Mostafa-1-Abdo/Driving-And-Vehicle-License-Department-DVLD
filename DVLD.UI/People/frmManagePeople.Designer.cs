namespace DVLD.UI
{
    partial class frmManagePeople
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
            this.ctrlManageData1.btn_AddImage = global::DVLD.UI.Properties.Resources.AddNewPerson;
            this.ctrlManageData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageData1.lb_TitleText = "Manage People";
            this.ctrlManageData1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageData1.Name = "ctrlManageData1";
            this.ctrlManageData1.pb_HeaderImage = global::DVLD.UI.Properties.Resources.ManagePeople;
            this.ctrlManageData1.Size = new System.Drawing.Size(1198, 609);
            this.ctrlManageData1.TabIndex = 0;
            this.ctrlManageData1.CloseClicked += new System.Action(this.ctrlManageData_OnCloseClick);
            this.ctrlManageData1.AddClicked += new System.Action(this.ctrlManageData_OnAddClick);
            this.ctrlManageData1.SearchTextChanged += new System.Action<string, string>(this.ctrlManageData_SearchTextChanged);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 609);
            this.Controls.Add(this.ctrlManageData1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManagePeople";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlManageData ctrlManageData1;
    }
}