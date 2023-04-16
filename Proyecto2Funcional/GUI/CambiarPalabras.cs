using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenerarSopaLetras;


namespace GUI
{
    /**
     * Clase encargada de mostrar graficamente al usuario como cambiar una palabra 
     */
    public partial class CambiarPalabras : Form
    {
        public GenerarSopaLetras.Program sopaLetras; //Referencia a GenerarSopaLetras
        public CambiarPalabras(GenerarSopaLetras.Program sopaLet) //Se manda por parametro desde el form principal
        {
            InitializeComponent();
            sopaLetras = sopaLet; //Se valoriza
            rellanarListBox(sopaLetras.palabras); //Se rellena la list box
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //Vuelve al form principal
        }

        /**
         * Es el boton principal de "cambiar palabra" que se encarga de realizar las confirmaciones
         * es el texto recibido, y la palabra a cambiar, y se encarga de obtener los datos 
         * para llamar a la funcion encargada de realizar el cambio
         */
        private void button2_Click(object sender, EventArgs e)
        {

            if (revisarFormato(textBox1.Text.Trim())) //Si el formato esta bien, se continua
            {
                if (revisarCheckList()) //Si solo se tiene seleccionado un item de la checklist se continua
                {

                    string vieja = "";
                    foreach (string palabra in checkedListBox1.CheckedItems) //Obtiene la unica palabra de la checklist
                    {
                        vieja = palabra;
                    }
                    sopaLetras.CambiarPalabra(vieja, textBox1.Text.Trim()); //Llama a la funcion encargado de cambiar la palabra

                    checkedListBox1.Items.Clear();
                    rellanarListBox(sopaLetras.palabras);
                    MessageBox.Show("Palabra cambiada correctamente " + vieja + "-->" + textBox1.Text.Trim());
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Problema en la checklist");
                }
            }
            else
            {
                MessageBox.Show("Escritura erronea en la palabra nueva");
            }
        }

        //Funcion que se encarga de rellenar la listBox con todas las palabras de la lista de palabras
        private void rellanarListBox(List<string> palabras)
        {
            foreach (string s in palabras)
            {
                checkedListBox1.Items.Add(s);
            }
        }


        //Funcion que revisa si la palabra digitada por el usuario en el texto es en mayuscula, sin espacios y con una longitud minima
        private bool revisarFormato(string palabra)
        {
            Random letras = new Random();
            if (palabra.Length <= 2) //Longitud minima de 3 caracteres son requeridos
            {
                return false;
            }
            foreach (byte c in palabra) //Solo palabra en mayuscula y sin espacio
            {
                if (c > 90 || c < 65)
                {
                    return false;
                }
            }
            return true;
        }

        //Funcion que se encarga de revisar que en el checkList, solo se haya seleccionado una palabra a cambiar
        private bool revisarCheckList()
        {
            if (checkedListBox1.CheckedItems.Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}
