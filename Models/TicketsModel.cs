using System;
namespace marcatel_api.Models
{
    public class GetTicketsModel
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Cliente { get; set; }
        public string Vendedor { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estatus { get; set; }
        public string Mensaje { get; set; }

    }

    public class GetTicketsFiltroModel
    {
        public string IdSucursal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class InsertTicketsModel
    {
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public int Usuario { get; set; }

    }

    public class UpdateTicketsModel
    {
        public int Id { get; set; }
        public int Estatus { get; set; }
    }

    public class DeleteTicketsModel
    {
        public int Id { get; set; }
    }
}