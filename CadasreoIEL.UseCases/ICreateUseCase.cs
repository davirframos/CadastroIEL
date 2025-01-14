using CadastroIEL.Infrastructure.Models;

namespace CadasreoIEL.UseCases
{
    public interface ICreateUseCase
    {
        Task<ResultUseCase> ExecuteAsync(Cadastro cadastroModel);
    }
}