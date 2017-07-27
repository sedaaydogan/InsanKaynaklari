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
    public partial class Form8 : Form
    {
        public Form8()
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

        private void Form8_Load(object sender, EventArgs e)
        {
            pozGetir();
            veriGetir();
        }

       // insert into CALISAN(CALISANID,CALISANADI,CALISANSOYADI,EMAIL,TELEFONNUMARASI,ISIDCAL,MAAS,BTARIH,CTARIH) values(hesap_seq.NEXTVAL, '" + txtad.Text + "','" + txtsoyad.Text + "','"+txtemail.Text+"','" + txttelno.Text + "'," + Convert.ToInt32(TBLBLM.Rows[0][0]) + ",'"+txtmaas.Text+"','" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "','" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "')";
  
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
            string ctarih= dataGridView1.Rows[secilenalan].Cells[8].Value.ToString();


            txtid.Text = calisanid;
            txtad.Text = calisanadi;
            txtsoyad.Text = calisansoyadi;
            txtemail.Text = email;
            txttelno.Text = telefonnumarasi;
            cmbpoz.Text = isidcal;
            txtmaas.Text = maas;
            dateTimePicker1.Text = btarih;
            dateTimePicker2.Text = ctarih;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update  CALISAN set BTARIH='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' where CALISANID='" + txtid.Text + "'";

                conn.Open();
                cmd.ExecuteNonQuery();
               // veriGetir();
               // MessageBox.Show("Güncelleme Başarıyle gerçekleşti!!!!");

                cmd.CommandText="SELECT ISINISMI FROM CALISMA where ISINISMI='" + cmbpoz.Text + "'";
                DataTable TBLBLM = new DataTable();
                    TBLBLM.Load(cmd.ExecuteReader());

                    if (TBLBLM.Rows.Count > 0)
                    {
                        cmd.CommandText = "insert into CALISMAGECMISI(CALISANID,BASLANGICTARIHI,CIKISTARIHI,ISADI,CALADI,CALSOYADI) values(hesap_seq.NEXTVAL, '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "','" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "','" + TBLBLM.Rows[0][0] + "','"+txtad.Text+"','"+txtsoyad.Text+"')";
                        cmd.ExecuteNonQuery();
                        //veriGetir();
                    }
                    
                cmd.CommandText = "Delete from CALISAN  where CALISANID='" + txtid.Text + "'";
                cmd.ExecuteNonQuery();
                veriGetir();
                conn.Close();
                
                MessageBox.Show("Kisinin isine son verilmis olup ana sayfaya donup personel dosyalarindan eski bilgilerine erisebilirsiniz !!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
