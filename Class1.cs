using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace AuraBeauty
{
    public class Conexion
    {
        // Ajustá 'Database=BaseDeDatos' si le pusiste otro nombre a la base
        private static readonly string Cadena =
            @"Server=(localdb)\MSSQLLocalDB;Database=BaseDeDatos;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(Cadena);
        }
    }
    internal class Class1
    {
    }
}
