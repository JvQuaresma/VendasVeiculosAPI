using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Models;

namespace Veiculos.Domain.Interfaces.Repositories {
    public interface ISaleRepository {

        public Task<Sale> SellAsync(Sale sale);
        public Task<Sale> GetByIdAsync(int id);
        public Task<IEnumerable<Sale>> GetAllAsync(int page, int limit, int offset);

    }
}
