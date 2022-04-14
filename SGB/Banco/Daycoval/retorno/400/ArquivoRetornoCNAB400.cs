using System.Collections.Generic;
using BoletoBr.Arquivo.Generico.Retorno;
using BoletoBr.Dominio;
using BoletoBr.Interfaces;
using BoletoNet;
using TipoArquivo = BoletoBr.Dominio.TipoArquivo;

namespace BoletoBr.Arquivo.CNAB400.Retorno
{
    public class ArquivoRetornoCnab400 : Interfaces.IArquivoRetorno
    {
        public Interfaces.IBanco Banco { get; set; }
        public TipoArquivo TipoArquivo { get; private set; }

        public List<RetornoDetalheGenerico> ListaDetalhe { get; set; }


        #region Construtores

        public ArquivoRetornoCnab400()
        {
            ListaDetalhe = new List<RetornoDetalheGenerico>();
            TipoArquivo = TipoArquivo.Cnab400;
        }

        #endregion
    }
}
