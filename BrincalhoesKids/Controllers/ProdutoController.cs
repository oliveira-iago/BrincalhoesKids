//Importa as libs
using BrincalhoesKids.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BrincalhoesKids.Controllers
{
    //Classe que possui as rotas das Actions relacionadas a manipulação dos prodtutos
    public class ProdutoController : Controller
    {   
        //Função chamada ao abrir pagina Produtos
        public IActionResult Disney()
        {
            //Cria um objeto da classe que manipula o banco de dados
            ProdutoBD pBD = new ProdutoBD();

            //Recebe a listagem de produtos
            List<Produto> listagem = pBD.Listar();

            //Retorna a View lista com a listagem
            return View(listagem);
        }

        //Função chamada ao abrir pagina Produtos
        public IActionResult StarWars()
        {
            //Cria um objeto da classe que manipula o banco de dados
            ProdutoBD pBD = new ProdutoBD();

            //Recebe a listagem de produtos
            List<Produto> listagem = pBD.Listar();

            //Retorna a View lista com a listagem
            return View(listagem);
        }

        //Função chamada ao abrir pagina Produtos
        public IActionResult Marvel()
        {
            //Cria um objeto da classe que manipula o banco de dados
            ProdutoBD pBD = new ProdutoBD();

            //Recebe a listagem de produtos
            List<Produto> listagem = pBD.Listar();

            //Cria um objeto do tipo item de carrinho
            Carrinho itemCarrinho = new Carrinho();

            //Retorna a View lista com a listagem
            return View(listagem);
        }
        
        //Função chamada ao abrir pagina Produtos
        public IActionResult Barbie()
        {
            //Cria um objeto da classe que manipula o banco de dados
            ProdutoBD pBD = new ProdutoBD();

            //Recebe a listagem de produtos
            List<Produto> listagem = pBD.Listar();

            //Retorna a View lista com a listagem
            return View(listagem);
        }
    }
}