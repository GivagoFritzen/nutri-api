using System.ComponentModel;

namespace Application.Commands
{
    public class UserCommand : Command
    {
        public string AntigaSenha { get; set; }

        [DefaultValue("")]
        public string NovaSenha { get; set; }
    }
}
