namespace DVLD.UI.UserControls
{
    partial class ctrlPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.cb_Filter = new System.Windows.Forms.ComboBox();
            this.btn_SearchPerson = new System.Windows.Forms.Button();
            this.btn_AddNewPerson = new System.Windows.Forms.Button();
            this.gb_Filters = new System.Windows.Forms.GroupBox();
            this.ctrlPersonCard1 = new DVLD.UI.UserControls.ctrlPersonCard();
            this.gb_Filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Find By:";
            // 
            // tb_Search
            // 
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Search.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.Location = new System.Drawing.Point(313, 27);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(214, 22);
            this.tb_Search.TabIndex = 17;
            this.tb_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Search_KeyDown);
            this.tb_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Search_KeyPress);
            // 
            // cb_Filter
            // 
            this.cb_Filter.BackColor = System.Drawing.Color.White;
            this.cb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Filter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Filter.FormattingEnabled = true;
            this.cb_Filter.Items.AddRange(new object[] {
            "ID",
            "National Number"});
            this.cb_Filter.Location = new System.Drawing.Point(96, 28);
            this.cb_Filter.Name = "cb_Filter";
            this.cb_Filter.Size = new System.Drawing.Size(210, 21);
            this.cb_Filter.TabIndex = 16;
            // 
            // btn_SearchPerson
            // 
            this.btn_SearchPerson.BackColor = System.Drawing.Color.White;
            this.btn_SearchPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchPerson.Image = global::DVLD.UI.Properties.Resources.FindPerson;
            this.btn_SearchPerson.Location = new System.Drawing.Point(543, 20);
            this.btn_SearchPerson.Name = "btn_SearchPerson";
            this.btn_SearchPerson.Size = new System.Drawing.Size(44, 37);
            this.btn_SearchPerson.TabIndex = 18;
            this.btn_SearchPerson.UseVisualStyleBackColor = false;
            this.btn_SearchPerson.Click += new System.EventHandler(this.btn_SearchPerson_Click);
            // 
            // btn_AddNewPerson
            // 
            this.btn_AddNewPerson.BackColor = System.Drawing.Color.White;
            this.btn_AddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddNewPerson.Image = global::DVLD.UI.Properties.Resources.AddNewPerson;
            this.btn_AddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddNewPerson.Location = new System.Drawing.Point(594, 20);
            this.btn_AddNewPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_AddNewPerson.Name = "btn_AddNewPerson";
            this.btn_AddNewPerson.Size = new System.Drawing.Size(44, 37);
            this.btn_AddNewPerson.TabIndex = 20;
            this.btn_AddNewPerson.UseVisualStyleBackColor = false;
            this.btn_AddNewPerson.Click += new System.EventHandler(this.btn_AddNewPerson_Click);
            // 
            // gb_Filters
            // 
            this.gb_Filters.BackColor = System.Drawing.Color.Transparent;
            this.gb_Filters.Controls.Add(this.btn_AddNewPerson);
            this.gb_Filters.Controls.Add(this.btn_SearchPerson);
            this.gb_Filters.Controls.Add(this.cb_Filter);
            this.gb_Filters.Controls.Add(this.tb_Search);
            this.gb_Filters.Controls.Add(this.label1);
            this.gb_Filters.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gb_Filters.ForeColor = System.Drawing.Color.Black;
            this.gb_Filters.Location = new System.Drawing.Point(0, 0);
            this.gb_Filters.Name = "gb_Filters";
            this.gb_Filters.Size = new System.Drawing.Size(704, 63);
            this.gb_Filters.TabIndex = 17;
            this.gb_Filters.TabStop = false;
            this.gb_Filters.Text = "Filter";
            this.gb_Filters.Enter += new System.EventHandler(this.gb_Filters_Enter);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCard1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(0, 65);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(704, 330);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gb_Filters);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(708, 397);
            this.gb_Filters.ResumeLayout(false);
            this.gb_Filters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.ComboBox cb_Filter;
        private System.Windows.Forms.Button btn_SearchPerson;
        private System.Windows.Forms.Button btn_AddNewPerson;
        private System.Windows.Forms.GroupBox gb_Filters;
    }
}
