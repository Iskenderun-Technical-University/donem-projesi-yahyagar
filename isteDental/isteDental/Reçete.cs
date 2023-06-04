using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isteDental
{
    public partial class Reçete : Form
    {
        public Reçete()
        {
            InitializeComponent();
        }
        ConnectionString Mycon = new ConnectionString();


        private void fiilHasta()
        {
            SqlConnection baglanti = Mycon.Getcon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from HastaTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            HastaASCb.ValueMember = "HAd";
            HastaASCb.DataSource = dt;
            baglanti.Close();

        }

        private void fiilTedavi()
        {
            SqlConnection baglanti = Mycon.Getcon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from RandevuTbl where Hasta='"+HastaASCb.SelectedValue.ToString()+"'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda=new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                TedaviTb.Text = dr["Tedavi"].ToString();
            }

            baglanti.Close();

        }

        private void Tedavi_Load(object sender, EventArgs e)
        {
            fiilHasta();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HastaASCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fiilTedavi();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            home hm= new home();        
            hm.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
    }
}
