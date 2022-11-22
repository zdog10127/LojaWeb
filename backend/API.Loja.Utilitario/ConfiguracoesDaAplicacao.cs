using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Utilitario
{
    public class ConfiguracoesDaAplicacao
    {
        public static string ObterStringDeConexaoBanco()
        {
            Configuracao configuracao = new Configuracao();
            return configuracao.ConfiguracoesDoAppsettings["ConnectionStringMySQL:DatabaseConnectionString"];
        }
    }
}
