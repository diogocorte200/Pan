using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BancoPan.Entity.Entity
{
    public class Cliente : BaseEntity
    {
        [Column(TypeName = "varchar(11)")]
        public string Cpf { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
    }
}
