using System;
using System.Collections.Generic;
//Importa a biblioteca MySql
using MySqlConnector;

namespace BrincalhoesKids.Models
{
    //Classe utilizada para manipulação dos itens do carrinho no banco de dados
    public class CarrinhoBD
    {
        //Credenciais do banco de dados
        private const string DadosConexao = "Database=BrincalhoesKids; Data Source=localhost; User Id=root";

        //Função que busca um item do carrinho por id
        public Carrinho BuscarPorId(int id)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para buscar registros da tabela
            String querySQL = "SELECT * FROM Carrinho WHERE Id=@Id";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection) - @Id recebe o Id do item do carrinho que deseja listar
            comandoSQL.Parameters.AddWithValue("@Id", id);

            //Executa o comando e recebe o resultado retornado do bando de dados
            MySqlDataReader readerSQL = comandoSQL.ExecuteReader();

            //Armazena o resultado no objeto do tipo Carrinho
            Carrinho itemEncontrado = new Carrinho();
            
            if (readerSQL.Read()){
                //Recebe o ID do item do carrinho
                itemEncontrado.Id = readerSQL.GetInt32("Id");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("IdProduto")))
                    //Recebe o produto do item encontrado
                    itemEncontrado.IdProduto = readerSQL.GetInt32("IdProduto");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Quantidade")))
                    //Recebe a quantidade do item encontrado
                    itemEncontrado.Quantidade = readerSQL.GetInt32("Quantidade");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("IdUsuario")))
                    //Recebe o usuario do item encontrado
                    itemEncontrado.IdUsuario = readerSQL.GetInt32("IdUsuario");
            }    
            //Fecha a conexão com o banco de dados
            Conexao.Close();

            //Retorna o item encontrado
            return itemEncontrado;
        }

        //Operações CRUD (Create, Read, Update, Delete) de manipulação de dados
        //Inserir/Criar (insert)
        public void Inserir(Carrinho item)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para Inserir registros da tabela
            String querySQL = "INSERT INTO Carrinho (IdProduto, Quantidade, IdUsuario) VALUES (@IdProduto, @Quantidade, @IdUsuario)";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection)
            comandoSQL.Parameters.AddWithValue("@IdProduto", item.IdProduto);
            comandoSQL.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            comandoSQL.Parameters.AddWithValue("@IdUsuario", item.IdUsuario);
            
            //Executa o comando no banco de dados
            comandoSQL.ExecuteNonQuery();
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();
        }
        
        //Listar/Exibir (select)
        public List<Carrinho> Listar()
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para Listar registros da tabela
            String querySQL = "SELECT * FROM Carrinho";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
                        
            //Executa o comando e recebe o resultado retornado do bando de dados
            MySqlDataReader readerSQL = comandoSQL.ExecuteReader();

            //Cria uma lista para armazenar os resgistros retornados do banco de dados
            List<Carrinho> lista = new List<Carrinho>();
            
            //Faz uma varredura nos registros retornados do bando de dados
            while (readerSQL.Read())
            {
                //Tranforma o registro do banco de dados em um objeto do tipo Carrinho
                Carrinho itemEncontrado = new Carrinho();
                
                //Recebe o ID do item d carrinho
                itemEncontrado.Id = readerSQL.GetInt32("Id");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("IdProduto")))
                    //Recebe o produto do item encontrado
                    itemEncontrado.IdProduto = readerSQL.GetInt32("IdProduto");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Quantidade")))
                    //Recebe a quantidade do item encontrado
                    itemEncontrado.Quantidade = readerSQL.GetInt32("Quantidade");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("IdUsuario")))
                    //Recebe o usuario do item encontrado
                    itemEncontrado.IdUsuario = readerSQL.GetInt32("IdUsuario");
                
                //Adiciona o item na listagem
                lista.Add(itemEncontrado);

            }
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();

            //Retorna a lista com os registros da tabela Carrinho do banco de dados
            return lista;
        }

        //Editar (update)
        public void Editar(Carrinho item)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para atualizar registros da tabela
            String querySQL = "UPDATE Carrinho set Quantidade=@Quantidade WHERE Id=@Id";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection)
            comandoSQL.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            comandoSQL.Parameters.AddWithValue("@Id", item.Id);

            //Executa o comando no banco de dados
            comandoSQL.ExecuteNonQuery();
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();
        }   
        
        //Excluir (delete)
        public void Excluir(Carrinho item)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para excluir da tabela
            String querySQL = "DELETE FROM Carrinho WHERE Id=@Id";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection) - @Id recebe o Id do item que deseja excluir
            comandoSQL.Parameters.AddWithValue("@Id", item.Id);
            
            //Executa o comando no banco de dados
            comandoSQL.ExecuteNonQuery();
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();
        }   
    }
}