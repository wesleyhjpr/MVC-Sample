using Dapper;
using DevIO.Domain.Interfaces.Repositories;
using DevIO.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DevIO.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration Configuration;
        protected string ConnectionString { get; }
        public ClienteRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("StringConexao");
        }
        public List<Cliente> ObterTodos()
        {
            using IDbConnection _conexao = new SqlConnection(ConnectionString);
            string sql = "SELECT Id, Nome, Email, DataCadastro, Ativo FROM Cliente";

            return _conexao.Query<Cliente>(sql).ToList();
        }

        public Cliente ObterPorId(Guid id)
        {
            using IDbConnection _conexao = new SqlConnection(ConnectionString);
            string sql = "SELECT Id, Nome, Email, DataCadastro, Ativo FROM Cliente WHERE Id = @Id";

            return _conexao.QuerySingleOrDefault<Cliente>(sql, new { Id = id });
        }

        public Cliente ObterPorEmail(string email)
        {
            using IDbConnection _conexao = new SqlConnection(ConnectionString);
            string sql = "SELECT Id, Nome, Email, DataCadastro, Ativo FROM Cliente WHERE Email = @Email";

            return _conexao.QuerySingleOrDefault<Cliente>(sql, new { Email = email });
        }

        public int Adicionar(Cliente cliente)
        {
            using IDbConnection _conexao = new SqlConnection(ConnectionString);
            string sql = @"INSERT INTO Cliente (Id, Nome, Email, DataCadastro, Ativo) 
                            VALUES (@Id, @Nome, @Email, @DataCadastro, @Ativo)";

            return _conexao.Execute(sql, cliente);
        }

        public int Atualizar(Cliente cliente)
        {
            using IDbConnection _conexao = new SqlConnection(ConnectionString);
            string sql = @"UPDATE Cliente 
                        SET Id = @Id, 
                        Nome = @Nome, 
                        Email = @Email, 
                        Ativo = @Ativo
                        WHERE Id = @Id";

            return _conexao.Execute(sql, cliente);
        }

        public int Remover(Guid id)
        {
            using IDbConnection _conexao = new SqlConnection(ConnectionString);
            string sql = @"DELETE FROM Cliente WHERE Id = @Id";

            return _conexao.Execute(sql, new { Id = id });
        }
        public void Dispose() => GC.SuppressFinalize(this);

    }

}
