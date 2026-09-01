using System.Data.SqlClient;

namespace AuraBeauty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // 1. Capturamos lo que el usuario escribió (Trim limpia espacios accidentales)
            string correo = txtCorreo.Text.Trim();
            string clave = txtContraseña.Text.Trim();

            // 2. Creamos el objeto Usuario (los datos vacíos se van a llenar solos al conectarse a la base de datos)
            Usuario empleadoActual = new Usuario("", "", correo, clave, 0);

            // 3. Llamamos al método que busca en SQL Server
            bool accesoConcedido = empleadoActual.IniciarSesion(correo, clave);

            // 4. Verificamos el resultado
            if (accesoConcedido)
            {
                // Si la conexión fue exitosa, usamos las propiedades que tu clase recuperó de SQL
                MessageBox.Show("¡Bienvenido/a " + empleadoActual.Nombre + " " + empleadoActual.Apellido + "!");

                // (Aquí más adelante pondremos el código para abrir tu menú principal)
            }
            else
            {
                MessageBox.Show("Acceso denegado. Verifica tu correo o contraseña.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
