using System;
namespace marcatel_api.Models
{
  public class GetCorteModel
  {
    public int Id { get; set; }

    public string Vendedor { get; set; }

    public string Total { get; set; }

    public DateTime FechaVenta { get; set; }
  }

  public class GetCorteFiltroModel
  {
    public int vendedor { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }
  }
}