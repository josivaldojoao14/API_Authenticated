using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWith.NET5.Model
{
    [Table("clientes")]

    public class Cliente
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("idade")]
        public int Idade { get; set; }

        [Column("senha")]
        public string senha { get; set; }

        [Column("perfil")]
        public string perfil { get; set; }

    }
}
