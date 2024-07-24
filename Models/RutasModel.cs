using System;
namespace marcatel_api.Models
{
    public class GetRutasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaRegristro { get; set; }
        public DateTime FechaActualiza { get; set; }
        public string Matricula { get; set; }
        public string Conductor { get; set; }
        public string NoLicencia { get; set; }
        public string NoSeguro { get; set; }

        public string Mensaje { get; set; }

    }

    public class InsertRutasModel
    {
        public string Nombre { get; set; }
        public int Usuario { get; set; }
        public string Matricula { get; set; }
        public string Conductor { get; set; }
        public string NoLicencia { get; set; }
        public string NoSeguro { get; set; }
    }

    public class UpdateRutasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Usuario { get; set; }
        public string Matricula { get; set; }
        public string Conductor { get; set; }
        public string NoLicencia { get; set; }
        public string NoSeguro { get; set; }
    }

    public class DeleteRutasModel
    {
        public int Id { get; set; }
    }
}