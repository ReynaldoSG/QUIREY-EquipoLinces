using System;
namespace marcatel_api.Models
{
    public class GetDetalleTicketModel
    {
        public int Id { get; set; }
        public int IdTicket { get; set; }
        public string Codigo { get; set; }
        public string Articulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTicket { get; set; }
        public string Usuario { get; set; }
        public string Estatus { get; set; }
        public string Mensaje { get; set; }

    }

    public class GetDetalleTicketSearchModel
    {
        public int idTicket { get; set; }
    }

    public class InsertDetalleTicketModel
    {
        public int IdTicket { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Usuario { get; set; }
    }

    public class UpdateDetalleTicketModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Estatus { get; set; }
        public int Usuario { get; set; }
    }

    public class DeleteDetalleTicketModel
    {
        public int Id { get; set; }
    }

    public class AutorizarTicketModel
    {
        public int Id { get; set; }
        public string Estatus { get; set; }

    }
}