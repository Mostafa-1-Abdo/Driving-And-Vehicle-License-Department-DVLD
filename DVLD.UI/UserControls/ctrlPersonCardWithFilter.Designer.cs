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
            this.ctrlPersonCard1 = new DVLD.UI.UserControls.ctrlPersonCard();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btn_AddNewPerson = new System.Windows.Forms.Button();
            this.btn_SearchPerson = new System.Windows.Forms.Button();
            this.cb_Filter = new System.Windows.Forms.ComboBox();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(13, 93);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(819, 271);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btn_AddNewPerson);
            this.gbFilters.Controls.Add(this.btn_SearchPerson);
            this.gbFilters.Controls.Add(this.cb_Filter);
            this.gbFilters.Controls.Add(this.tb_Search);
            this.gbFilters.Controls.Add(this.label1);
            this.gbFilters.Location = new System.Drawing.Point(13, 10);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(819, 77);
            this.gbFilters.TabIndex = 17;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // btn_AddNewPerson
            // 
            this.btn_AddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AddNewPerson.Image = global::DVLD.UI.Properties.Resources.AddNewPerson;
            this.btn_AddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddNewPerson.Location = new System.Drawing.Point(594, 20);
            this.btn_AddNewPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_AddNewPerson.Name = "btn_AddNewPerson";
            this.btn_AddNewPerson.Size = new System.Drawing.Size(44, 37);
            this.btn_AddNewPerson.TabIndex = 20;
            this.btn_AddNewPerson.UseVisualStyleBackColor = true;
            // 
            // btn_SearchPerson
            // 
            this.btn_SearchPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchPerson.Image = global::DVLD.UI.Properties.Resources.SearchPerson;
            this.btn_SearchPerson.Location = new System.Drawing.Point(543, 20);
            this.btn_SearchPerson.Name = "btn_SearchPerson";
            this.btn_SearchPerson.Size = new System.Drawing.Size(44, 37);
            this.btn_SearchPerson.TabIndex = 18;
            this.btn_SearchPerson.UseVisualStyleBackColor = true;
            this.btn_SearchPerson.Click += new System.EventHandler(this.btn_SearchPerson_Click);
            // 
            // cb_Filter
            // 
            this.cb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Filter.FormattingEnabled = true;
            this.cb_Filter.Items.AddRange(new object[] {
            "ID",
            "National Number"});
            this.cb_Filter.Location = new System.Drawing.Point(96, 25);
            this.cb_Filter.Name = "cb_Filter";
            this.cb_Filter.Size = new System.Drawing.Size(210, 21);
            this.cb_Filter.TabIndex = 16;
            // 
            // tb_Search
            // 
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Search.Location = new System.Drawing.Point(313, 25);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(214, 20);
            this.tb_Search.TabIndex = 17;
            this.tb_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Search_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Find By:";
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(849, 370);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btn_AddNewPerson;
        private System.Windows.Forms.Button btn_SearchPerson;
        private System.Windows.Forms.ComboBox cb_Filter;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Label label1;
    }
}
