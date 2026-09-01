using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

namespace AuraBeauty
{
    public class Conexion
    {
        // Ajustá 'Database=AuraBeautyDB' si le pusiste otro nombre a la base
        private static readonly string Cadena =
            @"Server=(localdb)\MSSQLLocalDB;Database=AuraBeautyDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(Cadena);
        }
    }
}
