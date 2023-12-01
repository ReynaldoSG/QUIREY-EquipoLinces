using System;
namespace marcatel_api.Models
{
    public class GetUsuariosModel
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Contrasena {get; set;}
        public string Rol {get; set;}
        public string Usuario {get; set;}
        public DateTime FechaAct {get; set;}
        public DateTime FechaReg {get; set;}
    }
    public class InsertUsuariosModel
    {
        public string Nombre {get; set;}
        public string Contrasena {get; set;}
        public int Rol {get; set;}
        public int Usuario {get; set;}
    } 
    public class UpdateUsuariosModel
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Contrasena {get; set;}
        public int Rol {get; set;}
        public int Usuario {get; set;}
    }
    public class DeleteUsuariosModel
    {
        public int Id {get; set;}
    }
}
