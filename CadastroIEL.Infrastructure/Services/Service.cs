using CadastroIEL.Infrastructure.Interfaces;
using CadastroIEL.Infrastructure.Models;

namespace CadastroIEL.Infrastructure.Services
{
    public class Service : IService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public Service(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> CreateAsync(Cadastro cadastroModel)
        {

            await _applicationDbContext.AddAsync(cadastroModel);

            var changes = await _applicationDbContext.SaveChangesAsync();

            return changes == 1;

        }

        public IEnumerable<Cadastro> GetUsersAsync()
        {
            var cadastro = _applicationDbContext.Products.ToList();

            if (cadastro == null)
            {
                return Enumerable.Empty<Cadastro>();
            }

            return cadastro;
        }

        public IEnumerable<Cadastro> Find(string cpf, string nome, string endereco, DateTime dateTime)
        {

            var cadastro = _applicationDbContext.Products
                    .Where(b => b.CPF.Equals(cpf) &&
                            b.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase) &&
                            b.Endereco.Contains(endereco) &&
                            b.DataConclusao == (int)(dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds));

            return cadastro;
        }

        public async Task<bool> DeleteAsync(string cpf)
        {
            var cadastro = await _applicationDbContext.Products.FindAsync(cpf);

            if (cadastro == null)
                return false;

            _applicationDbContext.Products.Remove(cadastro);

            var changes = await _applicationDbContext.SaveChangesAsync();

            return changes == 1;
        }

    }
}
