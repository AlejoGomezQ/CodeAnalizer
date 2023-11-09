using com.calitha.goldparser;

namespace CodeAnalizer
{
    public partial class Form1 : Form
    {
        MyParser analizador;

        public Form1()
        {
            //Instancia un objeto de la clase MyPArser y le envia la ruta del archivo de tablas
            analizador = new MyParser(Application.StartupPath + "\\GramaticaFinal.cgt");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = " ";

            analizador.Parse(richTextBox1.Text);

            richTextBox2.Text = analizador.getCadena();
        }
    }
}