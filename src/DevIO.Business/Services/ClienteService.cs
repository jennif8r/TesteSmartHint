using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(f => f.Documento == cliente.Documento).Result.Any())
            {
                Notificar("Este CPF/CNPJ já está cadastrado para outro Cliente.");
                return;
            }
            if (_clienteRepository.Buscar(f => f.Mail == cliente.Mail).Result.Any())
            {
                Notificar("Este e-mail já está cadastrado para outro Cliente.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(cliente.InscricaoEstadual))
            {
                if (_clienteRepository.Buscar(f => f.InscricaoEstadual == cliente.InscricaoEstadual).Result.Any())
                {
                    Notificar("Esta Inscrição Estadual já está cadastrada para outro Cliente");
                    return;
                }
            }


            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(f => f.Documento == cliente.Documento).Result.Any())
            {
                Notificar("Este CPF/CNPJ já está cadastrado para outro Cliente.");
                return;
            }
            if (_clienteRepository.Buscar(f => f.Mail == cliente.Mail).Result.Any())
            {
                Notificar("Este e-mail já está cadastrado para outro Cliente.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(cliente.InscricaoEstadual))
            {
                if (_clienteRepository.Buscar(f => f.InscricaoEstadual == cliente.InscricaoEstadual).Result.Any())
                {
                    Notificar("Esta Inscrição Estadual já está cadastrada para outro Cliente");
                    return;
                }
            }


            await _clienteRepository.Atualizar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}