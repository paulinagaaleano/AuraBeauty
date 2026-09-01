using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuraBeauty
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AplicarEstiloEstetico();

            // Configurar tecla Enter para ejecutar el botón Ingresar
            this.AcceptButton = btnIngresar;
        }

        private void AplicarEstiloEstetico()
        {
            // 1. Tamaño del formulario
            this.BackColor = Color.FromArgb(250, 246, 245);
            this.ClientSize = new Size(700, 550);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            Color textoOscuro = Color.FromArgb(45, 45, 45);
            Color acentoBoton = Color.FromArgb(190, 140, 150);

            // Tipografías Times New Roman
            Font fontTitulo = new Font("Times New Roman", 26F, FontStyle.Bold);
            Font fontLabel = new Font("Times New Roman", 13F, FontStyle.Regular);
            Font fontBox = new Font("Times New Roman", 13F, FontStyle.Regular);
            Font fontBoton = new Font("Times New Roman", 13F, FontStyle.Bold);

            // 2. Centrar Título
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl && (lbl.Text.Contains("Aura") || lbl.Text.Contains("Beauty")))
                {
                    lbl.Font = fontTitulo;
                    lbl.ForeColor = textoOscuro;
                    lbl.BackColor = Color.Transparent;
                    lbl.AutoSize = true;
                    lbl.Location = new Point((this.ClientSize.Width - lbl.PreferredWidth) / 2, 60);
                }
            }

            // 3. Posiciones con margen dinámico (evita solapamiento)
            int xEtiquetas = 110;  // Margen izquierdo para los textos
            int xCajas = 350;       // Inicio de las cajas con separación suficiente
            int anchoCaja = 280;

            // Fila 1: Correo Electrónico
            int yFila1 = 180;
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl && lbl.Text.Contains("Correo"))
                {
                    lbl.Font = fontLabel;
                    lbl.ForeColor = textoOscuro;
                    lbl.BackColor = Color.Transparent;
                    lbl.AutoSize = true;
                    lbl.Location = new Point(xEtiquetas, yFila1 + 4);
                }
            }

            if (this.Controls.ContainsKey("txtCorreo"))
            {
                txtCorreo.Font = fontBox;
                txtCorreo.BackColor = Color.White;
                txtCorreo.ForeColor = textoOscuro;
                txtCorreo.BorderStyle = BorderStyle.None;
                txtCorreo.Location = new Point(xCajas, yFila1);
                txtCorreo.Size = new Size(anchoCaja, 28);
            }

            // Fila 2: Contraseña
            int yFila2 = 250;
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl && lbl.Text.Contains("Contra"))
                {
                    lbl.Font = fontLabel;
                    lbl.ForeColor = textoOscuro;
                    lbl.BackColor = Color.Transparent;
                    lbl.AutoSize = true;
                    lbl.Location = new Point(xEtiquetas, yFila2 + 4);
                }
            }

            if (this.Controls.ContainsKey("txtContraseña"))
            {
                txtContraseña.Font = fontBox;
                txtContraseña.BackColor = Color.White;
                txtContraseña.ForeColor = textoOscuro;
                txtContraseña.BorderStyle = BorderStyle.None;
                txtContraseña.UseSystemPasswordChar = true;
                txtContraseña.Location = new Point(xCajas, yFila2);
                txtContraseña.Size = new Size(anchoCaja, 28);
            }

            // 4. Botón Ingresar centrado
            if (this.Controls.ContainsKey("btnIngresar"))
            {
                btnIngresar.Font = fontBoton;
                btnIngresar.BackColor = acentoBoton;
                btnIngresar.ForeColor = Color.White;
                btnIngresar.FlatStyle = FlatStyle.Flat;
                btnIngresar.FlatAppearance.BorderSize = 0;
                btnIngresar.Cursor = Cursors.Hand;
                btnIngresar.Size = new Size(220, 48);
                btnIngresar.Location = new Point((this.ClientSize.Width - 220) / 2, 360);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string clave = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor complete su correo y contraseña.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario empleadoActual = new Usuario("", "", correo, clave, 0);
            bool accesoConcedido = empleadoActual.IniciarSesion(correo, clave);

            if (accesoConcedido)
            {
                MessageBox.Show($"¡Bienvenido/a {empleadoActual.Nombre} {empleadoActual.Apellido}!", "Aura Beauty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Próximo paso: abrir FormMenuPrincipal y ocultar este formulario
            }
            else
            {
                MessageBox.Show("Acceso denegado. Verificá tu correo o contraseña.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }

            if (accesoConcedido)
            {
                this.Hide();
                MenuPrincipal menu = new MenuPrincipal(empleadoActual);
                menu.Show();
            }
        }

        

        // Métodos de eventos vacíos requeridos por el diseñador
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void txtCorreo_TextChanged(object sender, EventArgs e) { }
    }
}