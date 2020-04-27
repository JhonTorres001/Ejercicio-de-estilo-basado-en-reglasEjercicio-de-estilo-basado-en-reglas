using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SbsSW.SwiPlCs;

namespace InterfaceProlog
{
    public partial class formBD : Form
    {
        public formBD()
        {
            InitializeComponent();
        }

        private void formBD_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"prolog");
            Environment.SetEnvironmentVariable("Path", @"prolog");
            Environment.SetEnvironmentVariable("Path", @"prolog\bin");
            string[] p = { "-q", "-f", @"materia.pl" };
            PlEngine.Initialize(p);
            PlQuery c = new PlQuery("educacion");
            c.NextSolution();
        }

        private void btnCons_Click(object sender, EventArgs e)
        {
            PlQuery materia = new PlQuery("materia(E,C)");
            materia.Variables["E"].Unify(txtcap.Text.ToLower());
            if (materia.NextSolution() == true)
            {
         
               
                MessageBox.Show(materia.Variables["C"].ToString().ToUpper());
                txtcap.Text = "";
                txtcap.Focus();
            }
            else
            {
                MessageBox.Show("Materia no encontrada");
                DialogResult r = MessageBox.Show("Registrar Materia? ?", "Ayuda", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    lblajuda.Visible = true;
                    txtajuda.Visible = true;
                    btnConf.Visible = true;
                    lblajuda.Text = "Favor digitar la materia de " + txtcap.Text;
                    txtajuda.Focus();
                }
                else
                    MessageBox.Show("Gracias!");
            }
        }

        private void formBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlQuery q = new PlQuery("guardar");
            q.NextSolution();
            PlEngine.PlCleanup();
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            PlQuery add = new PlQuery("agregar(E,C)");
            add.Variables["E"].Unify(txtcap.Text.ToLower());
            add.Variables["C"].Unify(txtajuda.Text.ToLower());
            add.NextSolution();
            txtajuda.Visible = false;
            btnConf.Visible = false;
            lblajuda.Visible = false;
            MessageBox.Show("Registro insertado gracias :)");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
