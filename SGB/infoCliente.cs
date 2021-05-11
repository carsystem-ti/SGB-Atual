using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geracaoRemessa.Formulario
{
    public partial class infoCliente : Form
    {
        CarSystem.BancoDados.Dados _dados;
        CarSystem.Remessas.Remessa _remessa;
        string _pedido = "";

        public infoCliente(string pedido, CarSystem.Interface.IDados dados, CarSystem.Remessas.Remessa remessa)
        {
            InitializeComponent();
            _dados = (CarSystem.BancoDados.Dados)dados;
            _pedido = pedido;
            _remessa = remessa;
        }

        private void infoCliente_Load(object sender, EventArgs e)
        {

            CarSystem.Cliente cliente = new CarSystem.Cliente(_dados);

            cliente.getCliente(_pedido);

            txtNome.Text = cliente.nome;
            txtPedido.Text = cliente.contrato;
            txtProduto.Text = cliente.produto;
            txtRenovacao.Text = cliente.renovacao.ToString("dd/MM/yyyy");
            txtUltimoVencimento.Text = cliente.ultimoVencimento.ToString("dd/MM/yyyy");

            cliente = null;

            _dados.retornaDados = true;
            _dados.Comandos.tipoComando = CommandType.StoredProcedure;

            _dados.Comandos.limpaParametros();

            _dados.Comandos.textoComando = "sgb..pro_SGB_getTodosDebitos";
            _dados.Comandos.adicionaParametro("@contrato",SqlDbType.VarChar,10,_pedido);
            _dados.Comandos.adicionaParametro("@codigoRemessa",SqlDbType.Int,4,_remessa.infoRemessa.codigoRemessa);

            _dados.execute();

            dgRemessa.DataSource = _dados.dsDados.Tables[0];
            dgDebitos.DataSource = _dados.dsDados.Tables[1];

        }
    }
}