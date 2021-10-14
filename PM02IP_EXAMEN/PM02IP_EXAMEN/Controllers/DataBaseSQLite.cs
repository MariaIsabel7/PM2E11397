using PM02IP_EXAMEN.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM02IP_EXAMEN.Controllers
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        // Constructor de la clase DataBaseSQLite

        public DataBaseSQLite(String pathdb)
        {

            // Crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            // Creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Localizacion>().Wait();
        }

        // Operaciones CRUD con SQLite
        // READ List Way

        public Task<List<Localizacion>> ObtenerListaUbicaciones()
        {
            return db.Table<Localizacion>().ToListAsync();
        }

        //READ one by one
        public Task<Localizacion> ObtenerUbicacion(int pcodigo)
        {
            return db.Table<Localizacion>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }


        // CREATE persona
        public Task<int> GuardarUbicacion(Localizacion ubicacion)
        {
            if (ubicacion.codigo != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }

        //DELETE

        public Task<int> EliminarUbicacion(Localizacion ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }
    }
}
