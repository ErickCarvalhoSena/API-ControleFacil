using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.Areceber;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Damain.Services.Interfaces;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class AreceberService : IService<AreceberRequestContract, AreceberResponseContract, long>
    {
        private readonly IAreceberRepository _areceberRepository;

        private readonly IMapper _mapper;

        public AreceberService(IAreceberRepository areceberRepository, 
                                                                IMapper mapper)
        {
            _areceberRepository = areceberRepository;
            _mapper = mapper;
        }
        
        public async Task<AreceberResponseContract> Adicionar(AreceberRequestContract entidade, long idUsuario)
        {
            Areceber areceber = _mapper.Map<Areceber>(entidade);

            areceber.DataCadastro = DateTime.Now;
            areceber.IdUsuario = idUsuario;

            areceber = await _areceberRepository.Adicionar(areceber);

            return _mapper.Map<AreceberResponseContract>(areceber);
        }

        public async  Task<AreceberResponseContract> Atualizar(long id, AreceberRequestContract entidade, long idUsuario)
        {
            
            Areceber Areceber = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            var contrato = _mapper.Map<Areceber>(entidade);

            contrato.IdUsuario = Areceber.IdUsuario;
            contrato.Id = Areceber.Id;
            contrato.DataCadastro = Areceber.DataCadastro;

            contrato = await _areceberRepository.Atualizar(contrato);

            return _mapper.Map<AreceberResponseContract>(contrato);

            /*Areceber.DataCadastro = DateTime.Now;

            Areceber.Descricao = entidade.Descricao;
            Areceber.Observacao = entidade.Observacao;
            Areceber.ValorOriginal = entidade.ValorOriginal;
            Areceber.ValorPago = entidade.ValorPago;
            Areceber.DataPagamento = entidade.DataPagamento;
            Areceber.DataReferencia = entidade.DataReferencia;
            Areceber.DataVencimento = entidade.DataVencimento;
            Areceber.IdNaturezaDeLancamento = entidade.IdNaturezaDeLancamento;


            Areceber = await _areceberRepository.Atualizar(Areceber);

            return _mapper.Map<AreceberResponseContract>(Areceber);*/
        }

        public async Task Inativar(long id, long idUsuario)
        {
            Areceber areceber = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            await _areceberRepository.Deletar(areceber);
        }

        public async Task<IEnumerable<AreceberResponseContract>> Obter(long idUsuario)
        {
            var titulosAreceber = await _areceberRepository.ObterPeloIdUsuario(idUsuario);
            return titulosAreceber.Select(titulo => _mapper.Map<AreceberResponseContract>(titulo));
        }

        public async Task<AreceberResponseContract> Obter(long id, long idUsuario)
        {
            Areceber areceber = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            return _mapper.Map<AreceberResponseContract>(areceber);
        }

        private async Task<Areceber> ObterPorIdVinculadoAoIdUsuario(long id, long idUsuario)
        {
            var areceber = await _areceberRepository.Obter(id);

            if(areceber is null || areceber.IdUsuario != idUsuario)
            {
                throw new Exception($"Não foi encontrada nenhum titulo Areceber pelo id {id}");
            }

            return areceber;
        }
    }
}