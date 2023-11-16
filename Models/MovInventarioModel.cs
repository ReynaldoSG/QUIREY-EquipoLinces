using System;
using System.Data.Common;
namespace marcatel_api.Models
{
    public class GetMovInventarioModels
    {
        public int Id{get; set;}

        public string IdTipoMov {get; set;}

        public string IdAlmacen {get; set;}

        public DateTime fechaMovimiento{get; set;}

        public string Estatus{ get; set;}

        public string Usuario {get; set;}

        public DateTime FechaActualiza {get; set;}
    }

    public class InsertMovimientoModels
    {

    }
}
