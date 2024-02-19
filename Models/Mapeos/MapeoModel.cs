namespace marcatel_api.Models
{
    public class MapeoModel
    {
        public int Id { get; set; }
        public int IdArea { get; set; }
        public int IdSucursal { get; set; }
        public int IdUsuario { get; set; }
        public string Mueble { get; set; }
        public string Zona { get; set; }
        public string Cara { get; set; }
        public string Area { get; set; }
        public string Sucursal { get; set; }
        public string NombreUsuario { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public int Tipo { get; set; }


    }

    public class InsertMapeo
    {
        public int IdArea { get; set; }
        public int IdSucursal { get; set; }
        public string Mueble { get; set; }
        public string Zona { get; set; }
        public string Cara { get; set; }
        public string Area { get; set; }
        public int IdUsuario {get; set;}
    }

    public class GetValorInventarioReq
    {
        public string fecha_inicial {get; set;}
        public string fecha_final {get; set;}
    }


    public class GetMapeosImpresionReq
    {
        public int IdUsuario {get; set;}
        public int IdSucursal {get; set;}
        public int Impreso {get; set;}
    }

    public class GetDetalleMapeoreq
    {
        public int IdMapeo {get; set;}
        public int Tipo {get; set;}

    }

    public class KardexArticuloModel
    {
        public string Codigo {get; set;}
        public decimal Cantidad {get; set;}
        public decimal SalidaVentas {get; set;}
        public decimal SalidaConsumo {get; set;}
        public decimal SalidaMerma {get; set;}
        public decimal SalidaTransferencia {get; set;}
        public decimal SalidaConversion {get; set;}
        public decimal EntradaTraspaso {get; set;}
        public decimal EntradasConversion {get; set;}
        public decimal EntradasDevolucion {get; set;}
        public decimal EntradasSinOrden {get; set;}
        public decimal Teorico {get; set;}


    }

    public class GetKardexCodigoReq
    {
        public string FechaInicial {get; set;}
        public string FechaFinal {get; set;}
        public int Sucursal {get; set;}

    }

    public class MapeosCodigoModel
    {
        public int IdMapeo {get;set;}
        public int IdDetalleMapeo {get; set;}
        public string Codigo {get; set;}
        public string Descripcion {get; set;}
        public string Zona {get; set;}
        public string Mueble {get; set;}
        public string Cara {get; set;}
        public decimal Cantidad {get;set;}
    }

    public class GetMapeosCodigoReq
    {
        public string Codigo {get; set;}
        public string Fecha {get;set ;}
        public int IdSucursal {get; set;}
    }

}

