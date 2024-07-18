using System;
namespace marcatel_api.Models
{
    public class GetCatModuloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualiza { get; set; }
        public string Usuario { get; set; }
        public string Mensaje { get; set; }

    }

    public class InsertCatModuloModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
    }

    public class UpdateCatModuloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaActualiza { get; set; }
        public string Usuario { get; set; }
    }

    public class DeleteCatModuloModel
    {
        public int Id { get; set; }
    }

}
