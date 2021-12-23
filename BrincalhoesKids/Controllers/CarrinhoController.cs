//Importa as libs
using BrincalhoesKids.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace BrincalhoesKids.Controllers
{
    //Classe que possui as rotas das Actions relacionadas a manipulação do carrinho
    public class CarrinhoController : Controller
    {   
        //Função chamada ao abrir pagina Carrinho
        public IActionResult Index()
        {
            //Se não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Index Carrinho");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando Login");
                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Cria um objeto da classe que manipula o banco de dados
                CarrinhoBD cBD = new CarrinhoBD();

                //Recebe a listagem de produtos no carrinho
                List<Carrinho> listagem = cBD.Listar();

                //Exibe no console
                Console.WriteLine("\n\t-> Index Carrinho");
                Console.WriteLine("\n\tUsuário logado\n\tExibindo carrinho");

                //Retorna a View lista com a listagem
                return View(listagem);
            }
        }

        //Função para editar um item do carrinho
        public IActionResult Editar(int Id)
        {
            //Se estiver não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Editar Carrinho");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando login");
                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Cria um objeto da classe que manipula o banco de dados
                CarrinhoBD cBD = new CarrinhoBD();

                //Busca o item que vai ser editado pelo Id
                Carrinho item = cBD.BuscarPorId(Id);

                //Exibe no console
                Console.WriteLine("\n\t-> Editar Carrinho");
                Console.WriteLine("\n\tUsuário logado\n\tExibindo página de edição");

                //Retorna o objeto item
                return View(item);
            }
        }

        //Função chamada ao enviar o formlario da pagina Editar
        [HttpPost]
        public IActionResult Editar(Carrinho item)
        {
            //Se estiver não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Editar Carrinho");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando login");
                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Cria um objeto da classe que manipula o banco de dados
                CarrinhoBD cBD = new CarrinhoBD();

                //Atualiza as informações no banco de dados
                cBD.Editar(item);

                //Exibe no console
                Console.WriteLine("\n\t-> Editar Carrinho");
                Console.WriteLine("\n\tUsuário logado\n\tEdição realizada");
                
                //Retorna a função que chama a pagina Index para atualizar as infos dos itens no carrinho
                return RedirectToAction("Index", "Carrinho");
            }
        }

        //Função para inserir um item no carrinho
        public IActionResult Inserir(int Id)
        {
            //Se estiver não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Inserir Carrinho");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando login");

                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Cria um objeto d tipo item do carrinho
                Carrinho item = new Carrinho();

                //Recebe o ID do produto
                item.IdProduto = Id;
                //Recebe a quantidade que será adicionada ao carrinho
                item.Quantidade = 0;
                //Recebe o ID do usuario
                item.IdUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");

                //Exibe no console
                Console.WriteLine("\n\t-> Inserir Carrinho");
                Console.WriteLine("\n\tUsuário logado\n\tExibindo página de inserção");
                
                //Retorna a View inserir
                return View(item);
            }
        }

        //Função chamada ao enviar o formlario da pagina inserir
        [HttpPost]
        public IActionResult Inserir(Carrinho item)
        {
            //Se estiver não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Inserir Carrinho");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando login");

                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Cria um objeto da classe que manipula o banco de dados do carrinho
                CarrinhoBD cBD = new CarrinhoBD();

                //Insere o item no banco de dados
                cBD.Inserir(item);

                //Exibe no console
                Console.WriteLine("\n\t-> Inserir Carrinho");
                Console.WriteLine("\n\tUsuário logado\n\tInclusão realizada");
                
                //Retorna a função que chama a pagina Index para atualizar as infos dos itens no carrinho
                return RedirectToAction("Index", "Carrinho");
            }
        }
        //Função para excluir um item do carrinho no banco de dados
        public IActionResult Excluir(int Id)
        {
            //Se não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Excluir Carrinho");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando login");
                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Cria um objeto da classe que manipula o banco de dados
                CarrinhoBD cBD = new CarrinhoBD();

                //Busca o item que vai ser editado pelo Id
                Carrinho item = cBD.BuscarPorId(Id);

                //Exclui o item no banco de dados
                cBD.Excluir(item);

                //Exibe no console
                Console.WriteLine("\n\t-> Excluir Carrinho");
                Console.WriteLine("\n\tUsuário logado\n\tExclusão realizada");

                //Retorna a função que chama a pagina Carrinho para limpar o item excluido da listagem
                return RedirectToAction("Index", "Carrinho");
            }
        }
    }
}