namespace GUI;
using GenerarSopaLetras; //La referencia a "Sopa de letras"

public partial class Principal : Form
{
    public GenerarSopaLetras.Program sopaLetras; //La instancia de la relacion con GenerarSopaLetras
    public Principal(GenerarSopaLetras.Program sopaLet)
    {
        InitializeComponent();
        sopaLetras = sopaLet; //El valor general de la instancia a la relacion
        sopaLetras.cargarPalabras(); //Se cargan los datos
        rellanarListBox(sopaLetras.palabras); //Se rellena la listbox para mostrar las palabras
        textBox1.Visible = false;

    }

    //Llama al form encargado del juego
    private void button1_Click(object sender, EventArgs e)
    {
        this.Visible = false;

        Juego llamarN1 = new Juego(this.sopaLetras);
        llamarN1.ShowDialog();

        this.Visible = true;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void Principal_Load(object sender, EventArgs e)
    {

    }

    //Se encargar de refrescar y rellenar con la lista de palabras la listBox
    private void rellanarListBox(List<string> palabras)
    {
        listBox1.Items.Clear();
        foreach (string s in palabras)
        {
            listBox1.Items.Add(s);
        }
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    //Llama al form encargado de cambiar la palabra
    private void button2_Click(object sender, EventArgs e)
    {
        this.Visible = false;

        CambiarPalabras llamarN2 = new CambiarPalabras(sopaLetras);
        llamarN2.ShowDialog();

        rellanarListBox(sopaLetras.palabras);
        this.Visible = true;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    //Boton que muestra las instrucciones del programa
    private void button3_Click(object sender, EventArgs e)
    {
        textBox1.Visible = true;
        button3.Visible = false;

    }
}