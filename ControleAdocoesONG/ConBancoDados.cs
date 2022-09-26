using System;
using System.Data.SqlClient;
using System.Linq;


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
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Dados inseridos com sucesso!");
            Console.WriteLine("Aperte alguma tecla para prosseguir...");
            Console.ReadKey();
            conn.Close();
        }
        public void InserirAnimal(Animal animal)
        {
            conn.Open();
            string sql = "insert into Animal(CHIP, Familia, Raca, Sexo, Nome) values (" + animal.Chip + ", '" + animal.Familia + "', '" + animal.Raca + "', '" + animal.Sexo + "', '" + animal.Nome + "');";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Dados inseridos com sucesso!");
            Console.ReadKey();
            conn.Close();
        }
        public void InserirAdocao()
        {
            try
            {
                conn.Open();
                int NumeroRegistro = NumeroRandom();
                Console.WriteLine("Informe o CPF do adotante: ");
                string Adotante = Console.ReadLine(); //verificação pra ver se existe no BD (SELECT)
                Console.WriteLine("Informe o Numero de registro (CHIP) do animal adotado: ");
                int Adotado = int.Parse(Console.ReadLine());  //verificação pra ver se existe no BD (SELECT)
                string sql = "insert into RegistroAdocao(NumeroRegistro, Adotante, Adotado) values (" + NumeroRegistro + ", '" + Adotante + "', " + Adotado + ");";
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Dados inseridos com sucesso!");
                Console.WriteLine("Aperte alguma tecla para prosseguir...");
                Console.ReadKey();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Os registro inseridos não estão cadastrados em nossobanco de dados!");
                Console.WriteLine("Pressione alguma tecla para prosseguir...");
                Console.ReadKey();
                throw;
            }

        }
        public static int NumeroRandom()
        {
            Random rand = new Random();
            int[] numero = new int[100];
            int aux = 0;
            for (int k = 0; k < numero.Length; k++)
            {
                int rnd = 0;
                do
                {
                    rnd = rand.Next(1000, 9999);
                } while (numero.Contains(rnd));
                numero[k] = rnd;
                aux = numero[k];
            }
            return aux;
        }
        public int AtualizarTabela(string sql)
        {
            int row = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                row = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro código " + e.Number + "Contate o administrador");
            }
            return row;
        }
        public void SelectPessoa(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();
                if (!r.HasRows)
                {
                    Console.WriteLine("Usuário não localizado! \nOperação cancelada.");
                    conn.Close();
                    Console.WriteLine("Pressione uma tecla para prosseguir...");
                    Console.ReadKey();
                }
                else
                {
                    while (r.Read())
                    {
                        Console.WriteLine($"Nome: {r.GetString(0)}");
                        Console.WriteLine($"CPF: {r.GetString(1)}");
                        Console.WriteLine($"Sexo: {r.GetString(2)}");
                        Console.WriteLine($"Tel: {r.GetString(3)}");
                        Console.WriteLine($"Estado: {r.GetString(4)}");
                        Console.WriteLine($"Data de nascimento: {r.GetString(5)}");
                        Console.WriteLine();
                    }
                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro código " + e.Number + "Contate o administrador");
            }
            Console.WriteLine("Pressione alguma tecla para prosseguir...");
            Console.ReadKey();
        }
        public void SelectAnimal(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();
                if (!r.HasRows)
                {
                    Console.WriteLine("Pet não localizado...");
                    Console.WriteLine("Pressione uma tecla para prosseguir...");
                    Console.ReadKey();
                    conn.Close();
                }
                while (r.Read())
                {
                    Console.WriteLine($"Chip de Identificação: {r.GetInt32(0)}");
                    Console.WriteLine($"Familia: {r.GetString(1)}");
                    Console.WriteLine($"Raça: {r.GetString(2)}");
                    Console.WriteLine($"Sexo: {r.GetString(3)}");
                    Console.WriteLine($"Nome: {r.GetString(4)}");
                    Console.WriteLine();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro código " + e.Number + "Contate o administrador");
            }
            conn.Close();
            Console.WriteLine("Pressione alguma tecla para prosseguir...");
            Console.ReadKey();
        }
        public void SelectAdocoes(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();
                if (!r.HasRows)
                {
                    Console.WriteLine("Nao localizamos adocoes...");
                    Console.WriteLine("Pressione uma tecla para prosseguir...");
                    Console.ReadKey();
                    conn.Close();
                }
                while (r.Read())
                {
                    Console.WriteLine($"Numero de Registro: {r.GetInt32(0)}");
                    Console.WriteLine($"Adotante: {r.GetString(1)}");
                    Console.WriteLine($"Adotado: {r.GetInt32(2)}");
                    Console.WriteLine();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro código " + e.Number + "Contate o administrador");
            }
            conn.Close();
            Console.WriteLine("Pressione alguma tecla para prosseguir...");
            Console.ReadKey();
        }
    }
}
