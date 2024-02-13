using System;
namespace marcatel_api.Models
{
    public class GetCatPerfil{
        public int Id {get; set;}
        public string Categoria {get; set;}
    }

    public class GetModCat{
        public int Id {get; set;}
        public string Modulo {get; set;}
        public string Categoria {get; set;}
    }
}
