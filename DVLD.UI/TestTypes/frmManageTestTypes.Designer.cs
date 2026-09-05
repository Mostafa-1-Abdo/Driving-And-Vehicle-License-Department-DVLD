namespace DVLD.UI.TestTypes
{
    partial class frmManageTestTypes
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
            this.ctrlManageData1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlManageData1.btn_AddImage = null;
            this.ctrlManageData1.dgv_RecordsAutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ctrlManageData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageData1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlManageData1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ctrlManageData1.lb_TitleText = "Manage Test Types";
            this.ctrlManageData1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageData1.Name = "ctrlManageData1";
            this.ctrlManageData1.pb_HeaderImage = global::DVLD.UI.Properties.Resources.ManageTestTypes;
            this.ctrlManageData1.Size = new System.Drawing.Size(734, 547);
            this.ctrlManageData1.TabIndex = 0;
            // 
            // frmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 547);
            this.Controls.Add(this.ctrlManageData1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageTestTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Test Types";
            this.Load += new System.EventHandler(this.frmManageTestTypes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlManageData ctrlManageData1;
    }
}