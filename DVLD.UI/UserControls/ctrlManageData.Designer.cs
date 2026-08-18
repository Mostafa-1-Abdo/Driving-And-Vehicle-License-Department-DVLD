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
            this.dgv_Records = new System.Windows.Forms.DataGridView();
            this.ContectMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Title = new System.Windows.Forms.Label();
            this.cb_Filter = new System.Windows.Forms.ComboBox();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_NumberOfRecords = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pb_Header = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Header)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Records
            // 
            this.dgv_Records.AllowUserToAddRows = false;
            this.dgv_Records.AllowUserToDeleteRows = false;
            this.dgv_Records.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Records.ContextMenuStrip = this.ContectMenuStrip;
            this.dgv_Records.Location = new System.Drawing.Point(13, 280);
            this.dgv_Records.MultiSelect = false;
            this.dgv_Records.Name = "dgv_Records";
            this.dgv_Records.Size = new System.Drawing.Size(1165, 278);
            this.dgv_Records.TabIndex = 0;
            // 
            // ContectMenuStrip
            // 
            this.ContectMenuStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.ContectMenuStrip.Name = "ContectMenuStrip";
            this.ContectMenuStrip.Size = new System.Drawing.Size(61, 4);
            this.ContectMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContectMenuStrip_ItemClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter By:";
            // 
            // lb_Title
            // 
            this.lb_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_Title.Location = new System.Drawing.Point(374, 194);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(333, 46);
            this.lb_Title.TabIndex = 2;
            this.lb_Title.Text = "label2";
            this.lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Filter
            // 
            this.cb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Filter.FormattingEnabled = true;
            this.cb_Filter.Items.AddRange(new object[] {
            "None"});
            this.cb_Filter.Location = new System.Drawing.Point(86, 254);
            this.cb_Filter.Name = "cb_Filter";
            this.cb_Filter.Size = new System.Drawing.Size(172, 21);
            this.cb_Filter.TabIndex = 3;
            this.cb_Filter.SelectedIndexChanged += new System.EventHandler(this.cb_Filter_SelectedIndexChanged);
            // 
            // tb_Search
            // 
            this.tb_Search.Location = new System.Drawing.Point(264, 255);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(210, 20);
            this.tb_Search.TabIndex = 4;
            this.tb_Search.Visible = false;
            this.tb_Search.TextChanged += new System.EventHandler(this.tb_Search_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Records:";
            // 
            // lb_NumberOfRecords
            // 
            this.lb_NumberOfRecords.AutoSize = true;
            this.lb_NumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lb_NumberOfRecords.Location = new System.Drawing.Point(96, 575);
            this.lb_NumberOfRecords.Name = "lb_NumberOfRecords";
            this.lb_NumberOfRecords.Size = new System.Drawing.Size(13, 13);
            this.lb_NumberOfRecords.TabIndex = 8;
            this.lb_NumberOfRecords.Text = "0";
            // 
            // btn_Add
            // 
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Location = new System.Drawing.Point(1105, 227);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(73, 47);
            this.btn_Add.TabIndex = 9;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(1043, 563);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 36);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pb_Header
            // 
            this.pb_Header.Location = new System.Drawing.Point(430, 3);
            this.pb_Header.Name = "pb_Header";
            this.pb_Header.Size = new System.Drawing.Size(220, 189);
            this.pb_Header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Header.TabIndex = 5;
            this.pb_Header.TabStop = false;
            // 
            // ctrlManageData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lb_NumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pb_Header);
            this.Controls.Add(this.tb_Search);
            this.Controls.Add(this.cb_Filter);
            this.Controls.Add(this.lb_Title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Records);
            this.Name = "ctrlManageData";
            this.Size = new System.Drawing.Size(1185, 606);
            this.Load += new System.EventHandler(this.ctrlManageData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Records;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.ComboBox cb_Filter;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.PictureBox pb_Header;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_NumberOfRecords;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ContextMenuStrip ContectMenuStrip;
    }
}
