using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalProgra2
{
    public partial class LNSform : Form
    {
        private ArrayList listanueva;
        private static string[] lista;
        private int Renglones = 2;

        public LNSform()
        {
            InitializeComponent();
            txtBox.Text = "1#" + System.Environment.NewLine;
            txtBox.CharacterCasing = CharacterCasing.Lower;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info objInfo = new Info();
            objInfo.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            txtBox.Clear();
            Renglones = 1;
            txtBox.Text = Renglones.ToString() + "#" + System.Environment.NewLine;
            Renglones++;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string archivo;
            openFileDialog1.ShowDialog();
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
            archivo = file.ReadToEnd();
            txtBox.Text = archivo.ToString();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Sin Titulo.txt";
            var guardarArchivo = saveFileDialog1.ShowDialog();
            if (guardarArchivo == DialogResult.OK)
            {
                using (var Savefile = new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    Savefile.WriteLine(txtBox.Text);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("Desea salir de LNS?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBox.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBox.Paste();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBox.Cut();
        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listanueva = AgregarEnLista(lista);
            Consola objConsola = new Consola(listanueva);
            objConsola.ShowDialog();
        }
        public ArrayList AgregarEnLista(string[] lista)
        {
            string textoCompleto = txtBox.Text;
            lista = textoCompleto.Split('\n', '\r');
            ArrayList nuevalista = new ArrayList();
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].Equals(""))
                {

                }
                else { nuevalista.Add(lista[i]); }
            }
            return nuevalista;
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string contenido = txtBox.Text;
                txtBox.Text = contenido;
                string numero = Convert.ToString(Renglones);
                txtBox.AppendText("\n" + numero + "#");
                Renglones++;
            }
        }
    }
}
