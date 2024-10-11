using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Models.Dtos
{
    public class SupplierRequestDto
    {
        [Required(ErrorMessage ="Por favor, informe o nome do fornecedor")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public string? Name { get; set; }
    }
}
