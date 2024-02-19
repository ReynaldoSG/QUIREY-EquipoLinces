using System;
namespace marcatel_api.Models
{
    public class GetEstadosModel
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }
    }

    public class InsertEstadosModel
    {
        public string NombreEstado { get; set; }
    }

    public class UpdateEstadosModel
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }
    }

}