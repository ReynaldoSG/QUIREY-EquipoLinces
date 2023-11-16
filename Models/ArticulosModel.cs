using System;
namespace marcatel_api.Models
{
    public class GetArticulosModel
{
    public int Id {get; set;}
    public string Codigo {get; set;}
    public string Descripcion {get; set;}
    public int UM {get; set;}
    public string Costo{get;set;}
    public string Precio{get;set;}
    public string Usuario{get;set;}
    public DateTime Fecha {get;set;}

}

public class InsertArticulosModel
{
    public string Codigo {get; set;}
    public string Descripcion {get; set;}
    public int UM {get; set;}
    public decimal Costo{get;set;}
    public decimal Precio{get;set;}
    public int Usuario{get;set;}
}

public class UpdateArticulosModel
{
    public int Id {get; set;}
    public string Codigo {get; set;}
    public string Descripcion {get; set;}
    public int UM {get; set;}
    public decimal Costo {get;set;}
    public decimal Precio {get;set;}
    public int Usuario {get;set;}
}

public class DeleteArticulosModel
{
    public int Id {get; set;}
}

}
