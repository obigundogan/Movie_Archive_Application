using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Film_Arsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5VIVL0L; Initial Catalog=FilmArsivi; Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFILMLER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
            

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (AD,KATEGORI,LINK) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtfilmad.Text);
            komut.Parameters.AddWithValue("@p2", txtkategori.Text);
            komut.Parameters.AddWithValue("@p3", txtlink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listenize Eklendi..");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void btnhakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje İbrahim Gündoğan Tarafından 15.04.2024 tarihinde yapıldı.");
        }

        private void btncıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
