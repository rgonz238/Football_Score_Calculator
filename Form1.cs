using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FootballScoreCalculator
{
    public partial class Form1 : Form
    {
        Calculator calc;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            calc = new Calculator(Convert.ToInt32(txtBxTeam1.Text), Convert.ToInt32(txtBxTeam2.Text));

            txtBxPtDef.Text = calc.PointDeficit.ToString();
            txtBxNumPoss.Text = calc.NumOfPoss.ToString();
            txtBxNumTchdown1.Text = calc.NumTchdn1Pt.ToString();
            txtBxNumTchdown2.Text = calc.NumTchdn2Pt.ToString();
            txtBxNumFG.Text = calc.NumOfFGs.ToString();     
            txtBxDesc.Text = calc.Message;
        }
    }
}
