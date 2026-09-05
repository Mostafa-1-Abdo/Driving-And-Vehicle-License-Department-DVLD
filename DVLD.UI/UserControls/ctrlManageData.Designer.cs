namespace DVLD.UI
{
    partial class ctrlManageData
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Records = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lb_FilterBy = new System.Windows.Forms.Label();
            this.lb_Title = new System.Windows.Forms.Label();
            this.cb_Filter = new System.Windows.Forms.ComboBox();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_NumberOfRecords = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tt_AddNew = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Close = new System.Windows.Forms.Button();
            this.pb_Header = new System.Windows.Forms.PictureBox();
            this.cb_Search = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Header)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Records
            // 
            this.dgv_Records.AllowUserToAddRows = false;
            this.dgv_Records.AllowUserToDeleteRows = false;
            this.dgv_Records.AllowUserToResizeRows = false;
            this.dgv_Records.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Records.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Records.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Records.ContextMenuStrip = this.ContextMenuStrip;
            this.dgv_Records.Location = new System.Drawing.Point(14, 330);
            this.dgv_Records.MultiSelect = false;
            this.dgv_Records.Name = "dgv_Records";
            this.dgv_Records.ReadOnly = true;
            this.dgv_Records.RowHeadersVisible = false;
            this.dgv_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Records.Size = new System.Drawing.Size(1165, 278);
            this.dgv_Records.TabIndex = 0;
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ContextMenuStrip.Name = "ContectMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(181, 26);
            // 
            // lb_FilterBy
            // 
            this.lb_FilterBy.AutoSize = true;
            this.lb_FilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FilterBy.Location = new System.Drawing.Point(13, 303);
            this.lb_FilterBy.Name = "lb_FilterBy";
            this.lb_FilterBy.Size = new System.Drawing.Size(76, 21);
            this.lb_FilterBy.TabIndex = 1;
            this.lb_FilterBy.Text = "Filter By:";
            // 
            // lb_Title
            // 
            this.lb_Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_Title.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Title.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_Title.Location = new System.Drawing.Point(430, 200);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(333, 46);
            this.lb_Title.TabIndex = 2;
            this.lb_Title.Text = "Title";
            this.lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Filter
            // 
            this.cb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Filter.FormattingEnabled = true;
            this.cb_Filter.Items.AddRange(new object[] {
            "None"});
            this.cb_Filter.Location = new System.Drawing.Point(106, 303);
            this.cb_Filter.Name = "cb_Filter";
            this.cb_Filter.Size = new System.Drawing.Size(172, 21);
            this.cb_Filter.TabIndex = 3;
            this.cb_Filter.SelectedIndexChanged += new System.EventHandler(this.cb_Filter_SelectedIndexChanged);
            // 
            // tb_Search
            // 
            this.tb_Search.Location = new System.Drawing.Point(284, 302);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(172, 22);
            this.tb_Search.TabIndex = 4;
            this.tb_Search.Visible = false;
            this.tb_Search.TextChanged += new System.EventHandler(this.tb_Search_TextChanged);
            this.tb_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Search_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 628);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Records:";
            // 
            // lb_NumberOfRecords
            // 
            this.lb_NumberOfRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_NumberOfRecords.AutoSize = true;
            this.lb_NumberOfRecords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NumberOfRecords.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_NumberOfRecords.Location = new System.Drawing.Point(96, 632);
            this.lb_NumberOfRecords.Name = "lb_NumberOfRecords";
            this.lb_NumberOfRecords.Size = new System.Drawing.Size(13, 13);
            this.lb_NumberOfRecords.TabIndex = 8;
            this.lb_NumberOfRecords.Text = "0";
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.BackColor = System.Drawing.Color.White;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Location = new System.Drawing.Point(1114, 281);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(65, 43);
            this.btn_Add.TabIndex = 9;
            this.tt_AddNew.SetToolTip(this.btn_Add, "Add New");
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_Close.Image = global::DVLD.UI.Properties.Resources.Close;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(1058, 617);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(121, 36);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pb_Header
            // 
            this.pb_Header.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pb_Header.Location = new System.Drawing.Point(486, 8);
            this.pb_Header.Name = "pb_Header";
            this.pb_Header.Size = new System.Drawing.Size(220, 189);
            this.pb_Header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Header.TabIndex = 5;
            this.pb_Header.TabStop = false;
            // 
            // cb_Search
            // 
            this.cb_Search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Search.FormattingEnabled = true;
            this.cb_Search.Location = new System.Drawing.Point(284, 303);
            this.cb_Search.Name = "cb_Search";
            this.cb_Search.Size = new System.Drawing.Size(172, 21);
            this.cb_Search.TabIndex = 10;
            this.cb_Search.Visible = false;
            this.cb_Search.SelectedIndexChanged += new System.EventHandler(this.cb_Search_SelectedIndexChanged);
            // 
            // ctrlManageData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cb_Search);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lb_NumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pb_Header);
            this.Controls.Add(this.tb_Search);
            this.Controls.Add(this.cb_Filter);
            this.Controls.Add(this.lb_Title);
            this.Controls.Add(this.lb_FilterBy);
            this.Controls.Add(this.dgv_Records);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Name = "ctrlManageData";
            this.Size = new System.Drawing.Size(1192, 663);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Records;
        private System.Windows.Forms.Label lb_FilterBy;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.ComboBox cb_Filter;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.PictureBox pb_Header;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_NumberOfRecords;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolTip tt_AddNew;
        private System.Windows.Forms.ComboBox cb_Search;
    }
}
