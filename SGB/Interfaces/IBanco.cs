using System;
using System.Collections.Generic;
using System.Drawing;
using BoletoBr.Arquivo.Generico.Retorno;
using BoletoBr.Enums;
using BoletoNet;

namespace BoletoBr.Interfaces
{
    public interface IBanco
    {
        string CodigoBanco { get; set; }
        string DigitoBanco { get; set; }
        string NomeBanco { get; set; }
        Image LogotipoBancoParaExibicao { get; set; }
        string LocalDePagamento { get; }
        string MoedaBanco { get; }
        ICodigoOcorrencia ObtemCodigoOcorrenciaByInt(int numeroOcorrencia);

        //List<CarteiraCobranca> GetCarteirasCobranca();
        //CarteiraCobranca GetCarteiraCobrancaPorCodigo(string codigoCarteira);

        /// <summary>
        /// Faz a leitura do arquivo de retorno.
        /// </summary>
        /// <param name="linhasArquivo">Linhas do arquivo que será processado</param>
        RetornoGenerico LerArquivoRetorno(List<string> linhasArquivo);
        int CodigoJurosMora(CodigoJurosMora codigoJurosMora);
        int CodigoProteso (bool protestar = true);
    }
}
