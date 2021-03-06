namespace QuanLiRapPhim.frmAdminUserControls
{
    partial class NhanVien
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
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.lblStaffID = new System.Windows.Forms.Label();
            this.txtStaffId = new System.Windows.Forms.TextBox();
            this.txtStaffAddress = new System.Windows.Forms.TextBox();
            this.lblStaffINumber = new System.Windows.Forms.Label();
            this.lblStaffBirth = new System.Windows.Forms.Label();
            this.lblStaffPhone = new System.Windows.Forms.Label();
            this.btnSearchStaff = new System.Windows.Forms.Button();
            this.txtSearchStaff = new System.Windows.Forms.TextBox();
            this.btnDeleteStaff = new System.Windows.Forms.Button();
            this.btnUpdateStaff = new System.Windows.Forms.Button();
            this.lblStaffAddress = new System.Windows.Forms.Label();
            this.grpStaff = new System.Windows.Forms.GroupBox();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.btnShowStaff = new System.Windows.Forms.Button();
            this.dtgvStaff = new System.Windows.Forms.DataGridView();
            this.txtStaffName = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.txtStaffBirth = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.txtStaffINumber = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.txtStaffPhone = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.grpStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddStaff.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnAddStaff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStaff.ForeColor = System.Drawing.Color.White;
            this.btnAddStaff.Location = new System.Drawing.Point(391, 13);
            this.btnAddStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(68, 26);
            this.btnAddStaff.TabIndex = 20;
            this.btnAddStaff.Text = "Thêm";
            this.btnAddStaff.UseVisualStyleBackColor = false;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // lblStaffID
            // 
            this.lblStaffID.AutoSize = true;
            this.lblStaffID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffID.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStaffID.Location = new System.Drawing.Point(18, 32);
            this.lblStaffID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStaffID.Name = "lblStaffID";
            this.lblStaffID.Size = new System.Drawing.Size(64, 19);
            this.lblStaffID.TabIndex = 4;
            this.lblStaffID.Text = "Mã NV:";
            // 
            // txtStaffId
            // 
            this.txtStaffId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffId.Location = new System.Drawing.Point(112, 26);
            this.txtStaffId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.Size = new System.Drawing.Size(144, 26);
            this.txtStaffId.TabIndex = 2;
            // 
            // txtStaffAddress
            // 
            this.txtStaffAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffAddress.Location = new System.Drawing.Point(112, 117);
            this.txtStaffAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStaffAddress.Name = "txtStaffAddress";
            this.txtStaffAddress.Size = new System.Drawing.Size(144, 26);
            this.txtStaffAddress.TabIndex = 2;
            // 
            // lblStaffINumber
            // 
            this.lblStaffINumber.AutoSize = true;
            this.lblStaffINumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffINumber.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStaffINumber.Location = new System.Drawing.Point(19, 174);
            this.lblStaffINumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStaffINumber.Name = "lblStaffINumber";
            this.lblStaffINumber.Size = new System.Drawing.Size(65, 19);
            this.lblStaffINumber.TabIndex = 4;
            this.lblStaffINumber.Text = "CMND:";
            // 
            // lblStaffBirth
            // 
            this.lblStaffBirth.AutoSize = true;
            this.lblStaffBirth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffBirth.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStaffBirth.Location = new System.Drawing.Point(18, 88);
            this.lblStaffBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStaffBirth.Name = "lblStaffBirth";
            this.lblStaffBirth.Size = new System.Drawing.Size(81, 19);
            this.lblStaffBirth.TabIndex = 4;
            this.lblStaffBirth.Text = "Ngày sinh:";
            // 
            // lblStaffPhone
            // 
            this.lblStaffPhone.AutoSize = true;
            this.lblStaffPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffPhone.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStaffPhone.Location = new System.Drawing.Point(19, 146);
            this.lblStaffPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStaffPhone.Name = "lblStaffPhone";
            this.lblStaffPhone.Size = new System.Drawing.Size(56, 19);
            this.lblStaffPhone.TabIndex = 4;
            this.lblStaffPhone.Text = "Số ĐT:";
            // 
            // btnSearchStaff
            // 
            this.btnSearchStaff.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearchStaff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchStaff.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnSearchStaff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSearchStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSearchStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStaff.ForeColor = System.Drawing.Color.White;
            this.btnSearchStaff.Location = new System.Drawing.Point(798, 20);
            this.btnSearchStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchStaff.Name = "btnSearchStaff";
            this.btnSearchStaff.Size = new System.Drawing.Size(20, 21);
            this.btnSearchStaff.TabIndex = 22;
            this.btnSearchStaff.UseVisualStyleBackColor = false;
            this.btnSearchStaff.Click += new System.EventHandler(this.btnSearchStaff_Click);
            // 
            // txtSearchStaff
            // 
            this.txtSearchStaff.Location = new System.Drawing.Point(694, 21);
            this.txtSearchStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchStaff.Name = "txtSearchStaff";
            this.txtSearchStaff.Size = new System.Drawing.Size(100, 20);
            this.txtSearchStaff.TabIndex = 21;
            this.txtSearchStaff.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchStaff_KeyDown);
            // 
            // btnDeleteStaff
            // 
            this.btnDeleteStaff.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteStaff.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnDeleteStaff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDeleteStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStaff.ForeColor = System.Drawing.Color.White;
            this.btnDeleteStaff.Location = new System.Drawing.Point(573, 13);
            this.btnDeleteStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteStaff.Name = "btnDeleteStaff";
            this.btnDeleteStaff.Size = new System.Drawing.Size(68, 26);
            this.btnDeleteStaff.TabIndex = 18;
            this.btnDeleteStaff.Text = "Xóa";
            this.btnDeleteStaff.UseVisualStyleBackColor = false;
            this.btnDeleteStaff.Click += new System.EventHandler(this.btnDeleteStaff_Click);
            // 
            // btnUpdateStaff
            // 
            this.btnUpdateStaff.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateStaff.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnUpdateStaff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUpdateStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStaff.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStaff.Location = new System.Drawing.Point(479, 13);
            this.btnUpdateStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateStaff.Name = "btnUpdateStaff";
            this.btnUpdateStaff.Size = new System.Drawing.Size(68, 26);
            this.btnUpdateStaff.TabIndex = 19;
            this.btnUpdateStaff.Text = "Sửa";
            this.btnUpdateStaff.UseVisualStyleBackColor = false;
            this.btnUpdateStaff.Click += new System.EventHandler(this.btnUpdateStaff_Click);
            // 
            // lblStaffAddress
            // 
            this.lblStaffAddress.AutoSize = true;
            this.lblStaffAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffAddress.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStaffAddress.Location = new System.Drawing.Point(19, 119);
            this.lblStaffAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStaffAddress.Name = "lblStaffAddress";
            this.lblStaffAddress.Size = new System.Drawing.Size(61, 19);
            this.lblStaffAddress.TabIndex = 4;
            this.lblStaffAddress.Text = "Địa chỉ:";
            // 
            // grpStaff
            // 
            this.grpStaff.BackColor = System.Drawing.Color.Transparent;
            this.grpStaff.Controls.Add(this.txtStaffPhone);
            this.grpStaff.Controls.Add(this.txtStaffINumber);
            this.grpStaff.Controls.Add(this.txtStaffBirth);
            this.grpStaff.Controls.Add(this.txtStaffName);
            this.grpStaff.Controls.Add(this.lblStaffID);
            this.grpStaff.Controls.Add(this.txtStaffId);
            this.grpStaff.Controls.Add(this.txtStaffAddress);
            this.grpStaff.Controls.Add(this.lblStaffINumber);
            this.grpStaff.Controls.Add(this.lblStaffBirth);
            this.grpStaff.Controls.Add(this.lblStaffPhone);
            this.grpStaff.Controls.Add(this.lblStaffAddress);
            this.grpStaff.Controls.Add(this.lblStaffName);
            this.grpStaff.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStaff.ForeColor = System.Drawing.Color.Red;
            this.grpStaff.Location = new System.Drawing.Point(118, 13);
            this.grpStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpStaff.Name = "grpStaff";
            this.grpStaff.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpStaff.Size = new System.Drawing.Size(268, 478);
            this.grpStaff.TabIndex = 23;
            this.grpStaff.TabStop = false;
            this.grpStaff.Text = "Thông tin nhân viên";
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStaffName.Location = new System.Drawing.Point(18, 61);
            this.lblStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(59, 19);
            this.lblStaffName.TabIndex = 4;
            this.lblStaffName.Text = "Họ tên:";
            // 
            // btnShowStaff
            // 
            this.btnShowStaff.Location = new System.Drawing.Point(171, 134);
            this.btnShowStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowStaff.Name = "btnShowStaff";
            this.btnShowStaff.Size = new System.Drawing.Size(66, 28);
            this.btnShowStaff.TabIndex = 17;
            this.btnShowStaff.Text = "Xem";
            this.btnShowStaff.UseVisualStyleBackColor = true;
            this.btnShowStaff.Click += new System.EventHandler(this.btnShowStaff_Click);
            // 
            // dtgvStaff
            // 
            this.dtgvStaff.AllowUserToAddRows = false;
            this.dtgvStaff.AllowUserToDeleteRows = false;
            this.dtgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvStaff.Location = new System.Drawing.Point(391, 46);
            this.dtgvStaff.Name = "dtgvStaff";
            this.dtgvStaff.ReadOnly = true;
            this.dtgvStaff.RowHeadersWidth = 51;
            this.dtgvStaff.Size = new System.Drawing.Size(486, 427);
            this.dtgvStaff.TabIndex = 16;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(112, 57);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(144, 26);
            this.txtStaffName.TabIndex = 5;
            //this.txtStaffName.ValidateType = null;
            // 
            // txtStaffBirth
            // 
            this.txtStaffBirth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffBirth.Location = new System.Drawing.Point(112, 86);
            this.txtStaffBirth.Name = "txtStaffBirth";
            this.txtStaffBirth.Size = new System.Drawing.Size(144, 26);
            this.txtStaffBirth.TabIndex = 6;
            //this.txtStaffBirth.ValidateType = null;
            // 
            // txtStaffINumber
            // 
            this.txtStaffINumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffINumber.Location = new System.Drawing.Point(112, 174);
            this.txtStaffINumber.Name = "txtStaffINumber";
            this.txtStaffINumber.Size = new System.Drawing.Size(144, 26);
            this.txtStaffINumber.TabIndex = 7;
            ///this.txtStaffINumber.ValidateType = null;
            // 
            // txtStaffPhone
            // 
            this.txtStaffPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffPhone.Location = new System.Drawing.Point(112, 146);
            this.txtStaffPhone.Name = "txtStaffPhone";
            this.txtStaffPhone.Size = new System.Drawing.Size(144, 26);
            this.txtStaffPhone.TabIndex = 8;
            //this.txtStaffPhone.ValidateType = null;
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.btnSearchStaff);
            this.Controls.Add(this.txtSearchStaff);
            this.Controls.Add(this.btnDeleteStaff);
            this.Controls.Add(this.btnUpdateStaff);
            this.Controls.Add(this.grpStaff);
            this.Controls.Add(this.btnShowStaff);
            this.Controls.Add(this.dtgvStaff);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NhanVien";
            this.Size = new System.Drawing.Size(1050, 528);
            this.grpStaff.ResumeLayout(false);
            this.grpStaff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Label lblStaffID;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.TextBox txtStaffAddress;
        private System.Windows.Forms.Label lblStaffINumber;
        private System.Windows.Forms.Label lblStaffBirth;
        private System.Windows.Forms.Label lblStaffPhone;
        private System.Windows.Forms.Button btnSearchStaff;
        private System.Windows.Forms.TextBox txtSearchStaff;
        private System.Windows.Forms.Button btnDeleteStaff;
        private System.Windows.Forms.Button btnUpdateStaff;
        private System.Windows.Forms.Label lblStaffAddress;
        private System.Windows.Forms.GroupBox grpStaff;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Button btnShowStaff;
        private System.Windows.Forms.DataGridView dtgvStaff;
        private Patterns.Strategy.MyTextBox txtStaffPhone;
        private Patterns.Strategy.MyTextBox txtStaffINumber;
        private Patterns.Strategy.MyTextBox txtStaffBirth;
        private Patterns.Strategy.MyTextBox txtStaffName;
    }
}
