using System;
namespace marcatel_api.Models
{
    public class GetAlmacenesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Encargado { get; set; }

        public DateTime FechaReg { get; set; }
        public DateTime FechaAct { get; set; }

        public string Mensaje {get; set;}

    }

    public class InsertAlmacenesModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Encargado { get; set; }
        public int Usuario { get; set; }

    }

    public class UpdateAlmacenesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Encargado { get; set; }
        public int Usuario { get; set; }
    }

    public class DeleteAlmacenesModel
    {
        public int Id { get; set; }
    }
}