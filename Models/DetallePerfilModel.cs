using System;
namespace marcatel_api.Models
{
    public class GetDetallePerfilModel
    {
        public int Id { get; set; }
        public string nombreModulo { get; set; }
        public string Rol { get; set; }
        public string Acceso { get; set; }
        public DateTime fechaRegistro {get;set;}
        public DateTime fechaActualiza {get;set;}
        public string Estatus {get;set;}
        public string UsuarioActualiza {get;set;}

        public string Mensaje {get; set;}
    }

    public class GetDetallePerfilSearchModel
    {
        public int Id { get; set; }
    }

    public class InsertDetallePerfilModel
    {
        public int idPerfil { get; set; }
        public int idModulo { get; set; }
        public int acceso { get; set; }
        public int UsuarioActualiza{get;set;}
    }

    public class UpdateDetallePerfilModel
    {
        public int id { get; set; }
        public int idPerfil { get; set; }
        public int idModulo { get; set; }
        public int acceso { get; set; }
        public int UsuarioActualiza{get;set;}
        public int estatus { get; set; }
    }

    public class DeleteDetallePerfilModel
    {
        public int Id { get; set; }
    }
}