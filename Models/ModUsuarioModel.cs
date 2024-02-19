using System;
namespace marcatel_api.Models
{
    public class GetModUserModel
    {
        public int ID { get; set; }
        public string Modulo { get; set; }
        public string Usuario{get;set;}
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualiza { get; set; }

    }


    public class InsertModUserModel
    {
        public int IdModulo { get; set; }
        public int IdUsuario{get;set;}

    }

    public class UpdateModUserModel
    {
        public int Id { get; set; }
        public int IdModulo { get; set; }
        public int IdUsuario{get;set;}

    }

    public class DeleteModUserModel
    {
        public int Id { get; set; }
    }
}