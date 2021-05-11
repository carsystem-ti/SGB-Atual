using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tranfereQuitacao
{
    public partial class Parcelas : Form
    {
        public Parcelas(string pedido, CarSystem.BancoDados.Dados dados,CarSystem.Debitos.Debito debito )
        {
            InitializeComponent();            
            //CarSystem.Debitos.Grid.carregaParcelas(pedido, CarSystem.Tipos.statusDebito.naoPagos);
        }

        private void Parcelas_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = new ComboBox();

            
        }
    }
}