using Application.ViewModel.Medidas;
using Domain.Entity;

namespace Application.Mapper
{
    public static class MapperMedida
    {
        public static MedidaEntity ToEntity(this MedidaAdicionarViewModel medidaViewModel)
        {
            return medidaViewModel == null ? null : new MedidaEntity()
            {
                Descricao = medidaViewModel.Descricao,
                Data = medidaViewModel.Data,
                PesoAtual = medidaViewModel.PesoAtual,
                PesoIdeal = medidaViewModel.PesoIdeal,
                Altura = medidaViewModel.Altura,
                Circunferencias = medidaViewModel.Circunferencias.ToEntity()
            };
        }

        public static MedidaEntity ToEntity(this MedidaViewModel medidaViewModel)
        {
            return medidaViewModel == null ? null : new MedidaEntity()
            {
                Descricao = medidaViewModel.Descricao,
                Data = medidaViewModel.Data,
                PesoAtual = medidaViewModel.PesoAtual,
                PesoIdeal = medidaViewModel.PesoIdeal,
                Altura = medidaViewModel.Altura,
                Circunferencias = medidaViewModel.Circunferencias.ToEntity()
            };
        }

        public static MedidaViewModel ToViewModel(this MedidaEntity medida)
        {
            return medida == null ? null : new MedidaViewModel()
            {
                Descricao = medida.Descricao,
                Data = medida.Data,
                PesoAtual = medida.PesoAtual,
                PesoIdeal = medida.PesoIdeal,
                Altura = medida.Altura,
                Circunferencias = medida.Circunferencias.ToViewModel()
            };
        }
    }
}
