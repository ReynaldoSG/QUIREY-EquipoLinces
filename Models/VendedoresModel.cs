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
    public class InsertVendedoresModel
    {
        public string NombreVendedor{get;set;}
        public int IdSucursal{get;set;}
        public int Usuario{get;set;}
    }
    public class UpdateVendedoresModel
    {
        public int Id{get;set;}
        public string NombreVendedor{get;set;}
        public int IdSucursal{get;set;}
        public int Usuario{get;set;}
    }
    public class DeleteVendedoresModel
{
    public int Id {get; set;}
}
}