using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geracaoRemessa.Formulario
{
    public partial class geracaoBoletos : Form
    {
        CarSystem.Remessas.Remessa remessa;
        System.Threading.Thread thProcesso;

        //delegate void setTextCallback(System.Windows.Forms.Label lbl, System.String value );
        //delegate void setStatusCallback(System.Windows.Forms.Button cmd, System.Boolean value );
        delegate void setPropertyCallBack(object obj, string nomePropriedade, object valor);

        public geracaoBoletos( CarSystem.Remessas.Remessa remessa )
        {
            this.remessa = remessa;
            InitializeComponent();

            reset(true);
            
            this.remessa.clienteProcessado += new CarSystem.Remessas.Remessa.geracaoRemessa(this.clienteProcessado );

        }
        private void clienteProcessado(CarSystem.Tipos.statusProcessamento status,System.Int32 quantidade )

        {
            switch (status)
            {
                case CarSystem.Tipos.statusProcessamento.efetuado:
                    setProperty( lbl_processados, "Text", Convert.ToString((Convert.ToInt32(lbl_processados.Text) + quantidade)).PadLeft(6, '0'));
                    setProperty( lbl_gerados, "Text", Convert.ToString((Convert.ToInt32(lbl_gerados.Text) + quantidade)).PadLeft(6, '0'));
                    break;
                case CarSystem.Tipos.statusProcessamento.recusado:
                    setProperty(lbl_processados, "Text", Convert.ToString((Convert.ToInt32(lbl_processados.Text) + quantidade)).PadLeft(6, '0'));
                    setProperty(lbl_eliminados, "Text", Convert.ToString((Convert.ToInt32(lbl_eliminados.Text) + quantidade)).PadLeft(6, '0')); 
                    break;
                case CarSystem.Tipos.statusProcessamento.selecionado:
                    setProperty(lbl_selecionados, "Text", quantidade.ToString().PadLeft(6, '0'));
                    break;
            }

            if ( lbl_processados.Text == lbl_selecionados.Text )
            {
                MessageBox.Show("Processamento concluído!");                
                setProperty(this, "Cursor", System.Windows.Forms.Cursors.Default);
                setProperty(btn_processar,"Text","&Processar");
                //this.Cursor = System.Windows.Forms.Cursors.Default;
                //btn_processar.Text = "&Processar";
                //remessa.passaEtapa();
            }
        }
       
        private void geracaoBoletos_Load(object sender, EventArgs e)
        {
        }

        private void btn_processar_Click(object sender, EventArgs e)
        {            
            CarSystem.Tipos.etapasRemessa etapa = (CarSystem.Tipos.etapasRemessa)remessa.infoRemessa.codigoEtapa;
            
            if (thProcesso != null && thProcesso.IsAlive)
            {
                if (MessageBox.Show("Cancelar processo?", "Cancelar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    thProcesso.Abort();

                return;
            }

            reset(true);

            switch (etapa)
            {
                case CarSystem.Tipos.etapasRemessa.processarBoletos:
                    {
                        if (!remessa.infoRemessa.isLiberada)
                        {
                            new SGB.acertoValores(remessa).ShowDialog(this);
                        }
                        else
                        {
                            if (MessageBox.Show("Iniciar a geração dos boletos?", "Iniciar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                                thProcesso = new System.Threading.Thread(new System.Threading.ThreadStart(geraBoleto));
                                thProcesso.Start();
                            }
                        }
                        break;
                    }
                case CarSystem.Tipos.etapasRemessa.limpaTabela:
                    if (MessageBox.Show("Iniciar a limpeza da tabela?", "Iniciar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        thProcesso = new System.Threading.Thread(new System.Threading.ThreadStart(limpezaTabela));
                        thProcesso.Start();
                    }
                    break;
                case CarSystem.Tipos.etapasRemessa.atualizaTabela:
                    if (MessageBox.Show("Iniciar a atualizacao da tabela?", "Iniciar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        thProcesso = new System.Threading.Thread(new System.Threading.ThreadStart(atualizarTabela));
                        thProcesso.Start();
                    }
                    break;
            }

            if (remessa.infoRemessa.isLiberada)
                btn_processar.Text = "&Cancelar";
        }

        private void geraBoleto()
        {
            string nomeFuncao = "geracaoBoletos.geraBoleto";

            try
            {
                
                remessa.geraBoleto();
                reset(false);
            }
            catch(Exception ex)
            {
                 MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }

        }
        private void limpezaTabela()
        {
            remessa.limpezaTabela();
            reset(false);
        }
        private void atualizarTabela()
        {
            remessa.atualizarTabela();
            reset(false);
        }

        public void reset(bool isGeral)
        {
            if (isGeral)
            {
                setProperty(lbl_processados, "Text", "".PadLeft(6, '0'));
                setProperty(lbl_eliminados, "Text", "".PadLeft(6, '0'));
                setProperty(lbl_selecionados, "Text", "".PadLeft(6, '0'));
            }
            setProperty(this, "Cursor", System.Windows.Forms.Cursors.Default);
            setProperty(btn_processar, "Text", "&Processar");
            setProperty(btn_processar, "Enabled", true);
        }

        //private void setTexto(System.Object lbl, System.String value)
        //{
        //    setTextCallback setText;

        //    if ( lbl.InvokeRequired )
        //    {
        //        setText = new setTextCallback(setTexto);
        //        this.Invoke(setText, new Object[] {lbl, value});
        //    }
        //    else
        //    {
        //        lbl.Text = value;
        //    }
        //}
        //private void setStatusBotao( System.Windows.Forms.Button cmd, System.Boolean value )
        //{
        //    setStatusCallback setStatus;

        //    if ( cmd.InvokeRequired ) 
        //    {
        //        setStatus = new setStatusCallback(setStatusBotao);
        //        this.Invoke(setStatus, new Object[] {cmd, value});
        //    }
        //    else
        //    {
        //        cmd.Enabled = value;
        //    }
        
        //}

        private void setProperty(object obj, string nomePropriedade, object valor)
        {
            setPropertyCallBack setProperty = new setPropertyCallBack(this.setProperty);;

            System.Reflection.PropertyInfo propriedade = obj.GetType().GetProperty(nomePropriedade);

            bool invoke = (bool)obj.GetType().GetProperty("InvokeRequired").GetValue(obj,null);

            if (invoke)
                this.Invoke(setProperty, new Object[] { obj, nomePropriedade, valor });
            else
                propriedade.SetValue(obj, valor, null);
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Passar para a próxima etapa?", "Etapa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                remessa.passaEtapa();
        }

    }
}