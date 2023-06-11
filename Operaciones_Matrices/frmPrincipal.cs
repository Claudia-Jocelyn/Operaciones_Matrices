using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operaciones_Matrices
{
    public partial class frmPrincipal : Form
    {
        private int col1 = 2, col2 = 2;
        private int fil1 = 2, fil2 = 2;
        public frmPrincipal()
        {
            InitializeComponent();
            init();

        }

        private void init() {

            LimpiarMatriz(dtGW1, dtGW2);

        }

        private void actualizartamaño(DataGridView gridView) {
            int size = 70;
            foreach (DataGridViewColumn col in gridView.Columns)
            {
                col.Width = size; // Cambia esto al valor que quiera
            }

            foreach (DataGridViewRow row in gridView.Rows) {
                row.Height = size;
            }
        }

        private void btnFila1_Click(object sender, EventArgs e)
        {
            AgregarFila(dtGW1);
        }

        private void btnColumna1_Click(object sender, EventArgs e)
        {
            AgregarColumna(dtGW1);
        }

        private void btnFIla2_Click(object sender, EventArgs e)
        {
            AgregarFila(dtGW2);
        }

        private void btnColumna2_Click(object sender, EventArgs e)
        {
            AgregarColumna(dtGW2);
        }

        public void AgregarColumna(DataGridView gridView)
        {
            gridView.ColumnCount += 1;
            actualizartamaño(gridView);

        }
        public void AgregarFila(DataGridView gridView)
        {
            gridView.RowCount += 1;
            actualizartamaño(gridView);
        }

        public void QuitarColumna(DataGridView gridView)
        {
            gridView.ColumnCount -= 1;
            actualizartamaño(gridView);

        }
        public void QuitarFila(DataGridView gridView)
        {
            gridView.RowCount -= 1;
            actualizartamaño(gridView);
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            try
            {
                if (EstaCompleto(dtGW1) & EstaCompleto(dtGW2))
                {
                    Matriz matriz1 = Matriz.DataGridViewAMatriz(dtGW1);
                    Matriz matriz2 = Matriz.DataGridViewAMatriz(dtGW2);

                    MatrizADataGridView(Matriz.Suma(matriz1, matriz2), dtGWResul);

                    actualizartamaño(dtGW1);
                    actualizartamaño(dtGW2);
                    actualizartamaño(dtGWResul);

                    tabControl1.SelectedTab = tabPage2;
                }
                else
                {
                    MessageBox.Show("Las matrices no pueden estar vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarMatriz(dtGW1, dtGW2);
        }

        private bool EstaCompleto(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        return false; // Retorna false tan pronto como encuentra una celda vacía
                    }
                }
            }

            return true; // Si no encuentra ninguna celda vacía, retorna true
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            try
            {
                if (EstaCompleto(dtGW1) & EstaCompleto(dtGW2))
                {
                    Matriz matriz1 = Matriz.DataGridViewAMatriz(dtGW1);
                    Matriz matriz2 = Matriz.DataGridViewAMatriz(dtGW2);

                    MatrizADataGridView(Matriz.Resta(matriz1, matriz2), dtGWResul);

                    actualizartamaño(dtGW1);
                    actualizartamaño(dtGW2);
                    actualizartamaño(dtGWResul);

                    tabControl1.SelectedTab = tabPage2;
                }
                else
                {
                    MessageBox.Show("Las matrices no pueden estar vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (EstaCompleto(dtGW1) & EstaCompleto(dtGW2))
                {
                    Matriz matriz1 = Matriz.DataGridViewAMatriz(dtGW1);
                    Matriz matriz2 = Matriz.DataGridViewAMatriz(dtGW2);

                    MatrizADataGridView(Matriz.Multiplica(matriz1, matriz2), dtGWResul);

                    actualizartamaño(dtGW1);
                    actualizartamaño(dtGW2);
                    actualizartamaño(dtGWResul);

                    tabControl1.SelectedTab = tabPage2;
                }
                else
                {
                    MessageBox.Show("Las matrices no pueden estar vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnFilaM1_Click(object sender, EventArgs e)
        {
            QuitarFila(dtGW1);
        }

        private void btnFilaM2_Click(object sender, EventArgs e)
        {
            QuitarFila(dtGW2);
        }

        private void btnColumnaM1_Click(object sender, EventArgs e)
        {
            QuitarColumna(dtGW1);
        }

        private void btnColumnaM2_Click(object sender, EventArgs e)
        {
            QuitarColumna(dtGW2);
        }

        private void btnSimetria1_Click(object sender, EventArgs e)
        {


            if (Matriz.EsSimetrica(Matriz.DataGridViewAMatriz(dtGW1)))
            {
                MessageBox.Show("La matriz es simétrica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (Matriz.EsAntisimetrica(Matriz.DataGridViewAMatriz(dtGW1)))
            {
                MessageBox.Show("La matriz es asimétrica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("La matriz no es simetrica ni asimetrica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSimetria2_Click(object sender, EventArgs e)
        {
            if (Matriz.EsSimetrica(Matriz.DataGridViewAMatriz(dtGW2)))
            {
                MessageBox.Show("La matriz es simétrica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (Matriz.EsAntisimetrica(Matriz.DataGridViewAMatriz(dtGW2)))
            {
                MessageBox.Show("La matriz es asimétrica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("La matriz no es simetrica ni asimetrica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnInver1_Click(object sender, EventArgs e)
        {
            try
            {
                MatrizADataGridView(Matriz.Inversa(Matriz.DataGridViewAMatriz(dtGW1)), dtGW1);
                actualizartamaño(dtGW1);
                actualizartamaño(dtGW2);
                actualizartamaño(dtGWResul);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInver2_Click(object sender, EventArgs e)
        {
            try
            {
                MatrizADataGridView(Matriz.Inversa(Matriz.DataGridViewAMatriz(dtGW2)), dtGW2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MatrizADataGridView(Matriz matriz, DataGridView dataGridView)
        {
            // Limpia el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Añade las columnas
            for (int i = 0; i < matriz.Columnas; i++)
            {
                dataGridView.Columns.Add($"Columna{i}", "");
            }

            // Añade las filas
            for (int i = 0; i < matriz.Filas; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);

                for (int j = 0; j < matriz.Columnas; j++)
                {
                    row.Cells[j].Value = matriz[i, j];
                }

                dataGridView.Rows.Add(row);
            }
        }

        private void LimpiarMatriz(DataGridView dt1, DataGridView dt2) {

            dt1.Rows.Clear();
            dt2.Rows.Clear();

            dt1.Columns.Clear();
            dt2.Columns.Clear();

            dtGW1.ColumnCount = col1;
            dtGW2.ColumnCount = col2;
            dtGW1.RowCount = fil1;
            dtGW2.RowCount = fil2;

            actualizartamaño(dtGW1);
            actualizartamaño(dtGW2);
            actualizartamaño(dtGWResul);
        }

    }
}
