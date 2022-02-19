using Application.ViewModel.Admin;

namespace ApplicationTest.ViewModel.Admin
{
    public static class AdminViewModelFake
    {
        public static AdminAdicionarViewModel GetAdminAdicionarViewModelFake(
            string senha = "senha",
            string email = "email")
        {
            return new AdminAdicionarViewModel()
            {
                Senha = senha,
                Email = email
            };
        }
    }
}
