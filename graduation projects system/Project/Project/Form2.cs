using Oracle.DataAccess.Client;
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
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    public partial class Form2 : Form
    {
        string ordb = "Data source=orcl;User Id=scott;  Password=tiger;";
        OracleConnection conn;

        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select project_dis from projects where project_name  =:name";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("name", textBox1.Text);
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr[0].ToString();
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "insert into projects values(:name, :dis)";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("name", textBox1.Text);
            c.Parameters.Add("dis", textBox2.Text);
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("insertion done succesfully");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "getSupId";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("name", textBox3.Text);
            c.Parameters.Add("id", OracleDbType.Int64, ParameterDirection.Output);
            c.ExecuteNonQuery();
            if (c.Parameters["id"].Value != DBNull.Value)
            {
                textBox4.Text = c.Parameters["id"].Value.ToString();
            }


        }

        bool check = true;
        private void button4_Click(object sender, EventArgs e)
        {
            if (check)
            {
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "showproject";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("output", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleDataReader dr = c.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0]);
                }
                dr.Close();
                check = false;
            }
            
        }
    }
}
