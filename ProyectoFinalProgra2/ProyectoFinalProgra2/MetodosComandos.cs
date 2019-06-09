using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalProgra2
{
    class MetodosComandos
    {
        Dictionary<string, int> VariableDict = new Dictionary<string, int>();
        int resultado;
        public int RemMetodo(int posicion)
        {
            return posicion;
        }
        public Dictionary<string, int> InputMetodo(string[] lista, int posicion, int testglobal)
        {
            string variable = lista[2];
            VariableDict.Add(variable, testglobal);
            return VariableDict;
        }
        public void LetMetodo(string[] listaLet)
        {
            resultado = 0;
            string operacion = listaLet[2];

            if (operacion.Length <= 5)
            {
                char[] vecLet = new char[operacion.Length];
                for (int i = 0; i < operacion.Length; i++)
                {
                    vecLet[i] = operacion[i];
                }

                string operando1 = vecLet[2].ToString();
                string operando2 = vecLet[4].ToString();
                int var1 = VariableDict[operando1];
                int var2 = VariableDict[operando2];

                switch (vecLet[3])
                {
                    case '+':
                        resultado = var1 + var2;
                        VariableDict.Add(vecLet[0].ToString(), resultado);
                        break;
                    case '-':
                        resultado = var1 - var2;
                        VariableDict.Add(vecLet[0].ToString(), resultado);
                        break;
                    case '/':
                        resultado = var1 / var2;
                        VariableDict.Add(vecLet[0].ToString(), resultado);
                        break;
                    case '*':
                        resultado = var1 * var2;
                        VariableDict.Add(vecLet[0].ToString(), resultado);
                        break;
                }
            }
            else
            {
                MessageBox.Show("No se permiten mas de 2 operaciones", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string PrintMetodo(string[] lista)
        {
            Comandos objComandos = new Comandos();
            string imprimir = "";

            if (lista.Count() > 3 || lista.Count() < 3)
            {
                MessageBox.Show("Error de compilacion en print", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return imprimir;
            }
            else if (lista.Count() == 3)
            {
                try
                {
                    int variable = VariableDict[lista[2]];
                    imprimir = variable.ToString();
                }
                catch (Exception)
                {
                    if (lista[1] == objComandos.print)
                    {
                        imprimir = lista[2];
                    }
                }
            }
            return imprimir;
        }
        public int GoToMetodo(string[] lista, int posicion)
        {
            Comandos objComandos = new Comandos();

            if (lista.Count() > 3)
            {
                MessageBox.Show("Error de compilacion en goto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return posicion;
            }
            else
            {
                if (lista[1] == objComandos.goTo)
                {
                    posicion = Int32.Parse(lista[2]);
                    posicion = posicion - 2;
                }
                return posicion;
            }
        }
        public int IfGoToMetodo(string[] lista, int posicion)
        {

            Comandos objComandos = new Comandos();
            if (lista.Count() == 6)
            {
                if (lista[1] == objComandos.ifGoto)
                {
                    string operador = lista[3];
                    switch (operador)
                    {
                        case "<":
                            try
                            {
                                if (Int32.Parse(lista[2]) < Int32.Parse(lista[4]))
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }

                            }
                            catch (Exception)
                            {
                                int variable1 = VariableDict[lista[2]];
                                int variable2 = VariableDict[lista[4]];
                                if (variable1 < variable2)
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }
                            }
                            break;
                        case ">":
                            try
                            {
                                if (Int32.Parse(lista[2]) > Int32.Parse(lista[4]))
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }

                            }
                            catch (Exception)
                            {
                                int variable1 = VariableDict[lista[2]];
                                int variable2 = VariableDict[lista[4]];
                                if (variable1 > variable2)
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }
                            }
                            break;
                        case "==":
                            try
                            {
                                if (Int32.Parse(lista[2]) == Int32.Parse(lista[4]))
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }

                            }
                            catch (Exception)
                            {
                                int variable1 = VariableDict[lista[2]];
                                int variable2 = VariableDict[lista[4]];
                                if (variable1 == variable2)
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }
                            }
                            break;
                        case "!=":
                            try
                            {
                                if (Int32.Parse(lista[2]) != Int32.Parse(lista[4]))
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }

                            }
                            catch (Exception)
                            {
                                int variable1 = VariableDict[lista[2]];
                                int variable2 = VariableDict[lista[4]];
                                if (variable1 != variable2)
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }
                            }
                            break;
                        case "<=":
                            try
                            {
                                if (Int32.Parse(lista[2]) <= Int32.Parse(lista[4]))
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }

                            }
                            catch (Exception)
                            {
                                int variable1 = VariableDict[lista[2]];
                                int variable2 = VariableDict[lista[4]];
                                if (variable1 <= variable2)
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }
                            }
                            break;
                        case ">=":
                            try
                            {
                                if (Int32.Parse(lista[2]) >= Int32.Parse(lista[4]))
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }

                            }
                            catch (Exception)
                            {
                                int variable1 = VariableDict[lista[2]];
                                int variable2 = VariableDict[lista[4]];
                                if (variable1 >= variable2)
                                {
                                    posicion = Int32.Parse(lista[5]);
                                    posicion = posicion - 2;
                                }
                            }
                            break;
                    }
                }
                return posicion;

            }
            else
            {
                MessageBox.Show("Error de compilacion en if...goto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return posicion;
            }
        }
        public string EndMetodo(string[] lista)
        {
            Comandos objComandos = new Comandos();
            string imprimir = "";

            if (lista.Count() > 2)
            {
                MessageBox.Show("Error de compilacion en end", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return imprimir;
            }
            else
            {
                if (lista[1] == objComandos.end)
                {
                    imprimir = "Compilación finalizada exitosamente";
                }
                return imprimir;
            }
        }
    }
}


