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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void veriGetir()
        {

            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("Select DEPARTMANADI,ISINISMI,YONETICIMI from DEPARTMAN INNER JOIN CALISMA ON DEPARTMAN.DEPARTMANID=CALISMA.IDDEPARTMAN", conn);
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
                    else if (RowType == " ")
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
        private void Form4_Load(object sender, EventArgs e)
        {
            veriGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            //OracleCommand cmd = new OracleCommand("Select DEPARTMANADI,ISINISMI,YONETICIMI from DEPARTMAN INNER JOIN CALISMA ON DEPARTMAN.DEPARTMANID=CALISMA.IDDEPARTMAN WHERE DEPARTMANADI LIKE '%" + txtara.Text + "'", conn);
            //DataTable TBLOGRNCI = new DataTable();

            //try
            //{

            //    conn.Open();
            //    // dataGridView1.AutoGenerateColumns = false;
            //    TBLOGRNCI.Load(cmd.ExecuteReader());
            //    dataGridView1.DataSource = TBLOGRNCI.;

            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        if (row.Cells[2].Value == null || row.Cells[2].Value == DBNull.Value) return;

            //        string RowType = row.Cells[2].Value.ToString();

            //        if (RowType == "Evet")
            //        {

            //            row.Cells[2].Style.BackColor = Color.Red;

            //        }
            //        else if (RowType == "Hayır")
            //        {
            //            row.Cells[2].Style.BackColor = Color.Purple;
            //        }
            //        else if (RowType == " ")
            //        {
            //            row.Cells[2].Style.BackColor = Color.PaleGreen;

            //        }

            //    }
            //    //txttc.Focus();

            //    conn.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand("Select DEPARTMANADI,ISINISMI,YONETICIMI from DEPARTMAN INNER JOIN CALISMA ON DEPARTMAN.DEPARTMANID=CALISMA.IDDEPARTMAN WHERE DEPARTMANADI LIKE '%" + txtara.Text + "%'", conn);
            DataTable tbl = new DataTable();
            conn.Open();
            tbl.Load(cmd.ExecuteReader());
            conn.Close();
            dataGridView1.DataSource = tbl;
        
        }
    }
}
