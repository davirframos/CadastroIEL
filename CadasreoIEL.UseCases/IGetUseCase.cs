using CadastroIEL.Infrastructure.Models;

namespace CadasreoIEL.UseCases
{
    public interface IGetUseCase
    {
        IEnumerable<Cadastro> ExecuteAsync();
    }
}