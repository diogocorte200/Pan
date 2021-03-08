using BancoPan.Domain.Domain.Aggregate.Ibge;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoPan.Domain.Interfaces
{
    public interface IIbgeService
    {
        Task<List<Estado>> SearchEstates();
        Task<List<Municipio>> SearchCounties(int id);
    }
}
