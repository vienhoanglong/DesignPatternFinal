﻿using QuanLiRapPhim.DAO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim.frmAdminUserControls.DataUserControl
{
    public partial class TheLoai : UserControl
    {
        readonly BindingSource genreList = new BindingSource();

        public TheLoai()
        {
            InitializeComponent();
            LoadGenre();
        }

        void LoadGenre()
        {
            dtgvGenre.DataSource = genreList;
            LoadGenreList();
            AddGenreBinding();
        }
        void LoadGenreList()
        {
            genreList.DataSource = TheLoaiDAO.GetGenre();
        }
        void AddGenreBinding()
        {
            txtGenreID.DataBindings.Add("Text", dtgvGenre.DataSource, "Mã thể loại", true, DataSourceUpdateMode.Never);
            txtGenreName.DataBindings.Add("Text", dtgvGenre.DataSource, "Tên thể loại", true, DataSourceUpdateMode.Never);
            txtGenreDesc.DataBindings.Add("Text", dtgvGenre.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
        }
        private void btnShowGenre_Click(object sender, EventArgs e)
        {
            LoadGenreList();
        }

        void InsertGenre(string id, string name, string desc)
        {
            if (TheLoaiDAO.InsertGenre(id, name, desc))
            {
                MessageBox.Show("Thêm thể loại thành công");
            }
            else
            {
                MessageBox.Show("Thêm thể loại thất bại");
            }
        }
        private void btnInsertGenre_Click(object sender, EventArgs e)
        {
            string GenreID = txtGenreID.Text;
            string GenreName = txtGenreName.Text;
            string GenreDesc = txtGenreDesc.Text;
            InsertGenre(GenreID, GenreName, GenreDesc);
            LoadGenreList();
        }

        void UpdateGenre(string id, string name, string desc)
        {
            if (TheLoaiDAO.UpdateGenre(id, name, desc))
            {
                MessageBox.Show("Sửa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Sửa thể loại thất bại");
            }
        }
        private void btnUpdateGenre_Click(object sender, EventArgs e)
        {
            string GenreID = txtGenreID.Text;
            string GenreName = txtGenreName.Text;
            string GenreDesc = txtGenreDesc.Text;
            UpdateGenre(GenreID, GenreName, GenreDesc);
            LoadGenreList();
        }

        void DeleteGenre(string id)
        {
            if (TheLoaiDAO.DeleteGenre(id))
            {
                MessageBox.Show("Xóa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Xóa thể loại thất bại");
            }
        }
        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            string GenreID = txtGenreID.Text;
            DeleteGenre(GenreID);
            LoadGenreList();
        }

        
    }
}
