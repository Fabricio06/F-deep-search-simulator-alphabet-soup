using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FSharp.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GenerarSopaLetras; //La referencia a "Sopa de letras"
using System.Reflection;
using BusquedaProfu;

namespace GUI
{
    public partial class Juego : Form
    {
        public GenerarSopaLetras.Program sopaLetras;
        public char[,] matriz;
        private FSharpList<FSharpList<Tuple<int, int>>> direcciones;
        public Juego(GenerarSopaLetras.Program sopaLetr)
        {
            InitializeComponent();
            sopaLetras = sopaLetr; //La instancia de el generador de matriz

            //Se crean las dimenciones de la palabra mas grande
            dataGridView1.RowCount = sopaLetras.palabraMasLarga();
            dataGridView1.ColumnCount = dataGridView1.RowCount;

            this.matriz = sopaLetras.GenerateSopaDeLetras(); //Obtiene la matriz generada

            dataGridView1.ColumnHeadersVisible = true; //Para que se vean las columnas

            //Agrega la matriz al grid grafico
            inicializarPalabras();

            //Rellena las palabras a buscar
            rellanarcheckedListBox1(sopaLetras.palabras);

            obtenerDirecciones();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Juego_Load(object sender, EventArgs e)
        {

        }

        private void rellanarcheckedListBox1(List<string> palabras)
        {
            checkedListBox1.Items.Clear();
            foreach (string s in palabras)
            {
                checkedListBox1.Items.Add(s);
            }
        }

        public void inicializarPalabras()
        {
            //dataGridView1.
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1[i, j].Value = matriz[j, i];
                }
            }
        }
        public void obtenerMatriz()
        {
            //var matriz = dataGridView1.
        }
        private void juegoTerminado()
        {
            if (checkedListBox1.CheckedItems.Count == sopaLetras.palabras.Count)
            {
                MessageBox.Show("Felicidades ganaste");
                dataGridView1.Enabled = false;
            }
        }
        private void validar() 
        {
            var direcciones = this.direcciones;
            var flag = true;
            var indice = 0;
            foreach (FSharpList<Tuple<int, int>> dir in direcciones)
            {
                flag = true;
                foreach (Tuple<int, int> cor in dir)
                {
                    if(!(dataGridView1[cor.Item2, cor.Item1].Style.BackColor == Color.Brown))
                    {
                        flag = false; break;
                    }
                }
                if (flag)
                {
                    checkedListBox1.SetItemChecked(indice,true);
                }
                indice++;
                
            }
        }

        private void Color_click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Style.BackColor = Color.Brown;
            validar();
            juegoTerminado();
        }

        private void RegresarColor_Doclick(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Style.BackColor = Color.White;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkedListBox1.SetItemChecked(0, true);
        }

        private FSharpList<FSharpList<Tuple<int, int>>> obtenerDirecciones()
        {
            if (direcciones == null) // Solo se genera la lista si no ha sido creada antes
            {
                List<List<char>> sop = sopaLetras.ConvertirACharListList(sopaLetras.palabras);
                var palabra = sopaLetras.palabras.ToList();
                var charListList = palabra.Select(s => ListModule.OfSeq(s.ToCharArray())).ToList();
                var fsharpList = ListModule.OfSeq(charListList);
                direcciones = parteFShart.prof(fsharpList, matriz);
            }
            return direcciones;
        }

        private void pintarResultados(FSharpList<FSharpList<Tuple<int, int>>> direcciones)
        {
            foreach (FSharpList<Tuple<int, int>> dir in direcciones)
            {
                foreach (Tuple<int, int> cor in dir)
                {
                    dataGridView1[cor.Item2, cor.Item1].Style.BackColor = Color.Brown;
                }
            }
            for (int i = 0; i<checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i,true); //REVISAR
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var direcciones = obtenerDirecciones();
            pintarResultados(direcciones);
            juegoTerminado();
        }
    }
}
