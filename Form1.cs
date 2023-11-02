using com.calitha.goldparser;

namespace CodeAnalizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Instancia un objeto de la clase MyPArser y le envia la ruta del archivo de tablas
            MyParser analizador = new MyParser(Application.StartupPath + "\\GramaticaFinal.cgt");

            analizador.Parse(richTextBox1.Text);

            richTextBox2.Text = analizador.getCadena();
        }
    }
}