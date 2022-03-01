using Application.ViewModel.Medidas;
using Domain.Entity;
using System.Collections.Generic;

namespace Application.Mapper
{
    public static class MapperMedida
    {
        public static List<MedidaEntity> ToEntity(this MedidaAdicionarViewModel medidaViewModel)
        {
            var entities = new List<MedidaEntity>();

            if (medidaViewModel is not null)
            {
                entities.Add(new MedidaEntity()
                {
                    Descricao = medidaViewModel.Descricao,
                    Data = medidaViewModel.Data,
                    PesoAtual = medidaViewModel.PesoAtual,
                    PesoIdeal = medidaViewModel.PesoIdeal,
                    Altura = medidaViewModel.Altura,
                    Circunferencia = medidaViewModel.Circunferencia.ToEntity()
                });
            }

            return entities;
        }

        public static List<MedidaEntity> ToEntity(this List<MedidaViewModel> medidaViewModel)
        {
            var entities = new List<MedidaEntity>();

            if (medidaViewModel is not null && medidaViewModel.Count > 0)
            {
                foreach (var item in medidaViewModel)
                {
                    entities.Add(new MedidaEntity()
                    {
                        Descricao = item.Descricao,
                        Data = item.Data,
                        PesoAtual = item.PesoAtual,
                        PesoIdeal = item.PesoIdeal,
                        Altura = item.Altura,
                        Circunferencia = item.Circunferencia.ToEntity()
                    });
                }
            }

            return entities;
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
