using System;
namespace marcatel_api.Models
{
  public class GetEmpleadosModel
  {
    public int Id{get; set;}
    public string Persona {get; set;}
    public string Sucursal {get; set;}
    public string Puesto {get; set;}

     public string usuarioActualiza{get; set;}
    public DateTime fechaRegistro {get; set;}
    public DateTime fechaActualiza{get; set;}

    public string Mensaje {get; set;}
   
  }

  public class InsertEmpleadosModel
  {
    public int IdPersona {get; set;}
    public int IdSucursal{get; set;}
    public int IdPuesto{get; set;}

    public int usuarioActualiza {get; set;}
  }

  public class UpdateEmpleadosModel
  {
    public int Id{get; set;}
    public int IdPersona{get; set;}
    public int IdSucursal{get; set;}
    public int IdPuesto{get; set;}

    public int usuarioActualiza{get; set;}

  }
  public class DeleteEmpleadosModel
  {
    public int Id{get; set;}
  }

}