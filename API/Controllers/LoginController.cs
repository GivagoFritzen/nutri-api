using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : MainController
    {
        private readonly IApplicationServiceLogin applicationServiceLogin;

        public LoginController(IApplicationServiceLogin applicationServiceLogin)
        {
            this.applicationServiceLogin = applicationServiceLogin;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] LoginNutricionistaViewModel loginNutricionistaViewModel)
        {
            return CustomResponse(await applicationServiceLogin.Login(loginNutricionistaViewModel));
        }

        [HttpPatch]
        [AllowAnonymous]
        public ActionResult Refresh([FromBody] LoginTokenViewModel loginTokenViewModel)
        {
            return CustomResponse(applicationServiceLogin.Refresh(loginTokenViewModel));
        }
    }
}
