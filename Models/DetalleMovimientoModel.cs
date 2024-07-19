using System;
namespace marcatel_api.Models
{
    public class GetDetalleMovimientoModel
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public DateTime FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Estatus { get; set; }
        public string Mensaje { get; set; }

    }

    public class GetDetalleMovimientoSearchModel
    {
        public int Id { get; set; }
    }

    public class InsertDetalleMovimientoModel
    {
        public int IdMovimiento { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateDetalleMovimientoModel
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class DeleteDetalleMovimientoModel
    {
        public int Id { get; set; }
    }
}