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
    public partial class Consola : Form
    {
        private string[] vectorComandos;
        private MetodosComandos objMetodosComandos = new MetodosComandos();
        private ArrayList consola = new ArrayList();
        private Boolean tecladoActivo = false;
        Dictionary<string, int> VariableDict = new Dictionary<string, int>();
        string testglobal = "";
        int posInput = 0;
        private bool nonNumberEntered = false;

        public Consola(ArrayList lista)
        {
            InitializeComponent();
            CompilarInfo(lista);
            txtConsola.CharacterCasing = CharacterCasing.Lower;
        }

        private void CompilarInfo(ArrayList lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                int posicion = i;
                string fila = "";
                fila = lista[i].ToString();
                vectorComandos = fila.Split('#');

                i = Metodos(vectorComandos, i);
            }
        }

        private int Metodos(string[] vectorComnados, int posicion)
        {
            string metodo = vectorComnados[1];

            switch (metodo)
            {
                case "goto":
                    posicion = objMetodosComandos.GoToMetodo(vectorComnados, posicion);
                    break;
                case "print":
                    txtConsola.AppendText(objMetodosComandos.PrintMetodo(vectorComnados));
                    txtConsola.AppendText(Environment.NewLine);
                    break;
                case "rem":
                    posicion = objMetodosComandos.RemMetodo(posicion);
                    break;
                case "if...goto":
                    posicion = objMetodosComandos.IfGoToMetodo(vectorComnados, posicion);
                    break;
                case "end":
                    txtConsola.AppendText(Environment.NewLine);
                    txtConsola.AppendText(objMetodosComandos.EndMetodo(vectorComnados));
                    tecladoActivo = true;
                    break;
                case "input":
                    testglobal = "";
                    txtConsola.AppendText("? " + vectorComandos[2] + ": ");
                    this.ShowDialog();
                    break;
                case "let":
                    objMetodosComandos.LetMetodo(vectorComandos);
                    break;
            }
            return posicion;
        }

        private void txtConsola_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = tecladoActivo;
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void txtConsola_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = true;
            // e trae lo que escribí, revisar si se puede meter a uun entero
            int tam = 0;

            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                nonNumberEntered = false;
                if (e.KeyCode != Keys.Enter)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        testglobal = testglobal + e.KeyCode.ToString();
                        testglobal = testglobal.Replace("D", "");
                        testglobal = testglobal.Replace("NumPad", "");
                    }
                }
   }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                nonNumberEntered = false;
                if (e.KeyCode != Keys.Enter)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        testglobal = testglobal + e.KeyCode.ToString();
                        testglobal = testglobal.Replace("D", "");
                        testglobal = testglobal.Replace("NumPad", "");
                    }
                }

            }
            else if (e.KeyCode == Keys.Back)
            {
                nonNumberEntered = false;
                tam = testglobal.Length - 1;
                if (tam > -1)
                {
                    testglobal = testglobal.Remove(tam);
                }

            }
            else if (e.KeyCode == Keys.Enter)
            {
                nonNumberEntered = false;
                txtConsola.AppendText(Environment.NewLine);
                this.Close();
                int VarValue = Convert.ToInt32(testglobal);
                VariableDict = objMetodosComandos.InputMetodo(vectorComandos, posInput, VarValue);
            }
        }
    }
}
