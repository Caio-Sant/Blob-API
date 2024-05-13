#nullable disable

namespace PosTechFiapImagensWebApi.Models.Request
{
    public class ImageRequestViewModel
    {
        public string Nome { get; set; }
        public byte[] DadosBytes { get; set; }
    }
}