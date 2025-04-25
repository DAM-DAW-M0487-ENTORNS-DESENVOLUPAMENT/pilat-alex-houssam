using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using EstructuresDeDades;

namespace PilaT
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            
            string text = txtCompilador.Text;
            Compilador compilador = new Compilador();

            if (compilador.Validar(text))
            {
                MessageBox.Show("Es correcte :)");
            }
            else
            {
                MessageBox.Show("Es incorrecte :(");
            }
        }

        private void b_ObrirFitxer_Click(object sender, EventArgs e)
        {
            OpenFileDialog finestre = new OpenFileDialog();
            finestre.Filter = "Archivos de texto (*.txt)|*.txt";
            finestre.Title = "Archiu txt";
            StringBuilder sortida = new StringBuilder();

            if (finestre.ShowDialog() == DialogResult.OK)
            {
                string filePath = finestre.FileName;
                Compilador compilador = new Compilador();
                StreamReader sr = new StreamReader(filePath);
                TaulaLlista<string> contingut = new TaulaLlista<string>(1000);
                string linia = sr.ReadLine();
                int i = 1;
                while(linia != null)
                {
                    contingut.Add(linia);
                    linia = sr.ReadLine();
                }
                sr.Close();
                foreach (string line in contingut)
                {
                    if (compilador.Validar(line))
                    {
                         sortida.AppendLine($"linia {i++}) Es correcte :)");
                    }
                    else
                    {
                        sortida.AppendLine($"linia {i++}) Es incorrecte :(");
                    }
                } 
            }
            else
            {
                MessageBox.Show("No se a seleccionat cap archiu");
            }
            MessageBox.Show(sortida.ToString());

        }

        private void btnPolaca_Click(object sender, EventArgs e)
        {
            string entrada = txtPolaca.Text;

            if (!Polaca.EsNotacionPolaca(entrada))
            {
                MessageBox.Show("La entrada está en notación polaca.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La entrada NO está en notación polaca.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
