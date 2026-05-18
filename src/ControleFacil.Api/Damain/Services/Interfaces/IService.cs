using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Damain.Services.Interfaces
{
    /// <summary>
    /// Interface generica para criação de serviços do tipo CRUD
    /// </summary>
    /// <typeparam name="RQ">contrato de request</typeparam>
    /// <typeparam name="RS">contrato de response</typeparam>
    /// <typeparam name="I">Tipo do Id</typeparam> <summary>
    
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Obter(I idUsuario);

        Task<RS> Obter(I id, I idUsuario);

        Task<RS> Adicionar(RQ entidade, I idUsuario);

        Task<RS> Atualizar(I id,RQ entidade, I idUsuario);

        Task Inativar(I id, I idUsuario);
    }
}