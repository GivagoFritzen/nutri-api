using Application.Services;
using Application.ViewModel.Taco;
using CrossCuttingTest;
using Domain.Event.Taco;
using Domain.Repository;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Services
{
    [TestClass]
    public class ApplicationServiceTacoTest
    {
        private ApplicationServiceTaco applicationService;

        [TestInitialize]
        public async Task Initialize()
        {
            var mongoFake = new MongoFake<TacoEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<TacoEvent>().GetMongoDbContext(mongoFake);
            var tacoRepository = new TacoRepository(mongoDbContextoMock.Object);

            applicationService = new ApplicationServiceTaco(tacoRepository);
        }

        [TestMethod]
        public async Task Get_Taco_By_Pagination_Valores_Vazios()
        {
            var retorno = await applicationService.GetTacoByPagination(null, -1, -1);
            retorno.Errors.Should().BeNullOrEmpty();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTamanhoPaginas), DynamicDataSourceType.Method)]
        public async Task Get_Taco_By_Pagination_Valores_Limite_Pagina(int tamanhoPagina)
        {
            var retorno = await applicationService.GetTacoByPagination(null, -1, tamanhoPagina);
            var pagination = retorno.Body as TacoPaginationViewModel;
            pagination.Data.Count.Should().Be(tamanhoPagina);
        }

        [TestMethod]
        public async Task Get_Taco_By_Pagination_Paginas_Diferentes()
        {
            var primeiraPagina = await applicationService.GetTacoByPagination(null, 1, 1);
            var primeiroItem = (primeiraPagina.Body as TacoPaginationViewModel).Data.FirstOrDefault();

            var segundaPagina = await applicationService.GetTacoByPagination(null, 2, 1);
            var segundaItem = (segundaPagina.Body as TacoPaginationViewModel).Data.FirstOrDefault();

            primeiroItem.Id.Should().NotBe(segundaItem.Id);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDescricao), DynamicDataSourceType.Method)]
        public async Task Get_Taco_By_Pagination_Por_Descricao(string descricao, int total)
        {
            var retorno = await applicationService.GetTacoByPagination(descricao, 1, 10);
            var pagination = retorno.Body as TacoPaginationViewModel;

            pagination.Data.Should().HaveCount(total);
        }

        private static IEnumerable<object[]> GetTamanhoPaginas()
        {
            yield return new object[] { 2 };
            yield return new object[] { 5 };
            yield return new object[] { 8 };
        }

        private static IEnumerable<object[]> GetDescricao()
        {
            yield return new object[] { "Arroz, integral, cozido", 1 };
            yield return new object[] { "Arroz", 6 };
        }
    }
}
