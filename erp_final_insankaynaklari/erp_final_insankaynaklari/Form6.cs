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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void pozGetir()
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("select ISINISMI from CALISMA ORDER BY ISID ", conn);
            DataTable TBLBLM = new DataTable();

            try
            {

                conn.Open();
                TBLBLM.Load(cmd.ExecuteReader());

                for (int i = 0; i < TBLBLM.Rows.Count; i++)
                {
                    cmbpoz.Items.Add(TBLBLM.Rows[i]["ISINISMI"]);
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
            OracleCommand cmd = new OracleCommand("  select CALISANID,CALISANADI,CALISANSOYADI,EMAIL,TELEFONNUMARASI,ISINISMI ,MAAS,BTARIH,CTARIH from CALISAN INNER JOIN CALISMA ON CALISAN.ISIDCAL=CALISMA.ISID", conn);
            DataTable TBLOGRNCI = new DataTable();

            try
            {

                conn.Open();
                 dataGridView1.AutoGenerateColumns = false;
                TBLOGRNCI.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = TBLOGRNCI;
                //txttc.Focus();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            pozGetir();
            veriGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("SELECT ISID FROM CALISMA where ISINISMI='" + cmbpoz.Text + "'", conn);
            DataTable TBLBLM = new DataTable();

            try
            {

                conn.Open();
                // dataGridView1.AutoGenerateColumns = false;
                TBLBLM.Load(cmd.ExecuteReader());

                if (TBLBLM.Rows.Count > 0)
                {
                    cmd.CommandText = "insert into CALISAN(CALISANID,CALISANADI,CALISANSOYADI,EMAIL,TELEFONNUMARASI,ISIDCAL,MAAS,BTARIH,CTARIH) values(hesap_seq.NEXTVAL, '" + txtad.Text + "','" + txtsoyad.Text + "','"+txtemail.Text+"','" + txttelno.Text + "'," + Convert.ToInt32(TBLBLM.Rows[0][0]) + ",'"+txtmaas.Text+"','" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "','" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "')";
                    cmd.ExecuteNonQuery();
                    veriGetir();
                }
                conn.Close();
                //txttc.Clear();
                //txtad.Clear();
                //txtadres.Clear();
                ////txtogrencino.Clear();
                //txtsoyad.Clear();
                //txtresimyolu.Clear();
                //txttc.Focus();
                //maskedTextBox1.Clear();
                MessageBox.Show("Kayit Başarıyla eklendi!!!!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenalan = dataGridView1.SelectedCells[0].RowIndex;
            string calisanid = dataGridView1.Rows[secilenalan].Cells[0].Value.ToString();
            string calisanadi = dataGridView1.Rows[secilenalan].Cells[1].Value.ToString();
            string calisansoyadi = dataGridView1.Rows[secilenalan].Cells[2].Value.ToString();
            string email = dataGridView1.Rows[secilenalan].Cells[3].Value.ToString();
            string telefonnumarasi = dataGridView1.Rows[secilenalan].Cells[4].Value.ToString();
            string isidcal = dataGridView1.Rows[secilenalan].Cells[5].Value.ToString();
            string maas = dataGridView1.Rows[secilenalan].Cells[6].Value.ToString();
            string btarih = dataGridView1.Rows[secilenalan].Cells[7].Value.ToString();
            string ctarih = dataGridView1.Rows[secilenalan].Cells[8].Value.ToString();


            txtcalid.Text = calisanid;
            txtad.Text = calisanadi;
            txtsoyad.Text = calisansoyadi;
            txtemail.Text = email;
            txttelno.Text = telefonnumarasi;
            cmbpoz.Text = isidcal;
            txtmaas.Text = maas;
            dateTimePicker1.Text = btarih;
            dateTimePicker2.Text = ctarih;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string bolum = cmbpoz.SelectedItem.ToString();
                //string sinif = cmbsinif.SelectedItem.ToString();
                OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
                conn.Open();
                OracleCommand cmd1 = new OracleCommand("select ISID from CALISMA WHERE ISINISMI='" + bolum + "'", conn);
                DataTable TBLBLM = new DataTable();
                TBLBLM.Load(cmd1.ExecuteReader());
                cmd1.CommandText = "UPDATE CALISAN SET CALISANADI='" + txtad.Text + "',CALISANSOYADI='" + txtsoyad.Text + "',EMAIL='" + txtemail.Text + "',TELEFONNUMARASI='" + txttelno.Text + "',ISIDCAL=" + TBLBLM.Rows[0][0] + ",BTARIH='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "',CTARIH='" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' where CALISANID='" + txtcalid.Text + "'";

                // conn.Open();
                cmd1.ExecuteNonQuery();
                veriGetir();
                conn.Close();
                //txttc.Clear();
                //txtad.Clear();
                //txtadres.Clear();
                ////txtogrencino.Clear();
                //txtsoyad.Clear();
                //txtogrenciid.Clear();
                //maskedTextBox1.Clear();
                //dataGridView1.Focus();

                MessageBox.Show("Güncelleme Başarıyle gerçekleşti!!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
