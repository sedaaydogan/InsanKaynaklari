using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace erp_final_insankaynaklari
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void adresGetir()
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("select ADRES from KONUM ORDER BY KONUMID", conn);
            DataTable TBLBLM = new DataTable();

            try
            {

                conn.Open();
                TBLBLM.Load(cmd.ExecuteReader());

                for (int i = 0; i < TBLBLM.Rows.Count; i++)
                {
                    cmbkonum.Items.Add(TBLBLM.Rows[i]["ADRES"]);
                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void veriGetir()
        {

            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("SELECT DEPARTMANID,DEPARTMANADI,ADRES FROM DEPARTMAN INNER JOIN KONUM ON DEPARTMAN.IDKONUM=KONUM.KONUMID", conn);
            DataTable TBLBLM = new DataTable();

            try
            {

                conn.Open();
                 //dataGridView1.AutoGenerateColumns = false;
                TBLBLM.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = TBLBLM;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Delete from DEPARTMAN where DEPARTMANID='" + txtd_id.Text + "'";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    veriGetir();
                    conn.Close();
                    txtorganizasyon.Clear();
                   
                    MessageBox.Show("Kayıt Başarıyla Silindi!!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string konum = cmbkonum.SelectedItem.ToString();
                OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
                conn.Open();
                OracleCommand cmd1 = new OracleCommand("select KONUMID from KONUM WHERE ADRES='" + konum + "'", conn);
                DataTable TBLBLM = new DataTable();
                TBLBLM.Load(cmd1.ExecuteReader());
                cmd1.CommandText = "update  DEPARTMAN set DEPARTMANADI='" + txtorganizasyon.Text + "',IDKONUM=" + TBLBLM.Rows[0][0] + " where DEPARTMANID='" + txtd_id.Text + "'";

                // conn.Open();
                cmd1.ExecuteNonQuery();
                veriGetir();
                conn.Close();
                txtorganizasyon.Clear();

                MessageBox.Show("Güncelleme Başarıyle gerçekleşti!!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            adresGetir();
            veriGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int secilenalan = dataGridView1.SelectedCells[0].RowIndex;
            //string d_id = dataGridView1.Rows[secilenalan].Cells[0].Value.ToString();
            //string d_adi = dataGridView1.Rows[secilenalan].Cells[1].Value.ToString();
            //string adres = dataGridView1.Rows[secilenalan].Cells[2].Value.ToString();
            //txtd_id.Text = d_id;
            //txtorganizasyon.Text = d_adi;
            //cmbkonum.Text = adres;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("select KONUMID from KONUM WHERE ADRES='" + cmbkonum.Text + "'", conn);
            DataTable TBLBLM = new DataTable();

            try
            {

                conn.Open();
                // dataGridView1.AutoGenerateColumns = false;
                TBLBLM.Load(cmd.ExecuteReader());

            
                if (TBLBLM.Rows.Count > 0)
                {
                    cmd.CommandText = "insert into DEPARTMAN(DEPARTMANID,DEPARTMANADI,IDKONUM) values( hesap_seq.NEXTVAL,'" + txtorganizasyon.Text + "','" + Convert.ToInt32(TBLBLM.Rows[0][0]) + "')";
                    cmd.ExecuteNonQuery();
                    veriGetir();
                }


                MessageBox.Show("Kayit Başarıyla eklendi!!!!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();
                txtorganizasyon.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilenalan = dataGridView1.SelectedCells[0].RowIndex;
            string d_id = dataGridView1.Rows[secilenalan].Cells[0].Value.ToString();
            string d_adi = dataGridView1.Rows[secilenalan].Cells[1].Value.ToString();
            string adres = dataGridView1.Rows[secilenalan].Cells[2].Value.ToString();
            txtd_id.Text = d_id;
            txtorganizasyon.Text = d_adi;
            cmbkonum.Text = adres;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtorganizasyon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
