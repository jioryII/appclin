using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEspecialista
    {
        public int EspecialistaCMP { get; set; }
        public string EspecialistaNombre { get; set; }
        public string EspecialistaApellido { get; set; }
        public int EspecialidadCodigo { get; set; }

        public DEspecialista() { }

        public DEspecialista(int cmp, string nombre, string apellido, int especialidadCodigo)
        {
            EspecialistaCMP = cmp;
            EspecialistaNombre = nombre;
            EspecialistaApellido = apellido;
            EspecialidadCodigo = especialidadCodigo;
        }

        public string Insertar(DEspecialista especialista)
        {
            string respuesta = "";

            using (SqlConnection connection = new SqlConnection(Conexion.Cn))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("usp_InsertarEspecialista", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EspecialistaCMP", especialista.EspecialistaCMP);
                    command.Parameters.AddWithValue("@EspecialistaNombre", especialista.EspecialistaNombre);
                    command.Parameters.AddWithValue("@EspecialistaApellido", especialista.EspecialistaApellido);
                    command.Parameters.AddWithValue("@EspecialidadCodigo", especialista.EspecialidadCodigo);

                    int filasAfectadas = command.ExecuteNonQuery();
                    respuesta = filasAfectadas == 1 ? "OK" : "Error al insertar el especialista";
                }
                catch (Exception ex)
                {
                    respuesta = ex.Message;
                }
            }

            return respuesta;
        }

        // Puedes implementar métodos para Actualizar, Eliminar, Listar, etc., de manera similar.
    }
}
