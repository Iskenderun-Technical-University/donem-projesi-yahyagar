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
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection baglanti = MyConnection.Getcon();

            string query = "insert into TedaviTbl values('" + TedaviAdiTb.Text + "','" + TutarTb.Text + "','"+AciklamaTb+"')";
            hastalar Hs = new hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Tedavi Başarıyla Eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            baglanti.Close();
        }

        private void Tedavi_Load(object sender, EventArgs e)
        {
            hastalar Hs = new hastalar();
            string query = "select * from TedaviTbl";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }
        int key = 0;
        private void TedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TedaviAdiTb.Text = TedaviDGV.SelectedRows[0].Cells[0].Value.ToString();
            TutarTb.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            AciklamaTb.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();
           
            if (TedaviAdiTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void TedaviAdiTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
