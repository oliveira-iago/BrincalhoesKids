using System;
using System.Collections.Generic;
//Importa a biblioteca MySql
using MySqlConnector;

namespace BrincalhoesKids.Models
{
    //Classe utilizada para manipulação das informações do produto no banco de dados
    public class ProdutoBD
    {
        //Credenciais do banco de dados
        private const string DadosConexao = "Database=BrincalhoesKids; Data Source=localhost; User Id=root";

        //Função que busca um produto por id
        public Produto BuscarPorId(int id)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para buscar registros por ID na tabela
            String querySQL = "SELECT * FROM Produtos WHERE Id=@Id";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection) - @Id recebe o Id do produto que deseja listar
            comandoSQL.Parameters.AddWithValue("@Id", id);

            //Executa o comando e recebe o resultado retornado do bando de dados
            MySqlDataReader readerSQL = comandoSQL.ExecuteReader();

            //Armazena o resultado no objeto do tipo produto
            Produto produtoEncontrado = new Produto();
            
            if (readerSQL.Read()){
                //Recebe o ID do produto
                produtoEncontrado.Id = readerSQL.GetInt32("Id");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Nome")))
                    //Recebe o nome do produto encontrado
                    produtoEncontrado.Nome = readerSQL.GetString("Nome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Descricao")))
                    //Recebe a descrição do produto encontrado
                    produtoEncontrado.Descricao = readerSQL.GetString("Descricao");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Valor")))
                    //Recebe o valor do produto encontrado
                    produtoEncontrado.Valor = readerSQL.GetDouble("Valor");
            }    
            //Fecha a conexão com o banco de dados
            Conexao.Close();

            //Retorna o usuario encontrado
            return produtoEncontrado;
        }

        //Listar/Exibir (select)
        public List<Produto> Listar()
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para Listar registros da tabela
            String querySQL = "SELECT * FROM Produtos";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
                        
            //Executa o comando e recebe o resultado retornado do bando de dados
            MySqlDataReader readerSQL = comandoSQL.ExecuteReader();

            //Cria uma lista para armazenar os resgistros retornados do banco de dados
            List<Produto> lista = new List<Produto>();
            
            //Faz uma varredura nos registros retornados do bando de dados
            while (readerSQL.Read())
            {
                //Tranforma o registro do banco de dados em um objeto do tipo Produto
                Produto itemEncontrado = new Produto();
                
                //Recebe o ID do Produto
                itemEncontrado.Id = readerSQL.GetInt32("Id");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Nome")))
                    //Recebe o nome do item encontrado
                    itemEncontrado.Nome = readerSQL.GetString("Nome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Descricao")))
                    //Recebe a descrição do item encontrado
                    itemEncontrado.Descricao = readerSQL.GetString("Descricao");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Valor")))
                    //Recebe o Valor do item encontrado
                    itemEncontrado.Valor = readerSQL.GetDouble("Valor");
                
                //Adiciona o pacote na listagem
                lista.Add(itemEncontrado);

            }
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();

            //Retorna a lista com os registros da tabela PacotesTuristicos do banco de dados
            return lista;
        }
    }
}