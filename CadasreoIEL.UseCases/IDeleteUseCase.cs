
namespace CadasreoIEL.UseCases
{
    public interface IDeleteUseCase
    {
        Task<bool> ExecuteAsync(string cpf);
    }
}