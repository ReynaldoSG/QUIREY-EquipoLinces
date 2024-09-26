using System;
using System.Data.Common;
namespace marcatel_api.Models
{
    public class GetMovInventarioModels
    {
        public int Id { get; set; }

        public string IdTipoMov { get; set; }

        public string IdAlmacen { get; set; }

        public DateTime fechaMovimiento { get; set; }

        public string Estatus { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaActualiza { get; set; }

        public string Mensaje {get; set;}
    }


        public class GetMovInvFiltroModel
    {
        public string IdAlmacen { get; set; }
        public DateTime FechaInicio {get;set;}
        public DateTime FechaFin {get;set;}
    }


    public class InsertMovimientoModels
    {
        public int IdTipoMov { get; set; }

        public int IdAlmacen { get; set; }

        public int UsuarioActualiza { get; set; }
        public int IdDestino { get; set; }

    }

    public class UpdateMovimientoInvModel
    {
        public int Id { get; set; }

        public int IdTipoMov { get; set; }

        public int IdAlmacen { get; set; }

        public int UsuarioActualiza { get; set; }
    }

    public class DeleteMovimientoInvModel
    {
        public int Id { get; set; }
    }
}
