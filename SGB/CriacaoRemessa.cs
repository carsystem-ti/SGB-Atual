using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geracaoRemessa.Formulario
{
    public partial class CriacaoRemessa : Form
    {
        CarSystem.Remessas.Remessa _remessa;
        CarSystem.Tipos.nomeBanco _banco;
        CarSystem.Tipos.empresas _empresa;
        string _nomeRemessa;

        public CriacaoRemessa( CarSystem.Remessas.Remessa remessa )
        {
            InitializeComponent();
            this._remessa = remessa ;
        }

        private void CriacaoRemessa_Load(object sender, EventArgs e)
        {
            int dia = 0;

            cbEmpresa.SelectedIndex = 0;
            cbBanco.SelectedIndex = 0;            
            dtInicioVencimento.Value = _remessa.ultimoVencimento().AddDays(1);

            dia = dtInicioVencimento.Value.AddDays(14).Day;

            if (dia > 15)
                dtFimVencimentos.Value = dtInicioVencimento.Value.AddMonths(1).AddDays(-(dtInicioVencimento.Value.AddMonths(1).Day));
            else
                dtFimVencimentos.Value = dtInicioVencimento.Value.AddDays(14);

            //dtFimVencimentos.Value = dtInicioVencimento.Value.AddDays(14);
            dtInicioVencimento.Enabled = false;
            atualizaInformacoes();
            lblTituloRemessa.Text = _nomeRemessa;
        }

        private void atualizaInformacoes()
        {
            if (cbBanco.Text == "Santander")
                _banco = CarSystem.Tipos.nomeBanco.Santander;
            else if(cbBanco.Text == "Safra")
                _banco = CarSystem.Tipos.nomeBanco.Safra;
            else
                _banco = CarSystem.Tipos.nomeBanco.Bradesco;

            if (cbEmpresa.Text == "CarSystem")
                _empresa = CarSystem.Tipos.empresas.CarSystem;
            else
                _empresa = CarSystem.Tipos.empresas.SatNet;

            _nomeRemessa = CarSystem.Remessas.Remessa.formaNomeRemessa(dtInicioVencimento.Value, dtFimVencimentos.Value, Convert.ToInt32(_banco), Convert.ToInt32(_empresa));

        }

        private void cmdIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                atualizaInformacoes();

                if (_remessa.criaRemessa(_banco, Convert.ToInt32(_empresa), _nomeRemessa, Environment.UserName,
                     Convert.ToInt32(nud_Parcelas.Value), dtInicioVencimento.Value, dtFimVencimentos.Value))
                {
                    MessageBox.Show("Remessa: " + _nomeRemessa + " criada com sucesso!!");
                    _remessa.passaEtapa();
                    CriacaoRemessa_Load(this, null);
                }
                else
                    MessageBox.Show("Falha ao criar remessa!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}