using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAdocoesONG
{
    internal class ConBancoDados
    {
        string Conexao = "Data Source=localhost; Initial Catalog=ONG_Adocoes; User Id=sa; Password=12345;";
        SqlConnection conn;
        public ConBancoDados()
        {
            conn = new SqlConnection(Conexao);
        }
        public string Caminho()
        {
            return Conexao;
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            conn.Open();
            string sql = "insert into Pessoa(Nome, CPF, Sexo, DataNascimento, Telefone, Rua, Cidade, Bairro, SiglaEstado, Numero) values" +
                "('" + pessoa.Nome + "', '" + pessoa.CPF + "', '" + pessoa.Sexo + "', '" + pessoa.DataNascimento + "', '" + pessoa.Telefone +
                "', '" + pessoa.Rua + "', '" + pessoa.Cidade + "', '" + pessoa.Bairro + "', '" + pessoa.SiglaEstado + "', '" + pessoa.Numero + "');";
            Console.WriteLine(sql);
            Console.ReadKey();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
        }

    }
}
