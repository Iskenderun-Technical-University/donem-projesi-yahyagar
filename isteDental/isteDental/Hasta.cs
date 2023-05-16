using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isteDental
{
    public partial class Hasta : Form
    {
        
        public Hasta()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Hasta_Load(object sender, EventArgs e)
        {
            hastalar Hs = new hastalar();
            string query = "select * from HastaTbl";
            DataSet ds= Hs.ShowHasta(query);
            HastaDGV.DataSource= ds.Tables[0];
                

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection baglanti = MyConnection.Getcon();

            string query = "insert into HastaTbl values('" + HAdSoyad.Text + "','" + HTelefon.Text + "','" + HAdres.Text + "','" + HDogumTarihi.Value.Date + "','" + HCinsiyet.SelectedItem.ToString() + "','" + HAlerji.Text + "')";
            hastalar Hs = new hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Hasta Başarıyla Eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int key = 0;
        private void HastaDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdSoyad.Text = HastaDGV.SelectedRows[0].Cells[0].Value.ToString();
            HTelefon.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HAdres.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HDogumTarihi.Text = HastaDGV.Rows[0].Cells[4].Value.ToString();
            HCinsiyet.SelectedItem = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HAlerji.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (HAdSoyad.Text == "")
            {
                key = 0;

            }else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
