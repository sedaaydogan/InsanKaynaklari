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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        public void veriGetir()
        {

            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand(" SELECT * FROM CALISMAGECMISI", conn);
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
        private void Form9_Load(object sender, EventArgs e)
        {
            veriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
