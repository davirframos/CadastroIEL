using CadastroIEL.Infrastructure.Interfaces;
using CadastroIEL.Infrastructure.Models;

namespace CadasreoIEL.UseCases
{
    public class GetUseCase : IGetUseCase
    {
        private readonly IService _service;

        public GetUseCase(IService service)
        {
            _service = service;
        }

        public IEnumerable<Cadastro> ExecuteAsync()
        {
            return _service.GetUsersAsync();
        }
    }
}
