﻿using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPacienteService : IServiceBase<PacienteEntity>
    {
        Task<bool> VerificarEmailExiste(string email);
        Task<bool> VerificarEmailExiste(string email, Guid currentId);
    }
}