using System;   
namespace BrincalhoesKids.Models
{
    //Classe Usuario
    public class Usuario
    {
        //Atributos do Usuario
        public int Id {get; set;} //Id identificador
        public string Nome {get; set;} //Nome do usuario
        public string Sobrenome {get; set;} //Sobrenome do usuario
        public string Email {get; set;} //Email do usuario
        public string Login {get; set;} //Login do usuario
        public string Senha {get; set;} //Senha do usuario
        public DateTime DataNascimento {get; set;}  //Data de nascimento   
    }
}