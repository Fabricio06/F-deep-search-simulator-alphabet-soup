namespace GUI;

public partial class Principal : Form
{
    public Principal()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Juego llamarN1 = new Juego();
        llamarN1.Visible = true;
        this.Hide();
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
}