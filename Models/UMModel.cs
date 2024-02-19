using System;
namespace marcatel_api.Models
{
    public class GetUMModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Usuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaActualiza { get; set; }
}

public class InsertUMModel
{
    public string Nombre { get; set; }
    public int Usuario { get; set; }
}

public class UpdateUMModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Usuario { get; set; }
}

public class DeleteUMModel
{
    public int Id { get; set; }
}
}