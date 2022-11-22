using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Dominio.Entidades
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Required]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

        [Required]
        [Column("CodigoCategoria", TypeName = "int")]
        public int CodigoCategoria { get; set; }

        [Column("Descricao", TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Column("Produtos")]
        public List<Produtos> Produtos { get; set; }
    }
}
