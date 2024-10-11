using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Models.Dtos
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor do produto.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade disponível")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Por favor, informe o ID do fornecedor deste produto")]
        public Guid? SupplierId { get; set; }

    }
}
