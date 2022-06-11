﻿using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Domain.Interface.Repository;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceTaco : IApplicationServiceTaco
    {
        private readonly ITacoRepository tacoRepository;

        public ApplicationServiceTaco(ITacoRepository tacoRepository)
        {
            this.tacoRepository = tacoRepository;
        }

        public async Task<ResponseView> GetTacoByPagination(string descricao, int paginaAtual, int tamanhoPagina)
        {
            var tacoPaginationDTO = await tacoRepository.GetDescricao(
                descricao == null ? "" : descricao,
                paginaAtual > 1 ? paginaAtual : 1,
                tamanhoPagina > 1 ? tamanhoPagina : 1);

            return new ResponseView(tacoPaginationDTO.ToViewModel());
        }
    }
}
