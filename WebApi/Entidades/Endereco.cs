using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    [Table("Endereco")]
    public class Endereco
    {
        public int Id { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        //[ForeignKey("")]
        public int ClientId { get; set; }
       // public virtual Cliente Cliente { get; set; }
    }
}
