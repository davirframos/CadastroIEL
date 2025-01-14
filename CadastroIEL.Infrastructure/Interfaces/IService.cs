using CadastroIEL.Infrastructure.Models;

namespace CadastroIEL.Infrastructure.Interfaces
{
    public interface IService
    {
        Task<bool> CreateAsync(Cadastro cadastroModel);

        IEnumerable<Cadastro> GetUsersAsync();

        IEnumerable<Cadastro> Find(string cpf, string nome, string endereco, DateTime dateTime);

        Task<bool> DeleteAsync(string cpf);
    }
}
