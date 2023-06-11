using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operaciones_Matrices
{
    internal class Matriz
    {
        private double[,] _matriz;

        public double[,] matriz { get => _matriz; set => _matriz = value; }

        public Matriz(int filas, int columnas)
        {
            _matriz = new double[filas, columnas];
        }

        public double this[int i, int j]
        {
            get { return _matriz[i, j]; }
            set { _matriz[i, j] = value; }
        }

        public int Filas
        {
            get { return _matriz.GetLength(0); }
        }

        public int Columnas
        {
            get { return _matriz.GetLength(1); }
        }
        public static Matriz Suma(Matriz matriz1, Matriz matriz2)
        {
            if (matriz1.Filas != matriz2.Filas || matriz1.Columnas != matriz2.Columnas)
                throw new ArgumentException("Las dimensiones de las matrices deben ser iguales");

            Matriz resultado = new Matriz(matriz1.Filas, matriz1.Columnas);

            for (int i = 0; i < matriz1.Filas; i++)
            {
                for (int j = 0; j < matriz1.Columnas; j++)
                {
                    resultado[i, j] = matriz1[i, j] + matriz2[i, j];
                }
            }

            return resultado;
        }

        public static Matriz Resta(Matriz matriz1, Matriz matriz2)
        {
            if (matriz1.Filas != matriz2.Filas || matriz1.Columnas != matriz2.Columnas)
                throw new ArgumentException("Las dimensiones de las matrices deben ser iguales");

            Matriz resultado = new Matriz(matriz1.Filas, matriz1.Columnas);

            for (int i = 0; i < matriz1.Filas; i++)
            {
                for (int j = 0; j < matriz1.Columnas; j++)
                {
                    resultado[i, j] = matriz1[i, j] - matriz2[i, j];
                }
            }

            return resultado;
        }

        public static Matriz Multiplica(Matriz matriz1, Matriz matriz2)
        {
            if (matriz1.Columnas != matriz2.Filas)
                throw new ArgumentException("El número de columnas de la primera matriz debe ser igual al número de filas de la segunda matriz");

            Matriz resultado = new Matriz(matriz1.Filas, matriz2.Columnas);

            for (int i = 0; i < resultado.Filas; i++)
            {
                for (int j = 0; j < resultado.Columnas; j++)
                {
                    for (int k = 0; k < matriz1.Columnas; k++)
                    {
                        resultado[i, j] += matriz1[i, k] * matriz2[k, j];
                    }
                }
            }

            return resultado;
        }

        public static Matriz Negacion(Matriz matriz)
        {
            Matriz resultado = new Matriz(matriz.Filas, matriz.Columnas);

            for (int i = 0; i < matriz.Filas; i++)
            {
                for (int j = 0; j < matriz.Columnas; j++)
                {
                    resultado[i, j] = -matriz.matriz[i, j];
                }
            }

            return resultado;
        }

        public static bool EsSimetrica(Matriz matriz)
        {
            if (matriz.Filas != matriz.Columnas)
                return false;  // Solo las matrices cuadradas pueden ser simétricas

            for (int i = 0; i < matriz.Filas; i++)
            {
                for (int j = 0; j < i; j++) // Solo necesitamos verificar la mitad de la matriz
                {
                    if (matriz.matriz[i, j] != matriz.matriz[j, i])
                        return false;
                }
            }

            return true;
        }

        public static bool EsAntisimetrica(Matriz matriz)
        {
            if (matriz.Filas != matriz.Columnas)
                return false;  // Solo las matrices cuadradas pueden ser antisimétricas

            for (int i = 0; i < matriz.Filas; i++)
            {
                for (int j = 0; j < i; j++) // Solo necesitamos verificar la mitad de la matriz
                {
                    if (matriz.matriz[i,j] != -matriz[j,i])
                        return false;
                }
            }

            return true;
        }

        public static Matriz DataGridViewAMatriz(DataGridView dataGridView)
        {
            int filas = dataGridView.RowCount;
            int columnas = dataGridView.ColumnCount;

            // Crea una nueva matriz con las mismas dimensiones que el DataGridView
            Matriz matriz = new Matriz(filas, columnas);

            // Recorre las filas y las columnas del DataGridView
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // Intenta convertir el valor de la celda en un número
                    if (double.TryParse(dataGridView.Rows[i].Cells[j].Value.ToString(), out double valor))
                    {
                        // Si la conversión tiene éxito, asigna el número a la matriz
                        matriz[i, j] = valor;
                    }
                    else
                    {
                        // Si la conversión falla, lanza una excepción o maneja el error de la forma que prefieras
                        throw new FormatException($"El valor en la fila {i + 1} y la columna {j + 1} no es un número válido.");
                    }
                }
            }

            // Devuelve la matriz
            return matriz;
        }

        public static Matriz Inversa(Matriz matriz)
        {
            if (matriz.Filas != matriz.Columnas)
                throw new ArgumentException("La matriz debe ser cuadrada");

            int n = matriz.Filas;
            Matriz copiaMatriz = matriz; // Suponiendo que tienes un constructor de copia
            Matriz inversa = MatrizIdentidad(n);

            for (int i = 0; i < n; i++)
            {
                double diagonal = copiaMatriz[i, i];
                for (int j = 0; j < n; j++)
                {
                    copiaMatriz[i, j] /= diagonal;
                    inversa[i, j] /= diagonal;
                }

                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        double ratio = copiaMatriz[j, i];
                        for (int k = 0; k < n; k++)
                        {
                            copiaMatriz[j, k] -= ratio * copiaMatriz[i, k];
                            inversa[j, k] -= ratio * inversa[i, k];
                        }
                    }
                }
            }

            return inversa;
        }

        public static Matriz MatrizIdentidad(int size)
        {
            Matriz matriz = new Matriz(size, size);
            for (int i = 0; i < size; i++)
            {
                matriz[i, i] = 1;
            }
            return matriz;
        }

    }
}
