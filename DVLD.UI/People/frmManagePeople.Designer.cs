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
            this.ctrlManageData = new DVLD.UI.ctrlManageData();
            this.SuspendLayout();
            // 
            // ctrlManageData
            // 
            this.ctrlManageData.btn_AddImage = global::DVLD.UI.Properties.Resources.AddNewPerson;
            this.ctrlManageData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageData.lb_TitleText = "Manage People";
            this.ctrlManageData.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageData.Name = "ctrlManageData";
            this.ctrlManageData.pb_HeaderImage = global::DVLD.UI.Properties.Resources.ManagePeople;
            this.ctrlManageData.Size = new System.Drawing.Size(1188, 604);
            this.ctrlManageData.TabIndex = 0;
            this.ctrlManageData.CloseClicked += new System.Action(this.ctrlManageData_OnCloseClick);
            this.ctrlManageData.AddClicked += new System.Action(this.ctrlManageData_OnAddClick);
            this.ctrlManageData.SearchTextChanged += new System.Action<string, string>(this.ctrlManageData_SearchTextChanged);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 604);
            this.Controls.Add(this.ctrlManageData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManagePeople";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlManageData ctrlManageData;
    }
}