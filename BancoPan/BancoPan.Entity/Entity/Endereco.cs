using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BancoPan.Entity.Entity
{
    public class Endereco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(TypeName = "int")]
        public int IdEndereco { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Logradouro { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Numero { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Complemento { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Cidade { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string Estado { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Pais { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Cep { get; set; }
        [Column(TypeName = "int")]
        public int IdCliente { get; set; }

        
    }
}
