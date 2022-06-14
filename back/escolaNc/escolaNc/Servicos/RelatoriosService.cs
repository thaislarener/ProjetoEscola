using escolaNc.Data;
using escolaNc.Excecoes;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace escolaNc.Servicos
{
    public class RelatoriosService : IRelatoriosService
    {
        private readonly IAcessoBD _acesso;
        public RelatoriosService(IAcessoBD acesso)
        {
            _acesso = acesso;
        }
        public List<RelFaturamento> ServicosContratados()
        {

            var retorno = new List<RelFaturamento>();

            DataTable dt = _acesso.ExecutaProc("dbo.REL_SERVICOS_CONTRATADOS");

            foreach (DataRow r in dt.Rows)
            {
                retorno.Add(new RelFaturamento
                {
                    ID_SERVICO = int.Parse(r.ItemArray[0].ToString()),
                    DESCRICAO = r.ItemArray[1].ToString(),
                    ASSINANTES = int.Parse(r.ItemArray[2].ToString()),
                    VALOR = decimal.Parse(r.ItemArray[3].ToString()),
                    FATURAMENTO = decimal.Parse(r.ItemArray[4].ToString()),
                });
            }
            return retorno;
        }
        public string Inadimplentes(string cpf)
        {
            SqlParameter Parametros = new SqlParameter();
            Parametros.ParameterName = "@CPF";
            Parametros.Value = cpf;
            Parametros.SqlDbType = SqlDbType.NVarChar;

            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(cpf))
                dt = _acesso.ExecutaProc("dbo.RETORNA_INADIMPLENTES");
            else
                dt = _acesso.ExecutaProc("dbo.RETORNA_INADIMPLENTES", Parametros);

            string JSONString = string.Empty;

            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }
    }
}
