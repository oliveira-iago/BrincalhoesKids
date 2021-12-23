using System;

namespace BrincalhoesKids.Models
{
    //Classe Produto
    public class Produto
    {
        //Atributos do  produto
        public int Id {get; set;} //Id identificador
        public string Nome {get; set;} //Nome do produto
        public string Descricao {get; set;} //Descrição do produto
        public double Valor {get; set;} //Valor do produto
    }
}