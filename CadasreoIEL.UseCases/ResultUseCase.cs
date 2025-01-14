namespace CadasreoIEL.UseCases
{
    public class ResultUseCase
    {

        public bool Success { get; set; } = true;

        public IEnumerable<string> Messages { get; set; } = new List<string>();
    }
}
