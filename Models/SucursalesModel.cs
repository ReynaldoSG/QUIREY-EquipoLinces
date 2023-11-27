using System;
namespace marcatel_api.Models
{
    public class GetSucursalesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaAct { get; set; }
        public DateTime FechaReg { get; set; }
    }

    public class InsertSucursalesModel
    {
        public string Nombre { get; set; }
        public string Usuario { get; set; }
    }

    public class UpdateSucursalesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
    }

    public class DeleteSucursalesModel
    {
        public int Id { get; set; }
    }
}