using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Project
{
    public partial class Form1 : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
       // CrystalReport4 CR;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CR = new CrystalReport4();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source = orcl; User Id = hr; Password = hr;";
            string cmdstr = "SELECT project_name, team_name, student_id  FROM students WHERE student_id =:id";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id", textBox1.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //crystalReportViewer1.ReportSource = CR;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
