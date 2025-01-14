using CadastroIEL.Infrastructure.Interfaces;

namespace CadasreoIEL.UseCases
{
    public class DeleteUseCase : IDeleteUseCase
    {

        private readonly IService _service;

        public DeleteUseCase(IService service)
        {
            _service = service;
        }

        public async Task<bool> ExecuteAsync(string cpf)
        {
            var result = new ResultUseCase();

            result.Success = await _service.DeleteAsync(cpf);

            if (!result.Success)
            {
                result.Messages.Append("Usuario nao excluido");
            }

            return result.Success;
        }
    }
}
