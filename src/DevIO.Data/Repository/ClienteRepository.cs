using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext db) : base(db){}

        public async Task<IEnumerable<Cliente>> Filtrar(string filterName, string filterEmail, string filterPhone, DateTime? filterDate, string filterBlocked)
        {
            filterName = filterName?.Trim().ToLower();
            filterEmail = filterEmail?.Trim().ToLower();
            filterPhone = filterPhone?.Trim().ToLower();

            bool isBlocked = filterBlocked == "blocked";

            var query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filterName))
            {
                query = query.Where(v => v.Nome.ToLower().Contains(filterName));
            }

            if (!string.IsNullOrEmpty(filterEmail))
            {
                query = query.Where(v => v.Mail.ToLower().Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterPhone))
            {
                query = query.Where(v => v.Telefone.ToLower().Contains(filterPhone));
            }

            if (filterDate.HasValue)
            {
                query = query.Where(v => v.DataCadastro.Date == filterDate.Value.Date);
            }

            if (filterBlocked == "blocked")
            {
                query = query.Where(v => v.Bloqueado);
            }
            else if (filterBlocked == "notBlocked")
            {
                query = query.Where(v => !v.Bloqueado);
            }

            return await query.ToListAsync();
        }




    }
}
