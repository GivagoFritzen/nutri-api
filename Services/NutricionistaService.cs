﻿using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data.Interfaces;

namespace Services
{
    public class NutricionistaService : ServiceBase<NutricionistaEntity>, INutricionistaService
    {
        public NutricionistaService(IRepositoryBase<NutricionistaEntity> repositoryNutricionista)
            : base(repositoryNutricionista)
        {
            repository = repositoryNutricionista;
        }
    }
}