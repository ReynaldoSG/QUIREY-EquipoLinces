using System;
namespace marcatel_api.Models
{
    public class GetExistenciasModel
{
    public int Id {get; set;}
    public string Codigo {get; set;}
    public string Almacen {get; set;}
    public int Cantidad {get; set;}
    public string Usuario {get; set;}
    public DateTime FechaRegistro {get;set;}
    public DateTime FechaActualiza {get;set;}

    public string Mensaje {get; set;}

}

public class GetExistenciasFiltroModel
{
    public string Almacen {get; set;}
}

public class InsertExistenciasModel
{
    public string Codigo {get; set;}
    public string Almacen {get; set;}
    public int Cantidad {get; set;}
    public string Usuario {get; set;}
}

public class UpdateExistenciasModel
{
    public int Id {get; set;}
    public string Codigo {get; set;}
    public string Almacen {get; set;}
    public int Cantidad {get; set;}
    public string Usuario {get; set;}
}

public class DeleteExistenciasModel
{
    public int Id {get; set;}
}

}
