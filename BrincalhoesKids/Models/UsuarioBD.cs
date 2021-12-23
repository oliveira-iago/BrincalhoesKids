using System;
using System.Collections.Generic;
//Importa a biblioteca MySql
using MySqlConnector;

namespace BrincalhoesKids.Models
{
    //Classe utilizada para manipulação das informações do usuario no banco de dados
    public class UsuarioBD
    {
        //Credenciais do banco de dados
        private const string DadosConexao = "Database=BrincalhoesKids; Data Source=localhost; User Id=root";

        //Função que testa a conexão com o banco de dados
        public void TestarConexao()
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o banco de dados
            Conexao.Open();

            //Exibe uma mensagem indicando que conexão está ok
            Console.WriteLine("\n\tConexão com Banco de Dados: OK!");

            //Fecha a conexão aberta
            Conexao.Close();
        }

        //Função que verifica se o usuario está logado
        public Usuario ValidarLogin(Usuario usuario)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para buscar usuario por login e senha na tabela
            String querySQL = "SELECT * FROM Usuarios WHERE Login=@Login and Senha=@Senha";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection)
            comandoSQL.Parameters.AddWithValue("@Login", usuario.Login);
            comandoSQL.Parameters.AddWithValue("@Senha", usuario.Senha);

            //Executa o comando e recebe o resultado retornado do bando de dados
            MySqlDataReader readerSQL = comandoSQL.ExecuteReader();

            //objeto do tipo Usuario
            Usuario usuarioEncontrado = new Usuario();
            
            //Se o reader retornou um valor
            if (readerSQL.Read()){
                //Recebe o ID do usuario
                usuarioEncontrado.Id = readerSQL.GetInt32("Id");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Nome")))
                    //Recebe o nome do usuario encontrado
                    usuarioEncontrado.Nome = readerSQL.GetString("Nome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Sobrenome")))
                    //Recebe o sobrenome do usuario encontrado
                    usuarioEncontrado.Sobrenome = readerSQL.GetString("Sobrenome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Email")))
                    //Recebe o email do usuario encontrado
                    usuarioEncontrado.Email = readerSQL.GetString("Email");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Login")))
                    //Recebe o login do usuario encontrado
                    usuarioEncontrado.Login = readerSQL.GetString("Login");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Senha")))
                    //Recebe a senha do usuario encontrado
                    usuarioEncontrado.Senha = readerSQL.GetString("Senha");
                
                //Recebe a data de nascimento do usuario encontrado
                usuarioEncontrado.DataNascimento = readerSQL.GetDateTime("DataNascimento");
            }    
            //Fecha a conexão com o banco de dados
            Conexao.Close();

            //Retorna o usuario encontrado
            return usuarioEncontrado;
        }

        //Função que busca um usuario por id
        public Usuario BuscarPorId(int id)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para buscar registros por ID na tabela
            String querySQL = "SELECT * FROM Usuarios WHERE Id=@Id";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection) - @Id recebe o Id do usuario que deseja listar
            comandoSQL.Parameters.AddWithValue("@Id", id);

            //Executa o comando e recebe o resultado retornado do bando de dados
            MySqlDataReader readerSQL = comandoSQL.ExecuteReader();

            //Armazena o resultado no objeto do tipo Usuario
            Usuario usuarioEncontrado = new Usuario();
            
            if (readerSQL.Read()){
                //Recebe o ID do usuario
                usuarioEncontrado.Id = readerSQL.GetInt32("Id");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Nome")))
                    //Recebe o nome do usuario encontrado
                    usuarioEncontrado.Nome = readerSQL.GetString("Nome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Sobrenome")))
                    //Recebe o sobrenome do usuario encontrado
                    usuarioEncontrado.Sobrenome = readerSQL.GetString("Sobrenome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Email")))
                    //Recebe o email do usuario encontrado
                    usuarioEncontrado.Email = readerSQL.GetString("Email");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Login")))
                    //Recebe o login do usuario encontrado
                    usuarioEncontrado.Login = readerSQL.GetString("Login");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Senha")))
                    //Recebe a senha do usuario encontrado
                    usuarioEncontrado.Senha = readerSQL.GetString("Senha");
                
                //Recebe a data de nascimento do usuario encontrado
                usuarioEncontrado.DataNascimento = readerSQL.GetDateTime("DataNascimento");            
            }    
            //Fecha a conexão com o banco de dados
            Conexao.Close();

            //Retorna o usuario encontrado
            return usuarioEncontrado;
        }

        //Operações CRUD (Create, Read, Update, Delete) de manipulação de dados
        //Inserir/Criar (insert)
        public void Inserir(Usuario usuario)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para Inserir registros da tabela
            String querySQL = "INSERT INTO Usuarios (Nome, Sobrenome, Email, Login, Senha, DataNascimento) VALUES (@Nome, @Sobrenome, @Email, @Login, @Senha, @DataNascimento)";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection)
            comandoSQL.Parameters.AddWithValue("@Nome", usuario.Nome);
            comandoSQL.Parameters.AddWithValue("@Sobrenome", usuario.Sobrenome);
            comandoSQL.Parameters.AddWithValue("@Email", usuario.Email);
            comandoSQL.Parameters.AddWithValue("@Login", usuario.Login);
            comandoSQL.Parameters.AddWithValue("@Senha", usuario.Senha);
            comandoSQL.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
            
            //Executa o comando no banco de dados
            comandoSQL.ExecuteNonQuery();
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();
        }
        
        //Listar/Exibir (select)
        public List<Usuario> Listar()
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para Listar registros da tabela
            String querySQL = "SELECT * FROM Usuarios";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
                        
            //Executa o comando e recebe o resultado retornado do bando de dados
            MySqlDataReader readerSQL = comandoSQL.ExecuteReader();

            //Cria uma lista para armazenar os resgistros retornados do banco de dados
            List<Usuario> lista = new List<Usuario>();
            
            //Faz uma varredura nos registros retornados do bando de dados
            while (readerSQL.Read())
            {
                //Tranforma o registro do banco de dados em um objeto do tipo Usuario
                Usuario usuarioEncontrado = new Usuario();
                
                //Recebe o ID do usuario
                usuarioEncontrado.Id = readerSQL.GetInt32("Id");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Nome")))
                    //Recebe o nome do usuario encontrado
                    usuarioEncontrado.Nome = readerSQL.GetString("Nome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Sobrenome")))
                    //Recebe o sobrenome do usuario encontrado
                    usuarioEncontrado.Sobrenome = readerSQL.GetString("Sobrenome");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Email")))
                    //Recebe o email do usuario encontrado
                    usuarioEncontrado.Email = readerSQL.GetString("Email");
    
                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Login")))
                    //Recebe o login do usuario encontrado
                    usuarioEncontrado.Login = readerSQL.GetString("Login");

                //Recebe somente se as informações forem diferente de Nulo
                if (!readerSQL.IsDBNull(readerSQL.GetOrdinal("Senha")))
                    //Recebe a senha do usuario encontrado
                    usuarioEncontrado.Senha = readerSQL.GetString("Senha");
                
                //Recebe a data de nascimento do usuario encontrado
                usuarioEncontrado.DataNascimento = readerSQL.GetDateTime("DataNascimento");
                 
                //Adiciona o usuario na listagem
                lista.Add(usuarioEncontrado);

            }
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();

            //Retorna a lista com os registros da tabela Usuario do banco de dados
            return lista;
        }

        //Editar (update)
        public void Editar(Usuario usuario)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para atualizar registros da tabela
            String querySQL = "UPDATE Usuarios set Nome=@Nome, Sobrenome=@Sobrenome, Email=@Email, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento WHERE Id=@Id";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection)
            comandoSQL.Parameters.AddWithValue("@Nome", usuario.Nome);
            comandoSQL.Parameters.AddWithValue("@Sobrenome", usuario.Sobrenome);
            comandoSQL.Parameters.AddWithValue("@Email", usuario.Email);
            comandoSQL.Parameters.AddWithValue("@Login", usuario.Login);
            comandoSQL.Parameters.AddWithValue("@Senha", usuario.Senha);
            comandoSQL.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
            comandoSQL.Parameters.AddWithValue("@Id", usuario.Id);
            
            //Executa o comando no banco de dados
            comandoSQL.ExecuteNonQuery();
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();
        }   
        
        //Excluir (delete)
        public void Excluir(Usuario usuario)
        {
            //Informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //Abre uma conexão com o Banco de dados
            Conexao.Open();

            //Query em SQL para excluir da tabela
            String querySQL = "DELETE FROM Usuarios WHERE Id=@Id";
            
            //Prepara o comando (Query SQL + Conexão com o Banco de dados)
            MySqlCommand comandoSQL = new MySqlCommand(querySQL, Conexao);
            
            //Trata (devido ao SQL Injection) - @Id recebe o Id do usuario que deseja excluir
            comandoSQL.Parameters.AddWithValue("@Id", usuario.Id);
            
            //Executa o comando no banco de dados
            comandoSQL.ExecuteNonQuery();
            
            //Fecha a conexão com o banco de dados
            Conexao.Close();
        }   
    }
}