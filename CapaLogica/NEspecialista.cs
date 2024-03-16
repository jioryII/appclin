using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaLogica
{
    public class NEspecialista
    {
        public static string Insertar(int cmp, string nombre, string apellido, int especialidadCodigo)
        {
            DEspecialista especialista = new DEspecialista(cmp, nombre, apellido, especialidadCodigo);
            return especialista.Insertar(especialista);
        }

        public static string Actualizar(int cmp, string nombre, string apellido, string direccion, int telefono, int especialidadCodigo)
        {
            DEspecialista especialista = new DEspecialista(cmp, nombre, apellido, direccion, telefono, especialidadCodigo);
            return especialista.Actualizar(especialista);
        }

        public static string Eliminar(int cmp)
        {
            DEspecialista especialista = new DEspecialista();
            especialista.CMP = cmp;
            return especialista.Eliminar(especialista);
        }

        public static DataTable ListarEspecialistas()
        {
            return new DEspecialista().ListarEspecialistas();
        }

        public static DataTable BuscarEspecialistaPorNombre(string nombre)
        {
            DEspecialista especialista = new DEspecialista();
            return especialista.BuscarEspecialistaPorNombre(nombre);
        }
    }
}
