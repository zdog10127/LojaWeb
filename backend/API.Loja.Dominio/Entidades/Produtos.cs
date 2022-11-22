using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Dominio.Entidades
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        [Required]
        [Column("IdProduto")]
        public int IdProduto { get; set; }

        [Required]
        [Column("CodigoProduto", TypeName = "int")]
        public int CodigoProduto { get; set; }

        [Column("Descricao", TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Column("Preco", TypeName = "decimal")]
        public decimal Preço { get; set; }
    }
}
