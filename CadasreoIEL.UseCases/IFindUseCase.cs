using CadastroIEL.Infrastructure.Models;

namespace CadasreoIEL.UseCases
{
    public interface IFindUseCase
    {
        IEnumerable<Cadastro> ExecuteAsync(string cpf, string nome, string endereco, DateTime dateTime);
    }
}