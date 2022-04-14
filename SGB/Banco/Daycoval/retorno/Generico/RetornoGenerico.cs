using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BoletoBr.Dominio;
using SGB.Banco;
using SGB.Banco.Daycoval;

namespace BoletoBr.Arquivo.Generico.Retorno
{
    public class RetornoGenerico
    {
        public void Inicializa()
        {
            Header = new RetornoHeaderGenerico();
            RegistrosDetalhe = new List<RetornoDetalheGenerico>();
            Trailer = new RetornoTrailerGenerico();
        }

      

        public RetornoGenerico(RetornoCnab400 retornoCnab400)
        {
            Inicializa();
            RetornoCnab400Especifico = retornoCnab400;

            /* Transformar de CNAB400 para formato genérico */
            Header.CodigoDoBanco = retornoCnab400.Header.CodigoDoBanco;
            Header.Convenio = retornoCnab400.Header.NumeroConvenio.ToString(CultureInfo.InvariantCulture);
            Header.CodigoAgencia = retornoCnab400.Header.CodigoAgenciaCedente.ToString(CultureInfo.InvariantCulture);
            Header.DvAgencia = retornoCnab400.Header.DvAgenciaCedente;
            Header.NumeroConta = retornoCnab400.Header.ContaCorrente;
            Header.DvConta = retornoCnab400.Header.DvContaCorrente;
            Header.NomeEmpresa = retornoCnab400.Header.NomeDoBeneficiario;
            Header.NomeDoBanco = retornoCnab400.Header.NomeDoBanco;
            Header.NumeroInscricaoEmpresa =
                retornoCnab400.RegistrosDetalhe.FirstOrDefault()?.IdentificacaoEmpresaNoBanco;

            foreach (var registroAtual in retornoCnab400.RegistrosDetalhe)
            {
                var banco = SGB.Banco.Daycoval.BancoFactory.ObterBanco(Header.CodigoDoBanco);
                var ocorrencia = banco.ObtemCodigoOcorrenciaByInt(registroAtual.CodigoDeOcorrencia);
                var detalheGenericoAdd = new RetornoDetalheGenerico
                {
                    NossoNumero = registroAtual.NossoNumero,
                    TipoCobranca = registroAtual.TipoCobranca.ToString(CultureInfo.InvariantCulture),
                    Carteira = registroAtual.CodigoCarteira,
                    PercentualDesconto = registroAtual.TaxaDesconto,
                    PercentualIof = registroAtual.TaxaIof,
                    Especie = registroAtual.Especie,
                    DataCredito = registroAtual.DataDeCredito,
                    DataOcorrencia = registroAtual.DataDaOcorrencia,
                    DataVencimento = registroAtual.DataDeVencimento,
                    DataLiquidacao = registroAtual.DataLiquidacao,
                    NumeroDocumento = registroAtual.NumeroDocumento,
                    SeuNumero = registroAtual.SeuNumero,
                    ValorDocumento = registroAtual.ValorDoTituloParcela,
                    ValorTarifaCustas = registroAtual.ValorTarifa,
                    ValorOutrasDespesas = registroAtual.ValorOutrasDespesas,
                    ValorJurosDesconto = registroAtual.ValorJurosDesconto,
                    ValorIofDesconto = registroAtual.ValorIofDesconto,
                    ValorAbatimento = registroAtual.ValorAbatimento,
                    ValorDesconto = registroAtual.ValorDesconto,
                    ValorRecebido = registroAtual.ValorLiquidoRecebido + registroAtual.ValorDoDebitoCredito,
                    ValorAcrescimos = registroAtual.ValorJurosDeMora + registroAtual.ValorMulta + registroAtual.ValorTarifa,
                    ValorJuros = registroAtual.ValorJurosDeMora,
                    ValorMulta = registroAtual.ValorMulta,
                    ValorOutrosRecebimentos = registroAtual.ValorOutrosRecebimentos,
                    ValorAbatimentoNaoAproveitadoPeloSacado = registroAtual.ValorAbatimentosNaoAproveitado,
                    ValorLancamento = registroAtual.ValorLancamento,
                    InscricaoSacado = registroAtual.NumeroInscricaoSacado.ToString(CultureInfo.InvariantCulture),
                    NomeSacado = registroAtual.NomeSacado,
                    CodigoOcorrencia = String.IsNullOrEmpty(registroAtual.MotivoCodigoOcorrencia) ? "00" : registroAtual.MotivoCodigoOcorrencia,
                    MensagemOcorrenciaRetornoBancario = ocorrencia.Descricao,
                    Ocorrencia = ocorrencia,
                    NumeroConvenio = registroAtual.NumeroConvenio
                };

                //DATA LIQUIDAÇÃO E DATA OCORRENCIA
                if (detalheGenericoAdd.Pago && detalheGenericoAdd.DataLiquidacao == DateTime.MinValue)
                    detalheGenericoAdd.DataLiquidacao = registroAtual.DataDaOcorrencia;

                RegistrosDetalhe.Add(detalheGenericoAdd);
            }
        }
        
        public RetornoHeaderGenerico Header { get; set; }
        public List<RetornoDetalheGenerico> RegistrosDetalhe { get; set; } 
        public RetornoTrailerGenerico Trailer { get; set; }
        public RetornoCnab400 RetornoCnab400Especifico { get; set; }
    }
}
