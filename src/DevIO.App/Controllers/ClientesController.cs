using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlX.XDevAPI;
using Microsoft.AspNetCore.Authorization;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, 
                                      IMapper mapper,
                                      IClienteService clienteService,
                                      INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
           _clienteService = clienteService;
        }


        public async Task<IActionResult> Index(int? page)
        {
            var clientes = await _clienteRepository.ObterTodos();

            var clientesViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);


            int pageSize = 20;
            int pageNumber = page ?? 1;

            var pagedClientes = clientesViewModel.ToPagedList(pageNumber, pageSize);

            return View(pagedClientes);
        }

        [Route("novo-cliente")]
        public IActionResult Create()
        {
            return View();
        }

       
        [Route("novo-cliente")] 
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteService.Adicionar(cliente);

            if (!OperacaoValida()) return View(clienteViewModel);

            TempData["Sucesso"] = "Cliente cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        
        [Route("editar-cliente/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = await ObterCliente(id); 

            if (clienteViewModel == null)
            {
                return NotFound();
            }
           
            return View(clienteViewModel);
        }

        
        [Route("editar-cliente/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Atualizar(cliente);

            if (!OperacaoValida()) return View(await ObterCliente(id));

            TempData["Sucesso"] = "Cliente editadp com sucesso!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> FiltrarClientes(string filterName, string filterEmail, string filterPhone, string filterDate, string filterBlocked, int? page)
        {
            DateTime? parsedDate = null;

            if (!string.IsNullOrEmpty(filterDate) && DateTime.TryParse(filterDate, out DateTime date))
            {
                parsedDate = date;
            }

            var clientes = await _clienteRepository.Filtrar(filterName, filterEmail, filterPhone, parsedDate, filterBlocked);

            var clientesViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var pagedClientes = clientesViewModel.ToPagedList(pageNumber, pageSize);

            
            return View("Index", pagedClientes);
        }

        [HttpGet]
        [Route("remover-filtro")]
        public async Task<IActionResult> RemoverFiltro()
        {
            var clientes = await _clienteRepository.ObterTodos();
            var clientesViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

            int pageSize = 20;
            int pageNumber = 1; 

            var pagedClientes = clientesViewModel.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedClientes);
        }




        private async Task<ClienteViewModel> ObterCliente(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }

      
    }
}
