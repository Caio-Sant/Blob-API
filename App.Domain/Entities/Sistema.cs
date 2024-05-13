using System.ComponentModel.DataAnnotations;

#nullable disable

namespace App.Domain.Entities
{
    public partial class Sistema
    {
        [Key]
        public int SistemaId { get; set; }
        public bool Ativo { get; set; }
        public string Chave { get; set; }
        public string Descricao { get; set; }
    }
}