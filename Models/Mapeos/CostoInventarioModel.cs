namespace marcatel_api.Models
{
    public class CostoInventarioModel
    {
        public int IdFamilia {get; set;}
        public string NombreFamilia {get; set;}
        public string NombreDepartamento {get; set;}
        public decimal Ventas {get; set;}
        public decimal Compras {get; set;}
        public decimal Devoluciones {get; set;}
        public decimal Ajustes {get; set;}
        public decimal TransferEntradas {get; set;}
        public decimal Mermas {get; set;}
        public decimal TransferSalidas {get; set;}
        public decimal NotasCargo {get;set;}
        public decimal InvInicial {get; set;}
        
    }
}