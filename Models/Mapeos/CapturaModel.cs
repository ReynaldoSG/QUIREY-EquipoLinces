using Newtonsoft.Json;

namespace marcatel_api.Models
{
    public class CapturaModel
    {
        public int IdRenglon { get; set; }
        public float Cantidad { get; set; }
        public int IdUsuario { get; set; }
        public string Codigo { get; set; }
        public string Fecha {get; set;}
    }

    public class GuardarMapeoRequest
    {
        public int Id {get; set;}
        public int IdUsuario {get; set;}
    }

    public class GetCantidadesCapturadas
    {
        public int IdSucursal {get;set;}
        public string Fecha {get; set;}
        public int IdDepartamento {get; set;}
    }

    public class CantidadesCapturadasModel
    {
        public string Codigo {get; set;}
        public string Descripcion {get; set;}
        public decimal Cantidad {get; set;} 
    }

    public class GetDiferenciasInventarios
    {
        public string Codigo {get; set;}
        public string Descripcion {get; set;}
        public decimal SalidaVenta {get; set;}
        public decimal SalidaPConsumo {get;set ;}
        public decimal SalidaConversion {get; set;}
        public decimal SalidaPmerma {get; set;}
        public decimal SalidaTransferencia {get; set;}
        public decimal EntradaPTraspaso {get; set;}
        public decimal EntradaPConversion {get; set;}
        public decimal EntradaSOrden {get; set;}
        public decimal EntradaDevolucion {get; set;}
        public decimal Teorico {get; set;}
        public decimal Capturado {get; set;}
        public decimal Congelado {get;set;}
        public decimal Diferencia {get; set;}
    }
}
