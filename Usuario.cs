using System;
using System.Data.SqlClient;

namespace AuraBeauty
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }

        public int IdRol { get; set; } // Propiedad para almacenar el ID del rol

        public Usuario(string nombre, string apellido, string correoElectronico, string contraseña, int idRo)
        {
            Nombre = nombre;
            Apellido = apellido;
            CorreoElectronico = correoElectronico;
            Contraseña = contraseña;
            IdRol = idRo;
        }

        [Obsolete]
        public bool IniciarSesion(string correo, string contrasena)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BaseDeDatos;Integrated Security=True;";
            string query = "SELECT nombre, apellido, id_rol FROM Usuario WHERE correo = @correo AND contraseña = @contrasena";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@contrasena", contrasena);
                connection.Open();

                SqlDataReader lector = command.ExecuteReader();

                if (lector.Read())
                {
                    this.Nombre = lector["nombre"].ToString();
                    this.Apellido = lector["apellido"].ToString();
                    this.IdRol = Convert.ToInt32(lector["id_rol"]);
                    return true; // Credenciales válidas
                }
                else
                {
                    return false; // Credenciales inválidas
                }
            }
        }
    } 
} 