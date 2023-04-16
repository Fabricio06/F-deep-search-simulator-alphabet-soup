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
        public GenerarSopaLetras.Program sopaLetras; //Se guarda la instancia a GenerarSopaLetras
        public char[,] matriz; //Se guarda la matriz de manera global
        private FSharpList<FSharpList<Tuple<int, int>>> direcciones; //Se guardan las direcciones de manera global
        public Juego(GenerarSopaLetras.Program sopaLetr)
        {
            InitializeComponent();
            sopaLetras = sopaLetr; //La instancia de el generador de matriz

            //Se crean las dimenciones de la palabra mas grande
            dataGridView1.RowCount = sopaLetras.palabraMasLarga();
            dataGridView1.ColumnCount = dataGridView1.RowCount;

            this.matriz = sopaLetras.GenerateSopaDeLetras(); //Obtiene la matriz generada y le da el valor a la variablo global

            dataGridView1.ColumnHeadersVisible = true; //Para que se vean las columnas

            //Agrega la matriz al grid grafico
            inicializarPalabras();

            //Rellena las palabras a buscar
            rellanarcheckedListBox1(sopaLetras.palabras);

            obtenerDirecciones(); //Genera las direcciones y lo agrega a la variable global

        }

        //Boton para volver al principal
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Juego_Load(object sender, EventArgs e)
        {


        }

        //Funcion que se encarga de rellenar la checkListBox
        private void rellanarcheckedListBox1(List<string> palabras)
        {
            checkedListBox1.Items.Clear(); //La limpia para mantenerla actualizada siempre
            foreach (string s in palabras) //Recorre la lista de palabras
            {
                checkedListBox1.Items.Add(s); //Agrega la palabra
            }
        }

        //Funcion que se encarga de inicializar las palabras en la matriz visual - datagridview
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

        //Funcion que revisa si el juego ya termino y no
        private void juegoTerminado()
        {
            if (checkedListBox1.CheckedItems.Count == sopaLetras.palabras.Count) //Si las palabras encontradas es igual a la cantidad de palabras que hay
            {
                MessageBox.Show("Felicidades ganaste");
                dataGridView1.Enabled = false; //Se desactiva el dataGridView
            }
        }

        //Funcion que se encarga de estar validando cada vez que se pinta una coordenada para ver si ya se completo una palabra
        private void validar() 
        {
            var flag = true; //Bandera para llevar un mejor control
            var indice = 0; //Indice de la palabra que estamos revisando
            foreach (FSharpList<Tuple<int, int>> dir in direcciones) //Se recorre cada lista de coordenadas
            {
                flag = true;
                foreach (Tuple<int, int> cor in dir)  //Se revisan las coordenadas de la palabra en especifico
                {
                    if(!(dataGridView1[cor.Item2, cor.Item1].Style.BackColor == Color.Brown)) //Se revisa que esten todas pintadadas de cafe
                    {
                        flag = false; break; //Sino se coloca falso y se sale
                    }
                }
                if (flag) //Si, si cumple se coloca como completada esa palabra
                {
                    checkedListBox1.SetItemChecked(indice,true); //Se pone el check a la palabra actual
                }
                indice++;
                
            }
        }

        //Funcion que se encarga de ejecutar un evento al clicar la matriz, en este caso para pintar
        private void Color_click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Style.BackColor = Color.Brown; //Pinta la ubicacion que se clico, de cafe
            validar(); //Se valida para ver si ya completa una palabra
            juegoTerminado(); //Se valida si ya termino el juego
        }

        //Funcion que se encarga de ejecutar un evento al realizar doble click a la matriz, en este caso para despintar
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

        //Funcion que se encarga de llamar al subproyecto de f# para obtener las direcciones de las palabras
        private FSharpList<FSharpList<Tuple<int, int>>> obtenerDirecciones()
        {
            if (direcciones == null) // Solo se genera la lista si no ha sido creada antes
            {
                var charListList = sopaLetras.palabras.Select(s => ListModule.OfSeq(s.ToCharArray())).ToList(); //Convierte el List<string> de c# a un List<FsharpList<char>> de f#
                var fsharpList = ListModule.OfSeq(charListList);//Convierte el  List<FsharpList<char>> de c# a un FsharpList<FsharpList<char>> de f#
                direcciones = parteFShart.prof(fsharpList, matriz); //Llama a la funcion principal de f# que hace el recorrido en profundidad y devuelve las ubicaciones
            }
            return direcciones;
        }

        //Funcion que se encarga de pintar todas las ubicaciones enviadas
        private void pintarResultados(FSharpList<FSharpList<Tuple<int, int>>> direcciones)
        {
            foreach (FSharpList<Tuple<int, int>> dir in direcciones) //Obtiene cada ubicacion
            {
                foreach (Tuple<int, int> cor in dir)//Obtiene cada coordenada
                {
                    dataGridView1[cor.Item2, cor.Item1].Style.BackColor = Color.Brown; //Lo pinta
                }
            }
            for (int i = 0; i<checkedListBox1.Items.Count; i++) //Coloca en la Listbox las palabras con un check
            {
                checkedListBox1.SetItemChecked(i,true);
            }
            
        }

        //Boton si se hace click a "mostrar resultados" para pintar todas las palabras de manera automatica
        private void button2_Click(object sender, EventArgs e)
        {
            var direcciones = obtenerDirecciones();
            pintarResultados(direcciones);
            juegoTerminado();
        }
    }
}
