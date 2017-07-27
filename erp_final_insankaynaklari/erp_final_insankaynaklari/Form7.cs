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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        public void veriGetir()
        {

            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand(" SELECT DEPARTMANADI,COUNT(*) AS SAYI FROM DEPARTMAN INNER JOIN CALISMA ON DEPARTMAN.DEPARTMANID=CALISMA.IDDEPARTMAN INNER JOIN CALISAN ON CALISMA.ISID=CALISAN.ISIDCAL GROUP BY DEPARTMANADI ", conn);
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
        private void Form7_Load(object sender, EventArgs e)
        {
            //veriGetir();
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-EHLEVPQ:1521/XE;PERSIST SECURITY INFO=True;USER ID=SEDA; PASSWORD=123456");
            OracleCommand cmd = new OracleCommand(" SELECT DEPARTMANADI,COUNT(*) AS SAYI FROM DEPARTMAN INNER JOIN CALISMA ON DEPARTMAN.DEPARTMANID=CALISMA.IDDEPARTMAN INNER JOIN CALISAN ON CALISMA.ISID=CALISAN.ISIDCAL GROUP BY DEPARTMANADI ", conn);
            DataTable TBLOGRNCI = new DataTable();

            try
            {

                conn.Open();
                dataGridView1.AutoGenerateColumns = false;
                TBLOGRNCI.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = TBLOGRNCI;
                for (int i =0;i<dataGridView1.Rows.Count-1;i++)
                {
                this.chart1.Series["sonuc"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()));
                    //string ad=dataGridView1.Rows[i].Cells[0].Value.ToString();
                    
                    //if((Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString())>2))
                    //{
                    //    MessageBox.Show("" +ad+" is gücü fazlaligi var");
                    //}
                    //else if ((Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()) <= 1))
                    //{
                    //    MessageBox.Show("" + ad + " is gücü azligi var");

                    //}
                }   
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
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
