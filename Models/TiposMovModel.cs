using System;
namespace marcatel_api.Models
{
    public class GetTiposMovModel
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public string Tipo {get; set;}
    public string Usuario{get;set;}
    public DateTime Fecha {get;set;}

}

public class InsertTiposMovModel
{
    public string Nombre {get; set;}
    public string Tipo {get; set;}
    public string Usuario{get;set;}
}

public class UpdateTiposMovModel
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public string Tipo {get; set;}
    public string Usuario{get;set;}
}

public class DeleteTiposMovModel
{
    public int Id {get; set;}
}

}
