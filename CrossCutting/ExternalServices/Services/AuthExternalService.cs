using Domain.Models;
using ExternalServices.Interfaces;
using System;

namespace ExternalServices.Services
{
    public class AuthExternalService : IAuthExternalService
    {
        private readonly Random _random = new();

        private readonly List<Guid> _guidsAnalistas = new()
        {
            Guid.Parse("ebf9dfec-d793-4689-9805-bab9a91822eb")
        };
        
        private readonly List<Guid> _guidsGerentes = new()
        {
            Guid.Parse("411e12c1-bc82-4258-9dd7-86fc912666f7"),
        };
        public CommonUser ObterAnalista()
        {
            return new CommonUser { Id = GerarIdUsuarioAnalista(), Funcao = FuncaoUser.ANALISTA };
        }

        public CommonUser ObterGerente()
        {
            return new CommonUser { Id = GerarIdUsuarioGerente(), Funcao = FuncaoUser.GERENTE };
        }

        public Guid GerarIdUsuarioAnalista()
        {
            int index = _random.Next(_guidsAnalistas.Count);
            return _guidsAnalistas[index];
        }

        public Guid GerarIdUsuarioGerente()
        {
            int index = _random.Next(_guidsGerentes.Count);
            return _guidsGerentes[index];
        }

        public List<CommonUser> ObterAnalistas()
        {
            return _guidsAnalistas.Select(x => new CommonUser { Funcao = FuncaoUser.ANALISTA, Id = x }).ToList();
        }

        public List<CommonUser> ObterGerentes()
        {
            return _guidsGerentes.Select(x => new CommonUser { Funcao = FuncaoUser.GERENTE, Id = x }).ToList();
        }
    }
}
