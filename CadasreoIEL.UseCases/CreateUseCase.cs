using CadastroIEL.Infrastructure.Interfaces;
using CadastroIEL.Infrastructure.Models;

namespace CadasreoIEL.UseCases
{
    public class CreateUseCase : ICreateUseCase
    {

        private readonly IService _service;

        public CreateUseCase(IService service)
        {
            _service = service;
        }

        public async Task<ResultUseCase> ExecuteAsync(Cadastro cadastroModel)
        {

            var result = new ResultUseCase();

            if (!CpfValid(cadastroModel.CPF))
            {
                result.Success = false;

                result.Messages.Append("CPF Invalido");

                return result;

            }

            var createResult = await _service.CreateAsync(cadastroModel);

            if (!createResult)
            {
                result.Success = false;

                result.Messages.Append("Falha na criacao de usuario");
            }

            return result;
        }

        private bool CpfValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }


    }
}
