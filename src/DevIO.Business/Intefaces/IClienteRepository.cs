using System;
using System.Threading.Tasks;
using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> Filtrar(string filterName, string filterEmail, string filterPhone, DateTime? filterDate, string filterBlocked);
    }

}
