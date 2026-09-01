using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AuraBeauty
{
    public partial class FormUsuarios : Form
    {
        // Declaración de controles
        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private TextBox txtCorreo = null!;
        private TextBox txtContraseña = null!;
        private ComboBox cmbRol = null!;
        private Button btnGuardar = null!;

        public FormUsuarios()
        {
            ConstruirInterfaz();
            CargarRoles();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
        }

        private void ConstruirInterfaz()
        {
            // Configuración de la Ventana
            this.Text = "Aura Beauty - Registro de Usuarios";
            this.ClientSize = new Size(600, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(250, 246, 245);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Color textoOscuro = Color.FromArgb(45, 45, 45);
            Color acentoBoton = Color.FromArgb(190, 140, 150);
            Color fondoCajas = Color.White;

            // Tipografías
            Font fontTitulo = new Font("Times New Roman", 20F, FontStyle.Bold);
            Font fontEtiquetas = new Font("Times New Roman", 12F, FontStyle.Regular);
            Font fontEntradas = new Font("Times New Roman", 12F, FontStyle.Regular);
            Font fontBoton = new Font("Times New Roman", 12F, FontStyle.Bold);

            // Título
            Label lblTitulo = new Label
            {
                Text = "Nuevo Usuario",
                Font = fontTitulo,
                ForeColor = textoOscuro,
                AutoSize = true
            };
            this.Controls.Add(lblTitulo);
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.PreferredWidth) / 2, 30);

            // Coordenadas
            int xLabel = 70;
            int xInput = 210;
            int inputWidth = 310;
            int inputHeight = 28;
            int startY = 100;
            int gapY = 55;

            // Fila 1: Nombre
            Label lblNombre = new Label { Text = "Nombre:", Font = fontEtiquetas, ForeColor = textoOscuro, AutoSize = true, Location = new Point(xLabel, startY + 4) };
            txtNombre = new TextBox { Font = fontEntradas, BackColor = fondoCajas, ForeColor = textoOscuro, BorderStyle = BorderStyle.None, Location = new Point(xInput, startY), Size = new Size(inputWidth, inputHeight) };

            // Fila 2: Apellido
            Label lblApellido = new Label { Text = "Apellido:", Font = fontEtiquetas, ForeColor = textoOscuro, AutoSize = true, Location = new Point(xLabel, startY + gapY + 4) };
            txtApellido = new TextBox { Font = fontEntradas, BackColor = fondoCajas, ForeColor = textoOscuro, BorderStyle = BorderStyle.None, Location = new Point(xInput, startY + gapY), Size = new Size(inputWidth, inputHeight) };

            // Fila 3: Correo
            Label lblCorreo = new Label { Text = "Correo:", Font = fontEtiquetas, ForeColor = textoOscuro, AutoSize = true, Location = new Point(xLabel, startY + (gapY * 2) + 4) };
            txtCorreo = new TextBox { Font = fontEntradas, BackColor = fondoCajas, ForeColor = textoOscuro, BorderStyle = BorderStyle.None, Location = new Point(xInput, startY + (gapY * 2)), Size = new Size(inputWidth, inputHeight) };

            // Fila 4: Contraseña
            Label lblClave = new Label { Text = "Contraseña:", Font = fontEtiquetas, ForeColor = textoOscuro, AutoSize = true, Location = new Point(xLabel, startY + (gapY * 3) + 4) };
            txtContraseña = new TextBox { Font = fontEntradas, BackColor = fondoCajas, ForeColor = textoOscuro, BorderStyle = BorderStyle.None, UseSystemPasswordChar = true, Location = new Point(xInput, startY + (gapY * 3)), Size = new Size(inputWidth, inputHeight) };

            // Fila 5: Rol
            Label lblRol = new Label { Text = "Rol / Cargo:", Font = fontEtiquetas, ForeColor = textoOscuro, AutoSize = true, Location = new Point(xLabel, startY + (gapY * 4) + 4) };
            cmbRol = new ComboBox { Font = fontEntradas, BackColor = fondoCajas, ForeColor = textoOscuro, DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Location = new Point(xInput, startY + (gapY * 4)), Size = new Size(inputWidth, inputHeight) };

            // Botón Guardar
            btnGuardar = new Button
            {
                Text = "Registrar Usuario",
                Font = fontBoton,
                BackColor = acentoBoton,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(220, 45),
                Location = new Point((this.ClientSize.Width - 220) / 2, startY + (gapY * 5) + 15)
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;

            // Agregar controles
            this.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblApellido, txtApellido,
                lblCorreo, txtCorreo,
                lblClave, txtContraseña,
                lblRol, cmbRol,
                btnGuardar
            });

            this.AcceptButton = btnGuardar;
        }

        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add(new ItemRol { Id = 1, Nombre = "Administrador" });
            cmbRol.Items.Add(new ItemRol { Id = 2, Nombre = "Vendedor" });
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "Id";
            cmbRol.SelectedIndex = 1;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string clave = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor complete los campos obligatorios (Nombre, Correo y Contraseña).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRol.SelectedItem is not ItemRol rolSeleccionado)
            {
                MessageBox.Show("Seleccione un rol válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AuraBeautyDB;Integrated Security=True;TrustServerCertificate=True;";
                string query = "INSERT INTO Usuario (nombre, apellido, correo, contraseña, id_rol) VALUES (@nombre, @apellido, @correo, @clave, @id_rol)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", string.IsNullOrEmpty(apellido) ? DBNull.Value : apellido);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@id_rol", rolSeleccionado.Id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Usuario {nombre} registrado exitosamente como {rolSeleccionado.Nombre}.", "Aura Beauty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = 1;
            txtNombre.Focus();
        }

        private class ItemRol
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public override string ToString() => Nombre;
        }
    }
}