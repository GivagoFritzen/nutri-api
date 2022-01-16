using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : MainController
    {
        private readonly IApplicationServiceAdmin applicationServiceAdmin;

        public AdminController(IApplicationServiceAdmin applicationServiceAdmin)
        {
            this.applicationServiceAdmin = applicationServiceAdmin;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseView>> Add([FromBody] AdminAdicionarViewModel adminAdicionarViewModel)
        {
            return await applicationServiceAdmin.Add(adminAdicionarViewModel);
        }
    }
}
