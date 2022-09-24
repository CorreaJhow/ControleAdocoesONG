using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAdocoesONG
{
    internal class ConBancoDados
    {
        string Conexao = "Data Source=localhost; Initial Catalog=ONG_Adocoes; User Id=sa; Password=12345;";
        public ConBancoDados()
        {

        }
        public string Caminho()
        {
            return Conexao;
        }
    }
}
