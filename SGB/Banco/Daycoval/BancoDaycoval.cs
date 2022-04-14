
using BoletoBr.Arquivo.Generico.Retorno;
using BoletoBr.Bancos.Daycoval;
using BoletoBr.Dominio;

using BoletoBr.Enums;
using BoletoBr.Interfaces;
using BoletoNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGB.Banco.Daycoval
{
    public class BancoDaycoval : BoletoBr.Interfaces.IBanco
    {
        public string CodigoBanco { get; set; }
        public string DigitoBanco { get; set; }
        public string NomeBanco { get; set; }
        public Image LogotipoBancoParaExibicao { get; set; }
        public string LocalDePagamento { get; }
        public string MoedaBanco { get; }

      
        public BancoDaycoval()
        {
            CodigoBanco = "707";
            DigitoBanco = "2";
            NomeBanco = "Banco Daycoval";
            LocalDePagamento = "Pagável em qualquer banco até o vencimento.";
            MoedaBanco = "9";
        }










        public RetornoGenerico LerArquivoRetorno(List<string> linhasArquivo)
        {
            if (linhasArquivo == null || linhasArquivo.Any() == false)
                throw new ApplicationException("Arquivo informado é inválido/Não existem títulos no retorno.");

            /* Identifica o layout: 400 */
            if (linhasArquivo.First().Length == 400)
            {
                var leitor = new LeitorRetornoCnab400Daycoval(linhasArquivo);
                var retornoProcessado = leitor.ProcessarRetorno();

                var objRetornar = new RetornoGenerico(retornoProcessado);
                return objRetornar;
            }

            throw new Exception("Arquivo de RETORNO com " + linhasArquivo.First().Length + " posições, não é suportado.");
        }

        public int CodigoJurosMora(CodigoJurosMora codigoJurosMora)
        {
            throw new NotImplementedException();
        }

        public int CodigoProteso(bool protestar = true)
        {
            throw new NotImplementedException();
        }

        public ICodigoOcorrencia ObtemCodigoOcorrenciaByInt(int numeroOcorrencia)
        {
            throw new NotImplementedException();
        }
    }
}
