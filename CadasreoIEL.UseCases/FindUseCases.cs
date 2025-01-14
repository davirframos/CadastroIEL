using CadastroIEL.Infrastructure.Interfaces;
using CadastroIEL.Infrastructure.Models;

namespace CadasreoIEL.UseCases
{
    public class FindUseCase : IFindUseCase
    {

        private readonly IService _service;

        public FindUseCase(IService service)
        {
            _service = service;
        }

        public IEnumerable<Cadastro> ExecuteAsync(string cpf, string nome, string endereco, DateTime dateTime)
        {
            return _service.Find(cpf, nome, endereco, dateTime);
        }

    }
}
