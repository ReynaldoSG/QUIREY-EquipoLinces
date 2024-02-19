namespace marcatel_api.Models
{
    public class RenglonMapeoModel
    {
        public int Id { get; set; }
        public int Tipo {get; set;}
        public int IdMapeo { get; set; }
        public string Codigo { get; set; }
        public int Estante { get; set; }
        public string DescripcionArticulo { get; set; }
        public int IdUsuario { get; set; }
        public int Consecutivo { get; set; }
        public float CantidadDirecto { get; set; }
        public float CantidadCaptura { get; set; }
    }

    public class CongelarInventarioModel
    {
        public string Fecha {get; set;}
        public string FechaInicial {get; set;}
        public string FechaFinal {get; set;}
        public int IdSucursal {get; set;}
    }
}