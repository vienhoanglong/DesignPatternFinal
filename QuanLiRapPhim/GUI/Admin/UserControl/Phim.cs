using QuanLiRapPhim.DAO;
using QuanLiRapPhim.DTO;
using QuanLiRapPhim.Patterns.Strategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim.frmAdminUserControls.DataUserControl
{
    public partial class Phim : UserControl
    {
        private ObjectCRUD MV;
        readonly BindingSource movieList = new BindingSource();

        public Phim()
        {
            MV = new ObjectCRUD("Phim");
            InitializeComponent();
            LoadMovie();
        }

        void LoadMovie()
        {
            dtgvMovie.DataSource = movieList;
            LoadMovieList();
            AddMovieBinding();
        }
        void LoadMovieList()
        {
            movieList.DataSource = MV.load();
        }
        private void btnShowMovie_Click(object sender, EventArgs e)
        {
            LoadMovieList();
        }
        void AddMovieBinding()
        {
            txtMovieID.DataBindings.Add("Text", dtgvMovie.DataSource, "Mã phim", true,  DataSourceUpdateMode.Never);
            txtMovieName.DataBindings.Add("Text", dtgvMovie.DataSource, "Tên phim", true, DataSourceUpdateMode.Never);
            txtMovieDesc.DataBindings.Add("Text", dtgvMovie.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
            txtMovieLength.DataBindings.Add("Text", dtgvMovie.DataSource, "Thời lượng", true, DataSourceUpdateMode.Never);
            dtmMovieStart.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày khởi chiếu", true, DataSourceUpdateMode.Never);
            dtmMovieEnd.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày kết thúc", true, DataSourceUpdateMode.Never);
            txtMovieProductor.DataBindings.Add("Text", dtgvMovie.DataSource, "Sản xuất", true, DataSourceUpdateMode.Never);
            txtMovieDirector.DataBindings.Add("Text", dtgvMovie.DataSource, "Đạo diễn", true, DataSourceUpdateMode.Never);
            txtMovieYear.DataBindings.Add("Text", dtgvMovie.DataSource, "Năm SX", true, DataSourceUpdateMode.Never);
            LoadGenreIntoCheckedList(clbMovieGenre);
        }
        void LoadGenreIntoCheckedList(CheckedListBox checkedList)
        {
            List<DTO.TheLoai> genreList = TheLoaiDAO.GetListGenre();
            checkedList.DataSource = genreList;
            checkedList.DisplayMember = "Name";
        }
        private void txtMovieID_TextChanged(object sender, EventArgs e)
        //Use to binding the CheckedListBox Genre of Movie and picture of Movie
        {
            picFilm.Image = null;
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                clbMovieGenre.SetItemChecked(i, false);
                //Uncheck all CheckBox first
            }

            List<DTO.TheLoai> listGenreOfMovie = PhanLoaiPhimDAO.GetListGenreByMovieID(txtMovieID.Text);
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                DTO.TheLoai genre = (DTO.TheLoai)clbMovieGenre.Items[i];
                foreach (DTO.TheLoai item in listGenreOfMovie)
                {
                    if (genre.ID == item.ID)
                    {
                        clbMovieGenre.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            DTO.Phim movie = PhimDAO.GetMovieByID(txtMovieID.Text);

            if (movie == null)
                return;

            if (movie.Poster != null)
                picFilm.Image = PhimDAO.byteArrayToImage(movie.Poster);
        }

        void InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            ArrayList data = new ArrayList() { id, name, desc, length, startDate, endDate, productor, director, year, image };

            MV.add(data);
        }
        void InsertMovie_Genre(string movieID, CheckedListBox checkedListBox)
        //Insert into table 'PhanLoaiPhim'
        {
            List<DTO.TheLoai> checkedGenreList = new List<DTO.TheLoai>();
            foreach (DTO.TheLoai checkedItem in checkedListBox.CheckedItems)
            {
                checkedGenreList.Add(checkedItem);
            }
            PhanLoaiPhimDAO.InsertMovie_Genre(movieID, checkedGenreList);
        }

        private void btnUpLoadPictureFilm_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathImage = null;
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePathImage = openFile.FileName;
                    picFilm.Image = Image.FromFile(filePathImage.ToString());
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            string movieName = txtMovieName.Text;
            string movieDesc = txtMovieDesc.Text;
            float movieLength = float.Parse(txtMovieLength.Text);
            DateTime startDate = dtmMovieStart.Value;
            DateTime endDate = dtmMovieEnd.Value;
            string productor = txtMovieProductor.Text;
            string director = txtMovieDirector.Text;
            int year = int.Parse(txtMovieYear.Text);
            if (picFilm.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước");
                return;
            }
            InsertMovie(movieID, movieName, movieDesc, movieLength, startDate, endDate, productor, director, year, PhimDAO.imageToByteArray(picFilm.Image));
            InsertMovie_Genre(movieID, clbMovieGenre);
            LoadMovieList();
        }

        void UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            ArrayList data = new ArrayList() { id, name, desc, length, startDate, endDate, productor, director, year, image };

            MV.update(data);
        }
        void UpdateMovie_Genre(string movieID, CheckedListBox checkedListBox)
        {
            List<DTO.TheLoai> checkedGenreList = new List<DTO.TheLoai>();
            foreach (DTO.TheLoai checkedItem in checkedListBox.CheckedItems)
            {
                checkedGenreList.Add(checkedItem);
            }
            PhanLoaiPhimDAO.UpdateMovie_Genre(movieID, checkedGenreList);
        }
        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            string movieName = txtMovieName.Text;
            string movieDesc = txtMovieDesc.Text;
            float movieLength = float.Parse(txtMovieLength.Text);
            DateTime startDate = dtmMovieStart.Value;
            DateTime endDate = dtmMovieEnd.Value;
            string productor = txtMovieProductor.Text;
            string director = txtMovieDirector.Text;
            int year = int.Parse(txtMovieYear.Text);
            if (picFilm.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước");
                return;
            }
            UpdateMovie(movieID, movieName, movieDesc, movieLength, startDate, endDate, productor, director, year, PhimDAO.imageToByteArray(picFilm.Image));
            UpdateMovie_Genre(movieID, clbMovieGenre);
            LoadMovieList();
        }

        void DeleteMovie(string id)
        {
           
            MV.delete(id);
        }
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            DeleteMovie(movieID);
            LoadMovieList();
        }

        private void lblMovieProductor_Click(object sender, EventArgs e)
        {

        }

        private void lblMovieLength_Click(object sender, EventArgs e)
        {

        }
    }
}
