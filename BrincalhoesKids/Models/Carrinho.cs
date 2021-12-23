using System;
namespace BrincalhoesKids.Models
{
    //Classe PacotesTuristicos
    public class Carrinho
    {
        //Atributos do Pacote
        public int Id {get; set;} //Id identificador do item do carrinho
        public int IdProduto {get; set;} //Id identificador do produto
        public int Quantidade {get; set;} //Quantidade adicionada no carrinho
        public int IdUsuario {get; set;} //Usuario que adicionou o produto no carrinho
    }
}