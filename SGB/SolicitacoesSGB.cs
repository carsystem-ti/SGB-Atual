using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geracaoRemessa.Formulario
{
    public partial class SolicitacoesSGB : Form
    {

        CarSystem.SGB.Solicitacoes solicitacao;
        CarSystem.BancoDados.Dados _dados;

        private CarSystem.BancoDados.Dados dados
        {
            get
            {
                string nomeFuncao = "geraBoletos.Boletos.empresa_CheckedChanged";

                try
                {
                    if (_dados == null)
                    {
                        _dados = new CarSystem.BancoDados.Dados();
                        _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;

                        _dados.Conexoes.bancoDados = "principal";
                        _dados.Conexoes.usuario = "usr_sgb";
                        _dados.Conexoes.senha = "sgb_usr";
                    }

                    return _dados;
                }
                catch (Exception ex)
                {
                    throw new Exception("(" + nomeFuncao + ")" + ex.Message);
                }
            }
            set
            {
                _dados = value;
            }
        }

        public SolicitacoesSGB()
        {
            InitializeComponent();
        }

        public SolicitacoesSGB(CarSystem.BancoDados.Dados dados, string contrato, DateTime dataBase)
            : this()
        {
            solicitacao = new CarSystem.SGB.Solicitacoes(dados, contrato, dataBase);
            trackSolicitacoes.Value = 0;
        }
        public SolicitacoesSGB(CarSystem.BancoDados.Dados pDados, string pNumeroCcontrato, Int64 pCodigoSolicitacao)
            : this()
        {
            solicitacao = new CarSystem.SGB.Solicitacoes(pDados, pNumeroCcontrato);
            
            trackSolicitacoes.Value = getLocalizacaoCodigo(pCodigoSolicitacao);
            trackSolicitacoes_ValueChanged(null, null);
            trackSolicitacoes.ValueChanged += new EventHandler(trackSolicitacoes_ValueChanged);

        }

        private int getLocalizacaoCodigo(Int64 pCodigoSolicitacao)
        {
            for ( int iContador = 0; iContador < solicitacao.count; iContador++ )
                if ( solicitacao[iContador].codigoSolicitacao == pCodigoSolicitacao )
                    return iContador;

            throw new Exception("Código não encontrado!");
        }

        public SolicitacoesSGB(CarSystem.BancoDados.Dados pDados, Int64 pCodigoSolicitacao)
            : this()
        {
            solicitacao = new CarSystem.SGB.Solicitacoes(pDados, pCodigoSolicitacao);
        }

        private void SolicitacoesSGB_Load(object sender, EventArgs e)
        {
            try
            {
                trackSolicitacoes.Minimum = 0;
                trackSolicitacoes.Maximum = solicitacao.count - 1;
            }
            catch
            {
                this.Close();
            }             
        }

        private void SolicitacoesSGB_FormClosing(object sender, FormClosingEventArgs e)
        {
            solicitacao = null;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackSolicitacoes_ValueChanged(object sender, EventArgs e)
        {
            textAbertura.Text = solicitacao.dataSolicitacao.ToShortDateString();
            textContrato.Text = solicitacao.contrato;
            textStatusAtual.Text = solicitacao.descricaoStatus;

            txtSolicitacao.Text = solicitacao[trackSolicitacoes.Value].solicitacao;
            txtPendenteSGB.Text = solicitacao[trackSolicitacoes.Value].pendenteSGB;
            txtPendenteARB.Text = solicitacao[trackSolicitacoes.Value].pendenteARB;
            txtConclusão.Text = solicitacao[trackSolicitacoes.Value].conclusao;
        }
    }
}
