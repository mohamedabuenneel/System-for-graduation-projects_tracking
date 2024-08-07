using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
namespace Project
{
    
    public partial class Form5 : Form
    {
        CrystalReport5 CR;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = CR;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport5();
            foreach (ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
