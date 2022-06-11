using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class TacoController : MainController
    {
        private readonly IApplicationServiceTaco applicationServiceTaco;

        public TacoController(IApplicationServiceTaco applicationServiceTaco)
        {
            this.applicationServiceTaco = applicationServiceTaco;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseView>> GetTacoByPagination(string descricao, int paginaAtual, int tamanhoPagina)
        {
            return CustomResponse(await applicationServiceTaco.GetTacoByPagination(descricao, paginaAtual, tamanhoPagina));
        }
    }
}
