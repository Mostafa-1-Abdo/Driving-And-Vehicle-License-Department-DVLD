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
            this.ctrlManageData1.BackColor = System.Drawing.Color.White;
            this.ctrlManageData1.btn_AddImage = global::DVLD.UI.Properties.Resources.AddNewPerson;
            this.ctrlManageData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageData1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlManageData1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ctrlManageData1.lb_TitleText = "Manage People";
            this.ctrlManageData1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageData1.Name = "ctrlManageData1";
            this.ctrlManageData1.pb_HeaderImage = global::DVLD.UI.Properties.Resources.ManagePeople;
            this.ctrlManageData1.Size = new System.Drawing.Size(1192, 655);
            this.ctrlManageData1.TabIndex = 0;
            this.ctrlManageData1.AddClicked += new System.Action(this.ctrlManageData_OnAddClick);
            this.ctrlManageData1.OnFilterChanged += new System.Action<string>(this.ctrlManageData_OnFilterChanged);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 655);
            this.Controls.Add(this.ctrlManageData1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManagePeople";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlManageData ctrlManageData1;
    }
}