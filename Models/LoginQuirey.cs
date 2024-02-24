using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
    public class GetCatPerfilSearch{
        public int IdPerfil { get; set; }
    }

    public class GetModCatSearch{
        public int IdCategoria{ get; set; }
    }

    public class GetCatPerfil{
        public int Id { get; set; }
        public string Categoria { get; set; }
    }

    public class GetModCat{
        public int Id {get; set;}
        public string Modulo {get; set;}
        public string Categoria {get; set;}
    }

    public class CategoriasModulos{
        public GetCatPerfil Categoria {get; set;}
        public List<GetModCat> Modulos {get; set;}
    }
}
