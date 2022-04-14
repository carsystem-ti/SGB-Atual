
using BoletoBr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGB.Banco.Daycoval
{
    public static class   BancoFactory
    {
        public static IBanco ObterBanco(string codigoBanco, string digitoBanco = "")
        {
            try
            {
                switch (codigoBanco)
                {
                    /* 001 - Banco do Brasil */
                  
                    /* 707 - BANCO DAYCOVAL */
                    case "707":
                        return new BancoDaycoval();
                    /* 041 - BANCO BANRISUL */

                    default:
                        throw new NotImplementedException("Banco " + codigoBanco +
                                                          " ainda não foi implementado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a execução da transação.", ex);
            }
        }
    }
}
