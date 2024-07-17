namespace marcatel_api.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string NombrePersona { get; set; }
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public int IdPerfil { get; set; }
        public decimal PctDescuento {get; set;}
        public string Rol { get; set; }
        public int IdRol {get;set;}

    }
}

