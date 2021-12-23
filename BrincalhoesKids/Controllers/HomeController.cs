using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BrincalhoesKids.Models;

namespace BrincalhoesKids.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Cria um objeto da classe que manipula o banco de dados usuario
            UsuarioBD uBD = new UsuarioBD();
            //Testa a conexão com o banco de dados
            uBD.TestarConexao();

            //Cria um objeto da classe que manipula o banco de dados
            ProdutoBD pBD = new ProdutoBD();

            //Recebe a listagem de produtos
            List<Produto> listagem = pBD.Listar();            

            //Retorna a View lista com a listagem
            return View(listagem);
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
