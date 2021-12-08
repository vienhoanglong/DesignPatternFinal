namespace QuanLiRapPhim.frmAdminUserControls.DataUserControl
{
    partial class TheLoai
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
            this.btnShowGenre = new System.Windows.Forms.Button();
            this.btnUpdateGenre = new System.Windows.Forms.Button();
            this.btnDeleteGenre = new System.Windows.Forms.Button();
            this.btnInsertGenre = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvGenre = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGenreDesc = new System.Windows.Forms.TextBox();
            this.lblGenreDesc = new System.Windows.Forms.Label();
            this.txtGenreName = new System.Windows.Forms.TextBox();
            this.lblGenreName = new System.Windows.Forms.Label();
            this.lblGenreID = new System.Windows.Forms.Label();
            this.txtGenreID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGenre)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowGenre
            // 
            this.btnShowGenre.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowGenre.ForeColor = System.Drawing.Color.White;
            this.btnShowGenre.Location = new System.Drawing.Point(33, 305);
            this.btnShowGenre.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowGenre.Name = "btnShowGenre";
            this.btnShowGenre.Size = new System.Drawing.Size(84, 39);
            this.btnShowGenre.TabIndex = 3;
            this.btnShowGenre.Text = "Xem";
            this.btnShowGenre.UseVisualStyleBackColor = false;
            this.btnShowGenre.Click += new System.EventHandler(this.btnShowGenre_Click);
            // 
            // btnUpdateGenre
            // 
            this.btnUpdateGenre.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateGenre.ForeColor = System.Drawing.Color.White;
            this.btnUpdateGenre.Location = new System.Drawing.Point(363, 305);
            this.btnUpdateGenre.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateGenre.Name = "btnUpdateGenre";
            this.btnUpdateGenre.Size = new System.Drawing.Size(84, 39);
            this.btnUpdateGenre.TabIndex = 2;
            this.btnUpdateGenre.Text = "Sửa";
            this.btnUpdateGenre.UseVisualStyleBackColor = false;
            this.btnUpdateGenre.Click += new System.EventHandler(this.btnUpdateGenre_Click);
            // 
            // btnDeleteGenre
            // 
            this.btnDeleteGenre.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGenre.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGenre.Location = new System.Drawing.Point(256, 305);
            this.btnDeleteGenre.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteGenre.Name = "btnDeleteGenre";
            this.btnDeleteGenre.Size = new System.Drawing.Size(84, 39);
            this.btnDeleteGenre.TabIndex = 1;
            this.btnDeleteGenre.Text = "Xóa";
            this.btnDeleteGenre.UseVisualStyleBackColor = false;
            this.btnDeleteGenre.Click += new System.EventHandler(this.btnDeleteGenre_Click);
            // 
            // btnInsertGenre
            // 
            this.btnInsertGenre.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnInsertGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertGenre.ForeColor = System.Drawing.Color.White;
            this.btnInsertGenre.Location = new System.Drawing.Point(142, 305);
            this.btnInsertGenre.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertGenre.Name = "btnInsertGenre";
            this.btnInsertGenre.Size = new System.Drawing.Size(84, 39);
            this.btnInsertGenre.TabIndex = 0;
            this.btnInsertGenre.Text = "Thêm";
            this.btnInsertGenre.UseVisualStyleBackColor = false;
            this.btnInsertGenre.Click += new System.EventHandler(this.btnInsertGenre_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvGenre);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1548, 638);
            this.panel1.TabIndex = 11;
            // 
            // dtgvGenre
            // 
            this.dtgvGenre.AllowUserToAddRows = false;
            this.dtgvGenre.AllowUserToDeleteRows = false;
            this.dtgvGenre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvGenre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvGenre.Location = new System.Drawing.Point(0, 0);
            this.dtgvGenre.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvGenre.Name = "dtgvGenre";
            this.dtgvGenre.ReadOnly = true;
            this.dtgvGenre.RowHeadersWidth = 51;
            this.dtgvGenre.Size = new System.Drawing.Size(746, 638);
            this.dtgvGenre.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.Controls.Add(this.txtGenreID);
            this.panel2.Controls.Add(this.lblGenreID);
            this.panel2.Controls.Add(this.txtGenreName);
            this.panel2.Controls.Add(this.lblGenreName);
            this.panel2.Controls.Add(this.txtGenreDesc);
            this.panel2.Controls.Add(this.lblGenreDesc);
            this.panel2.Controls.Add(this.btnInsertGenre);
            this.panel2.Controls.Add(this.btnDeleteGenre);
            this.panel2.Controls.Add(this.btnUpdateGenre);
            this.panel2.Controls.Add(this.btnShowGenre);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(746, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 638);
            this.panel2.TabIndex = 0;
            // 
            // txtGenreDesc
            // 
            this.txtGenreDesc.Location = new System.Drawing.Point(33, 159);
            this.txtGenreDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtGenreDesc.Multiline = true;
            this.txtGenreDesc.Name = "txtGenreDesc";
            this.txtGenreDesc.Size = new System.Drawing.Size(414, 127);
            this.txtGenreDesc.TabIndex = 1;
            // 
            // lblGenreDesc
            // 
            this.lblGenreDesc.AutoSize = true;
            this.lblGenreDesc.BackColor = System.Drawing.Color.MintCream;
            this.lblGenreDesc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGenreDesc.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblGenreDesc.Location = new System.Drawing.Point(29, 119);
            this.lblGenreDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenreDesc.Name = "lblGenreDesc";
            this.lblGenreDesc.Size = new System.Drawing.Size(76, 24);
            this.lblGenreDesc.TabIndex = 0;
            this.lblGenreDesc.Text = "Mô tả :";
            // 
            // txtGenreName
            // 
            this.txtGenreName.Location = new System.Drawing.Point(183, 68);
            this.txtGenreName.Margin = new System.Windows.Forms.Padding(4);
            this.txtGenreName.Name = "txtGenreName";
            this.txtGenreName.Size = new System.Drawing.Size(264, 22);
            this.txtGenreName.TabIndex = 1;
            // 
            // lblGenreName
            // 
            this.lblGenreName.AutoSize = true;
            this.lblGenreName.BackColor = System.Drawing.Color.MintCream;
            this.lblGenreName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGenreName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblGenreName.Location = new System.Drawing.Point(29, 68);
            this.lblGenreName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenreName.Name = "lblGenreName";
            this.lblGenreName.Size = new System.Drawing.Size(134, 24);
            this.lblGenreName.TabIndex = 0;
            this.lblGenreName.Text = "Tên thể loại :";
            // 
            // lblGenreID
            // 
            this.lblGenreID.AutoSize = true;
            this.lblGenreID.BackColor = System.Drawing.Color.MintCream;
            this.lblGenreID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGenreID.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblGenreID.Location = new System.Drawing.Point(29, 15);
            this.lblGenreID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenreID.Name = "lblGenreID";
            this.lblGenreID.Size = new System.Drawing.Size(126, 24);
            this.lblGenreID.TabIndex = 0;
            this.lblGenreID.Text = "Mã thể loại :";
            // 
            // txtGenreID
            // 
            this.txtGenreID.Location = new System.Drawing.Point(183, 15);
            this.txtGenreID.Margin = new System.Windows.Forms.Padding(4);
            this.txtGenreID.Name = "txtGenreID";
            this.txtGenreID.Size = new System.Drawing.Size(264, 22);
            this.txtGenreID.TabIndex = 1;
            // 
            // TheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TheLoai";
            this.Size = new System.Drawing.Size(1548, 638);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGenre)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnShowGenre;
        private System.Windows.Forms.Button btnUpdateGenre;
        private System.Windows.Forms.Button btnDeleteGenre;
        private System.Windows.Forms.Button btnInsertGenre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtGenreDesc;
        private System.Windows.Forms.Label lblGenreDesc;
        private System.Windows.Forms.TextBox txtGenreName;
        private System.Windows.Forms.Label lblGenreName;
        private System.Windows.Forms.DataGridView dtgvGenre;
        private System.Windows.Forms.TextBox txtGenreID;
        private System.Windows.Forms.Label lblGenreID;
    }
}
