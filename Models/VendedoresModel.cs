using System;
namespace marcatel_api.Models
{
    public class GetVendedoresModel
    {
        public int Id {get;set;}
        public string NombreVendedor {get;set;}
        public string Sucursal {get;set;}
        public string Estatus {get;set;}
        public string UsuarioActualiza {get;set;}
        public DateTime FechaRegistro{get;set;}
        public DateTime FechaActualiza{get;set;}
    }
}