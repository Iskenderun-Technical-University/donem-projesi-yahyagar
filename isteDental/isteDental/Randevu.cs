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

namespace isteDental
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }
      

        private void Randevu_Load(object sender, EventArgs e)
        {
            fiilHasta();
            fiilTedavi();
        }
        ConnectionString Mycon=new ConnectionString();


        private void fiilHasta()
        {
            SqlConnection baglanti = Mycon.Getcon();
            baglanti.Open();
            SqlCommand komut=new SqlCommand("select HAd from HastaTbl",baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt= new DataTable();
            dt.Columns.Add("HAd",typeof(string));
            dt.Load(rdr);
            RadCb.ValueMember = "HAd";
            RadCb.DataSource = dt;
            baglanti.Close();

        }
        private void fiilTedavi()
        {
            SqlConnection baglanti = Mycon.Getcon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TAd from TedaviTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TAd", typeof(string));
            dt.Load(rdr);
            RtedaviCb.ValueMember = "TAd";
            RtedaviCb.DataSource = dt;
            baglanti.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection baglanti = MyConnection.Getcon();

            string query = "insert into RandevuTbl values('" + RadCb.SelectedValue.ToString() + "','" + RtedaviCb.SelectedValue.ToString() + "','" + Rtarih.Value.Date + "','" + SaatCb.Text + "')";
            hastalar Hs = new hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Randevu Başarıyla Eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void RandevuDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            RadCb.SelectedValue = RandevuDGV.SelectedRows[0].Cells[0].Value.ToString();
            RtedaviCb.SelectedValue = RandevuDGV.SelectedRows[0].Cells[1].Value.ToString();
            Rtarih.Text = RandevuDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (RadCb.SelectedIndex == -1)
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(RandevuDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            home hm = new home();
            hm.Show();
            this.Hide();
        }
    }
    }

