using CadasreoIEL.UseCases;
using CadastroIEL.Infrastructure.Models;
using CadastroIEL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroIEL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IGetUseCase getUseCase;
        private readonly IFindUseCase findUseCase;
        private readonly IDeleteUseCase deleteUseCase;
        private readonly ICreateUseCase createUseCase;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
            IGetUseCase getUseCase, IFindUseCase findUseCase, IDeleteUseCase deleteUseCase, ICreateUseCase createUseCase)
        {
            _logger = logger;
            this.getUseCase = getUseCase;
            this.findUseCase = findUseCase;
            this.deleteUseCase = deleteUseCase;
            this.createUseCase = createUseCase;
        }

        public async Task<IActionResult> Index()
        {
            return View(getUseCase.ExecuteAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                var result = await createUseCase.ExecuteAsync(cadastro);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }

                return View(result.Messages.FirstOrDefault()); 
            }

            return View(cadastro);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string? nome, string? cpf, string endereco, DateTime dataConclusao)
        {
            // Fetch and filter the data
            var results = findUseCase.ExecuteAsync(cpf, nome, endereco, dataConclusao);

            return View(results.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
