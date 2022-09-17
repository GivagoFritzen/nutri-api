using Application.ViewModel.Medidas;
using Domain.Entity;
using System.Collections.Generic;

namespace Application.Mapper
{
    public static class MapperMedida
    {
        public static MedidaEntity ToEntity(this MedidaViewModel medidaViewModel)
        {
            return medidaViewModel == null ? null : new MedidaEntity()
            {
                Id = medidaViewModel.Id,
                Descricao = medidaViewModel.Descricao,
                Data = medidaViewModel.Data,
                PesoAtual = medidaViewModel.PesoAtual,
                PesoIdeal = medidaViewModel.PesoIdeal,
                Altura = medidaViewModel.Altura,
                Circunferencia = medidaViewModel.Circunferencia.ToEntity()
            };
        }

        public static void Update(this MedidaEntity medidaEntity, MedidaAtualizarViewModel medidaViewModel)
        {
            if (medidaEntity != null && medidaViewModel != null)
            {
                medidaEntity.Descricao = medidaViewModel.Medida.Descricao;
                medidaEntity.Data = medidaViewModel.Medida.Data;
                medidaEntity.PesoAtual = medidaViewModel.Medida.PesoAtual;
                medidaEntity.PesoIdeal = medidaViewModel.Medida.PesoIdeal;
                medidaEntity.Altura = medidaViewModel.Medida.Altura;
                medidaEntity.Circunferencia.Update(medidaViewModel.Medida.Circunferencia);
            };
        }

        public static List<MedidaViewModel> ToViewModel(this List<MedidaEntity> medidas)
        {
            var models = new List<MedidaViewModel>();

            if (medidas is not null && medidas.Count > 0)
            {
                foreach (var item in medidas)
                {
                    models.Add(new MedidaViewModel()
                    {
                        Id = item.Id,
                        Descricao = item.Descricao,
                        Data = item.Data,
                        PesoAtual = item.PesoAtual,
                        PesoIdeal = item.PesoIdeal,
                        Altura = item.Altura,
                        Circunferencia = item.Circunferencia.ToViewModel()
                    });
                }
            }

            return models;
        }
    }
}
