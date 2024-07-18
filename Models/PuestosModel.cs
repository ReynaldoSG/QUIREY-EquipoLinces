using System;
namespace marcatel_api.Models
{
  public class GetPuestosModel
  {
    public int Id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public decimal salario { get; set; }
    public DateTime fechaRegistro { get; set; }
    public DateTime fechaActualiza { get; set; }

    public string usuarioActualiza { get; set; }
    public string Mensaje { get; set; }
  }

  public class InsertPuestoModel
  {
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public decimal salario { get; set; }
    public int usuarioActualiza { get; set; }

  }

  public class UpdatePuestoModel
  {
    public int Id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public decimal salario { get; set; }
    public int usuarioActualiza { get; set; }
  }

  public class DeletePuestoModel
  {
    public int Id { get; set; }
  }
}