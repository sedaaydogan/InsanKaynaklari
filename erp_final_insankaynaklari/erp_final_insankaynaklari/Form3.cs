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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void departmanGetir()
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("select DEPARTMANADI from DEPARTMAN ORDER BY DEPARTMANID", conn);
            DataTable TBLBLM = new DataTable();

            try
            {

                conn.Open();
                TBLBLM.Load(cmd.ExecuteReader());

                for (int i = 0; i < TBLBLM.Rows.Count; i++)
                {
                    comboBox1.Items.Add(TBLBLM.Rows[i]["DEPARTMANADI"]);
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
            OracleCommand cmd = new OracleCommand("SELECT ISID,ISINISMI,YONETICIMI,MINMAAS,MAXMAAS,DEPARTMANADI FROM CALISMA INNER JOIN DEPARTMAN ON CALISMA.IDDEPARTMAN=DEPARTMAN.DEPARTMANID", conn);
            DataTable TBLOGRNCI = new DataTable();

            try
            {

                conn.Open();
                // dataGridView1.AutoGenerateColumns = false;
                TBLOGRNCI.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = TBLOGRNCI;
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[2].Value == null || row.Cells[2].Value == DBNull.Value) return;

                    string RowType = row.Cells[2].Value.ToString();
                    
                    if (RowType == "Evet")
                    {

                        row.Cells[2].Style.BackColor = Color.Red;

                    }
                    else if (RowType == "Hayır")
                    {
                        row.Cells[2].Style.BackColor = Color.Purple;
                    }
                    else if(RowType==" ")
                    {
                        row.Cells[2].Style.BackColor = Color.PaleGreen;

                    }
                    
                }
                //txttc.Focus();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            departmanGetir();
            veriGetir();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Delete from CALISMA where ISID='" + txtid.Text + "'";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    veriGetir();
                    conn.Close();
                    txtid.Clear();
                    txtmaxmaas.Clear();
                    txtminmaas.Clear();
                    txtpozsyon.Clear();
                    dataGridView1.Focus();

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

                string bolum = comboBox1.SelectedItem.ToString();
                //string sinif = cmbsinif.SelectedItem.ToString();
                OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
                conn.Open();
                OracleCommand cmd1 = new OracleCommand("select DEPARTMANID from DEPARTMAN WHERE DEPARTMANADI='" + bolum + "'", conn);
                DataTable TBLBLM = new DataTable();
                TBLBLM.Load(cmd1.ExecuteReader());
                cmd1.CommandText = "UPDATE CALISMA SET ISINISMI='" + txtpozsyon.Text + "',YONETICIMI='" + cmbYonetici.SelectedItem.ToString() + "',MINMAAS='" + txtminmaas.Text + "',MAXMAAS='" + txtmaxmaas.Text + "',IDDEPARTMAN=" + TBLBLM.Rows[0][0] + " WHERE ISID='" + txtid.Text + "'";

                // conn.Open();
                cmd1.ExecuteNonQuery();
                veriGetir();
                conn.Close();
                txtid.Clear();
                txtmaxmaas.Clear();
                txtminmaas.Clear();
                txtpozsyon.Clear();
               

                dataGridView1.Focus();

                MessageBox.Show("Güncelleme Başarıyle gerçekleşti!!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("select DEPARTMANID from DEPARTMAN WHERE DEPARTMANADI='" + comboBox1.Text + "'", conn);
            DataTable TBLBLM = new DataTable();

            try
            {

                conn.Open();
                // dataGridView1.AutoGenerateColumns = false;
                TBLBLM.Load(cmd.ExecuteReader());

                if (TBLBLM.Rows.Count > 0)
                {
                    cmd.CommandText = "insert into CALISMA(ISID,ISINISMI,YONETICIMI,MINMAAS,MAXMAAS,IDDEPARTMAN) values(hesap_seq.NEXTVAL,'" + txtpozsyon.Text + "','" + cmbYonetici.SelectedItem.ToString() + "','" + txtminmaas.Text + "','" + txtmaxmaas.Text + "'," + Convert.ToInt32(TBLBLM.Rows[0][0]) + ")";
                    cmd.ExecuteNonQuery();
                    veriGetir();
                }
                conn.Close();
                txtid.Clear();
                txtmaxmaas.Clear();
                txtminmaas.Clear();
                txtpozsyon.Clear();
               
                //txttc.Focus();
                
                MessageBox.Show("Kayit Başarıyla eklendi!!!!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenalan = dataGridView1.SelectedCells[0].RowIndex;
            string isid = dataGridView1.Rows[secilenalan].Cells[0].Value.ToString();
            string i_adi = dataGridView1.Rows[secilenalan].Cells[1].Value.ToString();
            string yoneticimi = dataGridView1.Rows[secilenalan].Cells[2].Value.ToString();
            string minmass = dataGridView1.Rows[secilenalan].Cells[3].Value.ToString();
            string maxmaas = dataGridView1.Rows[secilenalan].Cells[4].Value.ToString();
            string dep = dataGridView1.Rows[secilenalan].Cells[5].Value.ToString();

            txtid.Text = isid;
            txtpozsyon.Text = i_adi;
            cmbYonetici.Text = yoneticimi;
            txtminmaas.Text = minmass;
            txtmaxmaas.Text = maxmaas; 
            comboBox1.Text = dep;
        }

        private void txtmaxmaas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtminmaas_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
