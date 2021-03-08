using BancoPan.Domain.Domain.Aggregate;
using System.Threading.Tasks;

namespace BancoPan.Domain.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCep> SearchAddress(string cep);
    }
}
