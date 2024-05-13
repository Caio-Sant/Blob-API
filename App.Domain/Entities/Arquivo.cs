using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public partial class Arquivo
    {
        [Key]
        public int Id { get; set; }
        public string? NomeArquivo { get; set; }
    }
}