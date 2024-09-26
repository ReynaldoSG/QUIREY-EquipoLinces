using System;
namespace marcatel_api.Models
{
    public class GetClientesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualiza { get; set; }
        public string Telefono { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public string Coordenadas { get; set; }

        public string Mensaje {get; set;}
    }

    public class InsertClientesModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Telefono { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public string Coordenadas { get; set; }
    }

    public class UpdateClientesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Telefono { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public string Coordenadas { get; set; }
    }

    public class DeleteClientesModel
    {
        public int Id { get; set; }
    }

}
