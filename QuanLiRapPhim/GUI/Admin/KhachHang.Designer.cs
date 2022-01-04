namespace QuanLiRapPhim.frmAdminUserControls
{
    partial class KhachHang
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
            this.txtSearchCus = new System.Windows.Forms.TextBox();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.txtCusName = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.txtCusBirth = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.txtCusINumber = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.txtCusPhone = new QuanLiRapPhim.Patterns.Strategy.MyTextBox();
            this.nudPoint = new System.Windows.Forms.NumericUpDown();
            this.lblCusID = new System.Windows.Forms.Label();
            this.txtCusID = new System.Windows.Forms.TextBox();
            this.txtCusAddress = new System.Windows.Forms.TextBox();
            this.lblCusINumber = new System.Windows.Forms.Label();
            this.lblCusBirth = new System.Windows.Forms.Label();
            this.lblCusPhone = new System.Windows.Forms.Label();
            this.lblCusPoint = new System.Windows.Forms.Label();
            this.lblCusAddress = new System.Windows.Forms.Label();
            this.lblCusName = new System.Windows.Forms.Label();
            this.btnShowCustomer = new System.Windows.Forms.Button();
            this.dtgvCustomer = new System.Windows.Forms.DataGridView();
            this.btnSearchCus = new System.Windows.Forms.Button();
            this.grpCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchCus
            // 
            this.txtSearchCus.Location = new System.Drawing.Point(748, 21);
            this.txtSearchCus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchCus.Name = "txtSearchCus";
            this.txtSearchCus.Size = new System.Drawing.Size(100, 20);
            this.txtSearchCus.TabIndex = 20;
            this.txtSearchCus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCus_KeyDown);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteCustomer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnDeleteCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCustomer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(638, 13);
            this.btnDeleteCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(68, 26);
            this.btnDeleteCustomer.TabIndex = 17;
            this.btnDeleteCustomer.Text = "Xóa";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateCustomer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnUpdateCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUpdateCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCustomer.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCustomer.Location = new System.Drawing.Point(556, 13);
            this.btnUpdateCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(68, 26);
            this.btnUpdateCustomer.TabIndex = 18;
            this.btnUpdateCustomer.Text = "Sửa";
            this.btnUpdateCustomer.UseVisualStyleBackColor = false;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCustomer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnAddCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Location = new System.Drawing.Point(476, 13);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(68, 26);
            this.btnAddCustomer.TabIndex = 19;
            this.btnAddCustomer.Text = "Thêm";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // grpCustomer
            // 
            this.grpCustomer.BackColor = System.Drawing.Color.Transparent;
            this.grpCustomer.Controls.Add(this.txtCusName);
            this.grpCustomer.Controls.Add(this.txtCusBirth);
            this.grpCustomer.Controls.Add(this.txtCusINumber);
            this.grpCustomer.Controls.Add(this.txtCusPhone);
            this.grpCustomer.Controls.Add(this.nudPoint);
            this.grpCustomer.Controls.Add(this.lblCusID);
            this.grpCustomer.Controls.Add(this.txtCusID);
            this.grpCustomer.Controls.Add(this.txtCusAddress);
            this.grpCustomer.Controls.Add(this.lblCusINumber);
            this.grpCustomer.Controls.Add(this.lblCusBirth);
            this.grpCustomer.Controls.Add(this.lblCusPhone);
            this.grpCustomer.Controls.Add(this.lblCusPoint);
            this.grpCustomer.Controls.Add(this.lblCusAddress);
            this.grpCustomer.Controls.Add(this.lblCusName);
            this.grpCustomer.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomer.ForeColor = System.Drawing.Color.Red;
            this.grpCustomer.Location = new System.Drawing.Point(139, 13);
            this.grpCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(2);
            this.grpCustomer.Size = new System.Drawing.Size(251, 455);
            this.grpCustomer.TabIndex = 16;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Thông tin khách hàng";
            // 
            // txtCusName
            // 
            this.txtCusName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusName.Location = new System.Drawing.Point(100, 58);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(145, 26);
            this.txtCusName.TabIndex = 9;
            this.txtCusName.ValidateType = null;
            // 
            // txtCusBirth
            // 
            this.txtCusBirth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusBirth.Location = new System.Drawing.Point(100, 88);
            this.txtCusBirth.Name = "txtCusBirth";
            this.txtCusBirth.Size = new System.Drawing.Size(145, 26);
            this.txtCusBirth.TabIndex = 8;
            this.txtCusBirth.ValidateType = null;
            // 
            // txtCusINumber
            // 
            this.txtCusINumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusINumber.Location = new System.Drawing.Point(100, 181);
            this.txtCusINumber.Name = "txtCusINumber";
            this.txtCusINumber.Size = new System.Drawing.Size(145, 26);
            this.txtCusINumber.TabIndex = 7;
            this.txtCusINumber.ValidateType = null;
            // 
            // txtCusPhone
            // 
            this.txtCusPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusPhone.Location = new System.Drawing.Point(100, 149);
            this.txtCusPhone.Name = "txtCusPhone";
            this.txtCusPhone.Size = new System.Drawing.Size(145, 26);
            this.txtCusPhone.TabIndex = 6;
            this.txtCusPhone.ValidateType = null;
            // 
            // nudPoint
            // 
            this.nudPoint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPoint.Location = new System.Drawing.Point(120, 219);
            this.nudPoint.Margin = new System.Windows.Forms.Padding(2);
            this.nudPoint.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPoint.Name = "nudPoint";
            this.nudPoint.Size = new System.Drawing.Size(56, 26);
            this.nudPoint.TabIndex = 5;
            this.nudPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCusID
            // 
            this.lblCusID.AutoSize = true;
            this.lblCusID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusID.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCusID.Location = new System.Drawing.Point(18, 32);
            this.lblCusID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusID.Name = "lblCusID";
            this.lblCusID.Size = new System.Drawing.Size(66, 19);
            this.lblCusID.TabIndex = 4;
            this.lblCusID.Text = "Mã KH:";
            // 
            // txtCusID
            // 
            this.txtCusID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusID.Location = new System.Drawing.Point(100, 30);
            this.txtCusID.Margin = new System.Windows.Forms.Padding(2);
            this.txtCusID.Name = "txtCusID";
            this.txtCusID.Size = new System.Drawing.Size(145, 26);
            this.txtCusID.TabIndex = 2;
            // 
            // txtCusAddress
            // 
            this.txtCusAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusAddress.Location = new System.Drawing.Point(100, 116);
            this.txtCusAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtCusAddress.Name = "txtCusAddress";
            this.txtCusAddress.Size = new System.Drawing.Size(145, 26);
            this.txtCusAddress.TabIndex = 2;
            // 
            // lblCusINumber
            // 
            this.lblCusINumber.AutoSize = true;
            this.lblCusINumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusINumber.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCusINumber.Location = new System.Drawing.Point(18, 184);
            this.lblCusINumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusINumber.Name = "lblCusINumber";
            this.lblCusINumber.Size = new System.Drawing.Size(65, 19);
            this.lblCusINumber.TabIndex = 4;
            this.lblCusINumber.Text = "CMND:";
            // 
            // lblCusBirth
            // 
            this.lblCusBirth.AutoSize = true;
            this.lblCusBirth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusBirth.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCusBirth.Location = new System.Drawing.Point(18, 88);
            this.lblCusBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusBirth.Name = "lblCusBirth";
            this.lblCusBirth.Size = new System.Drawing.Size(81, 19);
            this.lblCusBirth.TabIndex = 4;
            this.lblCusBirth.Text = "Ngày sinh:";
            // 
            // lblCusPhone
            // 
            this.lblCusPhone.AutoSize = true;
            this.lblCusPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusPhone.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCusPhone.Location = new System.Drawing.Point(18, 152);
            this.lblCusPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusPhone.Name = "lblCusPhone";
            this.lblCusPhone.Size = new System.Drawing.Size(56, 19);
            this.lblCusPhone.TabIndex = 4;
            this.lblCusPhone.Text = "Số ĐT:";
            // 
            // lblCusPoint
            // 
            this.lblCusPoint.AutoSize = true;
            this.lblCusPoint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusPoint.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCusPoint.Location = new System.Drawing.Point(18, 225);
            this.lblCusPoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusPoint.Name = "lblCusPoint";
            this.lblCusPoint.Size = new System.Drawing.Size(102, 19);
            this.lblCusPoint.TabIndex = 4;
            this.lblCusPoint.Text = "Điểm thưởng:";
            // 
            // lblCusAddress
            // 
            this.lblCusAddress.AutoSize = true;
            this.lblCusAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusAddress.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCusAddress.Location = new System.Drawing.Point(18, 119);
            this.lblCusAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusAddress.Name = "lblCusAddress";
            this.lblCusAddress.Size = new System.Drawing.Size(61, 19);
            this.lblCusAddress.TabIndex = 4;
            this.lblCusAddress.Text = "Địa chỉ:";
            // 
            // lblCusName
            // 
            this.lblCusName.AutoSize = true;
            this.lblCusName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCusName.Location = new System.Drawing.Point(18, 61);
            this.lblCusName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusName.Name = "lblCusName";
            this.lblCusName.Size = new System.Drawing.Size(59, 19);
            this.lblCusName.TabIndex = 4;
            this.lblCusName.Text = "Họ tên:";
            // 
            // btnShowCustomer
            // 
            this.btnShowCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowCustomer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnShowCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnShowCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowCustomer.ForeColor = System.Drawing.Color.White;
            this.btnShowCustomer.Location = new System.Drawing.Point(394, 13);
            this.btnShowCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowCustomer.Name = "btnShowCustomer";
            this.btnShowCustomer.Size = new System.Drawing.Size(68, 26);
            this.btnShowCustomer.TabIndex = 15;
            this.btnShowCustomer.Text = "Xem";
            this.btnShowCustomer.UseVisualStyleBackColor = false;
            this.btnShowCustomer.Click += new System.EventHandler(this.btnShowCustomer_Click);
            // 
            // dtgvCustomer
            // 
            this.dtgvCustomer.AllowUserToAddRows = false;
            this.dtgvCustomer.AllowUserToDeleteRows = false;
            this.dtgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCustomer.Location = new System.Drawing.Point(387, 45);
            this.dtgvCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvCustomer.Name = "dtgvCustomer";
            this.dtgvCustomer.ReadOnly = true;
            this.dtgvCustomer.RowHeadersWidth = 51;
            this.dtgvCustomer.RowTemplate.Height = 24;
            this.dtgvCustomer.Size = new System.Drawing.Size(497, 423);
            this.dtgvCustomer.TabIndex = 14;
            // 
            // btnSearchCus
            // 
            this.btnSearchCus.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearchCus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchCus.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnSearchCus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSearchCus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSearchCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCus.ForeColor = System.Drawing.Color.White;
            this.btnSearchCus.Location = new System.Drawing.Point(853, 18);
            this.btnSearchCus.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchCus.Name = "btnSearchCus";
            this.btnSearchCus.Size = new System.Drawing.Size(20, 21);
            this.btnSearchCus.TabIndex = 21;
            this.btnSearchCus.UseVisualStyleBackColor = false;
            this.btnSearchCus.Click += new System.EventHandler(this.btnSearchCus_Click);
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.btnSearchCus);
            this.Controls.Add(this.txtSearchCus);
            this.Controls.Add(this.btnDeleteCustomer);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.grpCustomer);
            this.Controls.Add(this.btnShowCustomer);
            this.Controls.Add(this.dtgvCustomer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "KhachHang";
            this.Size = new System.Drawing.Size(1050, 528);
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchCus;
        private System.Windows.Forms.TextBox txtSearchCus;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.NumericUpDown nudPoint;
        private System.Windows.Forms.Label lblCusID;
        private System.Windows.Forms.TextBox txtCusAddress;
        private System.Windows.Forms.Label lblCusINumber;
        private System.Windows.Forms.Label lblCusBirth;
        private System.Windows.Forms.Label lblCusPhone;
        private System.Windows.Forms.Label lblCusPoint;
        private System.Windows.Forms.Label lblCusAddress;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.Button btnShowCustomer;
        private System.Windows.Forms.DataGridView dtgvCustomer;
        private Patterns.Strategy.MyTextBox txtCusPhone;
        private System.Windows.Forms.TextBox txtCusID;
        private Patterns.Strategy.MyTextBox txtCusINumber;
        private Patterns.Strategy.MyTextBox txtCusName;
        private Patterns.Strategy.MyTextBox txtCusBirth;
    }
}
