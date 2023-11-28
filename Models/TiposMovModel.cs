using System;
namespace marcatel_api.Models
{
    public class GetTiposMovModel
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public int Tipo {get; set;}
    public string Usuario{get;set;}
    public DateTime FechaAct {get;set;}
    public DateTime FechaReg {get;set;}

}

public class InsertTiposMovModel
{
    public string Nombre {get; set;}
    public int Tipo {get; set;}
    public int Usuario{get;set;}
}

public class UpdateTiposMovModel
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public int Tipo {get; set;}
    public int Usuario{get;set;}
}

public class DeleteTiposMovModel
{
    public int Id {get; set;}
}

}
