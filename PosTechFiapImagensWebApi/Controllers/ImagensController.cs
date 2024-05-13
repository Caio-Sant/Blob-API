using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosTechFiapImagensWebApi.Interfaces;
using PosTechFiapImagensWebApi.Models.Request;
using PosTechFiapImagensWebApi.Models.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace PosTechFiapImagensWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagensController : ControllerBase
    {
        private readonly IAzureStorageBlobService _service;

        public ImagensController(IAzureStorageBlobService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        [SwaggerOperation(Summary = "Endpoint para obter todas a imagens presentes no Storage.", Description = "Endpoint para obter todas a imagens presentes no Storage.")]
        [SwaggerResponse(200, "OK", typeof(List<ImagemResponseViewModel>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public IActionResult GetImagens()
        {
            List<ImagemResponseViewModel> imagens = _service.PesquisarTodasImagens();
            return imagens == null ? NoContent() : Ok(imagens);
        }

        [HttpGet]
        [Route("Deletadas")]
        [SwaggerOperation(Summary = "Endpoint para obter todas a imagens deletadas no Storage.", Description = "Endpoint para obter todas a imagens deletadas no Storage.")]
        [SwaggerResponse(200, "OK", typeof(List<ImagemResponseViewModel>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public IActionResult GetImagensDeletadas()
        {
            List<ImagemResponseViewModel> imagensdel = _service.PesquisarTodasImagensDeletadas();
            return imagensdel == null ? NoContent() : Ok(imagensdel);
        }

        [HttpGet]
        [Route("{nome}")]
        [SwaggerOperation(Summary = "Endpoint para obter a imagem por nome de arquivo no Storage.", Description = "Endpoint para obter a imagem por nome de arquivo no Storage.")]
        [SwaggerResponse(200, "OK", typeof(ImagemResponseViewModel))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public IActionResult PesquisarUriArquivoPorNome([FromRoute] string nome)
        {
            Uri uri = _service.PesquisarUriArquivoPorNome(nome);

            ImagemResponseViewModel model = new()
            {
                Nome = nome,
                ImagemUri = uri
            };

            return uri == null ? NoContent() : Ok(model);
        }

        [HttpPost]
        [Route("upload")]
        [SwaggerOperation(Summary = "Endpoint para realizar upload da imagem no Storage.", Description = "Endpoint para realizar upload da imagem no Storage.")]
        public async Task<IActionResult> UploadImagemAsync([FromBody] ImageRequestViewModel model)
        {
            ImagemResponseViewModel imagem = await _service.UploadImagemAsync(new BinaryData(model.DadosBytes), model.Nome);

            return imagem == null ? NoContent() : Ok(imagem);
        }

        [HttpDelete]
        [Route("{nome}")]
        [SwaggerOperation(Summary = "Endpoint para remover uma imagem por nome de arquivo no Storage.", Description = "Endpoint para remover uma imagem por nome de arquivo no Storage.")]
        public async Task<IActionResult> DeletarArquivoPorNome([FromRoute] string nome)
        {
            int delete = await _service.DeletarImagemPorNome(nome);

            return delete.Equals(0) ? NoContent() : Ok(nome);
        }

        [HttpPut]
        [Route("{nome}")]
        [SwaggerOperation(Summary = "Endpoint para recuperar por nome imagem exluida no Storage.", Description = "Endpoint para recuperar por nome imagem exluida no Storage.")]
        [SwaggerResponse(200, "OK", typeof(string))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> RecuperarArquivoPorNome([FromRoute] string nome)
        {
            int recupera = await _service.RecuperarImagensDeletadas(nome);

            return recupera.Equals(0) ? NoContent() : Ok(nome);
        }

    }
}