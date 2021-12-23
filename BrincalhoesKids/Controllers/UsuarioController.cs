//Importa as libs
using BrincalhoesKids.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace BrincalhoesKids.Controllers
{
    //Classe que possui as rotas das Actions relacionadas a manipulação de Usuario
    public class UsuarioController : Controller
    {   
        //Função chamada ao abrir pagina Perfil
        public IActionResult Perfil()
        {
            //Se não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Exibir Perfil");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando Login");
                
                //Retorna a função que chama a pagina Index
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Exibir Perfil");
                Console.WriteLine("\n\tUsuário logado\n\tExibindo perfil");
                
                //Retorna a View perfil Usuario
                return View();
            }
        }
        
        //Função chamada ao abrir pagina Login
        public IActionResult Login()
        {
            //Se não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Fazer login");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando Login");
                
                //Retorna a View login Usuario
                return View();
            }
            else
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Fazer login");
                Console.WriteLine("\n\tUsuário logado\n\tExibindo perfil");
                
                //Retorna a função que chama a pagina Index
                return RedirectToAction("Perfil", "Usuario");
            }
        }

        //Função chamada ao enviar o formlario da pagina Login
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            //Cria um objeto da classe que manipula o banco de dados
            UsuarioBD uBD = new UsuarioBD();

            //Valida o login
            Usuario usuarioValidado = uBD.ValidarLogin(usuario);

            //Verifica se o usuário foi validado
            if(usuarioValidado.Id == 0)
            {
                //Mensagem de erro
                ViewBag.Mensagem = "Login ou senha incorretos";
                
                //Exibe no console
                Console.WriteLine("\n\t-> Fazer login");
                Console.WriteLine("\n\tFalha ao tentar efetuar login");
                
                //Retorna a função que chama a propria pagina
                return View();
            }
            else
            {                   
                //Grava as credenciais na sessão - pra continuar logado (tipo Cookies)
                HttpContext.Session.SetInt32("IdUsuario", usuarioValidado.Id); //Id do usuario
                HttpContext.Session.SetString("NomeUsuario", usuarioValidado.Nome); //Nome do usuario
                HttpContext.Session.SetString("SobrenomeUsuario", usuarioValidado.Sobrenome); //Sobrenome do usuario
                HttpContext.Session.SetString("EmailUsuario", usuarioValidado.Email); //Email do usuario
                HttpContext.Session.SetString("LoginUsuario", usuarioValidado.Login); //Login do usuario
                
                //Exibe no console
                Console.WriteLine("\n\t-> Fazer login");
                Console.WriteLine("\n\tLogin efetuado com sucesso!\n\tExibindo perfil");

                //Retorna a função que chama a pagina Index
                return RedirectToAction("Perfil", "Usuario");
            }
        }

        //Função que faz logout na sessão (desconecta o usuário)
        public IActionResult Logout()
        {
            //Limpa todos os dados da sessão (tipo Cookies)
            HttpContext.Session.Clear();

            //Exibe no console
            Console.WriteLine("\n\t-> Fazer logout");
            Console.WriteLine("\n\tLogout realizado com sucesso\n\tExibindo página incial");

            //Retorna a função que chama a pagina Index
            return RedirectToAction("Index", "Home");
        }

        //Função para editar um usuario no banco de dados
        public IActionResult Editar()
        {
            //Se não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Editar usuario");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando Login");
                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Recebe o Id do usuario logado
                int idUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");

                //Cria um objeto da classe que manipula o banco de dados
                UsuarioBD uBD = new UsuarioBD();

                //Busca o usuario que vai ser editado pelo Id
                Usuario usuario = uBD.BuscarPorId(idUsuario);

                //Exibe no console
                Console.WriteLine("\n\t-> Editar usuario");
                Console.WriteLine("\n\tUsuário logado\n\tExibindo página de edição");

                //Retorna o objeto usuario
                return View(usuario);
            }
        }

        //Função chamada ao enviar o formlario da pagina Editar
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            //Se não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Editar usuario");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando Login");
                
                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            //Cria um objeto da classe que manipula o banco de dados
            UsuarioBD uBD = new UsuarioBD();

            //Atualiza as informações no banco de dados
            uBD.Editar(usuario);

            //Grava as informações na sessão - (tipo Cookies)
            HttpContext.Session.SetInt32("IdUsuario", usuario.Id); //Id do usuario
            HttpContext.Session.SetString("NomeUsuario", usuario.Nome); //Nome do usuario
            HttpContext.Session.SetString("SobrenomeUsuario", usuario.Sobrenome); //Sobrenome do usuario
            HttpContext.Session.SetString("EmailUsuario", usuario.Email); //Email do usuario
            HttpContext.Session.SetString("LoginUsuario", usuario.Login); //Login do usuario

            //Exibe no console
            Console.WriteLine("\n\t-> Editar usuario");
            Console.WriteLine("\n\tUsuário editado\n\tExibindo página de perfil");
            
            //Retorna a função que chama a pagina Lista para atualizar as infos do usuario na listagem
            return RedirectToAction("Perfil", "Usuario");
        }

        //Função para excluir um usuario do banco de dados
        public IActionResult Excluir(int Id)
        {
            //Se não estiver logado
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                //Exibe no console
                Console.WriteLine("\n\t-> Excluir usuario");
                Console.WriteLine("\n\tUsuário não logado\n\tSolicitando Login");
                //Retorna a função que chama a pagina Login
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                //Recebe o Id do usuario logado
                int idUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");

                //Cria um objeto da classe que manipula o banco de dados
                UsuarioBD uBD = new UsuarioBD();

                //Busca o usuario que vai ser excluido pelo Id
                Usuario usuario = uBD.BuscarPorId(idUsuario);

                //Exclui o usuario no banco de dados
                uBD.Excluir(usuario);

                //Exibe no console
                Console.WriteLine("\n\t-> Excluir usuario");
                Console.WriteLine("\n\tUsuário excluído\n\tExibindo página inicial");
                //Retorna a função que chama a pagina Index
                return RedirectToAction("Index", "Home");
            }
        }


        //Função chamada ao abrir pagina Cadastro
        public IActionResult Cadastro()
        {
            //Exibe no console
            Console.WriteLine("\n\t-> Cadastrar usuario");
            Console.WriteLine("\n\tExibindo página de cadastro");
            //Retorna a View cadastro
            return View();
        }

        //Função chamada ao enviar o formlario da pagina Cadastro
        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            //Cria um objeto da classe que manipula o banco de dados
            UsuarioBD uBD = new UsuarioBD();

            //Converte DateTime em Date
            usuario.DataNascimento = usuario.DataNascimento.Date;

            //Insere o registro no banco de dados
            uBD.Inserir(usuario);
            
            //Mensagem de sucesso
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";

            //Exibe no console
            Console.WriteLine("\n\t-> Cadastrar usuario");
            Console.WriteLine("\n\tCadastro realizado com sucesso!\n\tSolicitando Login");            
            
            //Retorna a View login
            return RedirectToAction("Login", "Usuario");
        }
    }
}