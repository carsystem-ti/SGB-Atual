using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geracaoRemessa.Formulario
{
    public partial class InformacoesRemessa : Form
    {
        public CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados("SGB", CarSystem.Tipos.Servidores.Fury , "usr_sgb", "sgb_usr");
        private CarSystem.Remessas.Remessa remessa;

        public InformacoesRemessa()
        {
            remessa = new CarSystem.Remessas.Remessa(this.dados);
            InitializeComponent();
            
            //System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();

            //foreach (System.Reflection.AssemblyName an in a.GetReferencedAssemblies())
            
            //    MessageBox.Show(an.Name + an.Version.ToString());
        }

        private void InformacoesRemessa_Load(object sender, EventArgs e)
        {
            comboEmpresa.SelectedIndex = 0;
            this.Text = "Informações das Remessas " + Application.ProductVersion.ToString();
            preencheTree();
        }

        private void preencheTree()
        {

            System.Windows.Forms.TreeNode noTree;
            System.Windows.Forms.TreeNode noTree2;
            System.Data.DataSet ds;

            tvInformacoesRemessa.Nodes.Clear();

            ds = dados.execute("pro_SGB_informacoesRemessa",true);

            foreach ( System.Data.DataRow drLinha in ds.Tables[0].Rows)
            {
                
                noTree = new System.Windows.Forms.TreeNode( drLinha["codigoRemessa"].ToString().PadLeft(5, '0')
                                                                + "-" + drLinha["nomeRemessa"].ToString());
                noTree.Nodes.Add("Primeiro Vencimento: " + drLinha["dataInicioCobranca"].ToString());
                noTree.Nodes.Add("  Último Vencimento: " + drLinha["dataFimCobranca"].ToString());
                noTree.Nodes.Add("           Parcelas: " + drLinha["numeroParcelas"].ToString());
                noTree.Nodes.Add("        Iniciado em: " + drLinha["dataCriacao"].ToString());
                noTree.Nodes.Add("              Etapa: " + remessa.getDescricaoEtapa(Convert.ToInt32(drLinha["codigoEtapa"])));
                noTree.Nodes.Add("           Etapa em: " + drLinha["dataEtapa"].ToString());
                noTree.Nodes.Add("            Empresa: " + CarSystem.Empresa.nomeEmpresa(Convert.ToInt32(drLinha["codigoEmpresa"])));
                noTree.Name = drLinha["codigoRemessa"].ToString();
                

                if ((System.Int32)drLinha["codigoEtapa"] != (System.Int32)CarSystem.Tipos.etapasRemessa.finalizado)
                {
                    dados.Comandos.textoComando = "pro_SGB_resumoRemessa";
                    dados.Comandos.tipoComando = CommandType.StoredProcedure;

                    dados.Comandos.limpaParametros();
                    dados.Comandos.adicionaParametro("@codigoRemessa", SqlDbType.SmallInt, 2, drLinha["codigoRemessa"].ToString());

                    dados.execute();

                    noTree2 = new System.Windows.Forms.TreeNode("Números");

                    foreach (System.Data.DataRow drLinha2 in dados.dsDados.Tables[0].Rows)
                        noTree2.Nodes.Add(drLinha2["descricaoBloqueio"].ToString().PadRight(35, Convert.ToChar(" ")) + drLinha2["quantidade"].ToString().PadLeft(5, Convert.ToChar("0")));

                    noTree.Nodes.Add(noTree2);                    
                    noTree.Nodes[(noTree.Nodes.Count - 1)].ForeColor = Color.BlueViolet;
                    tvInformacoesRemessa.Nodes.Add(noTree);
                    tvInformacoesRemessa.Nodes[(tvInformacoesRemessa.Nodes.Count - 1)].ForeColor = Color.DarkRed;
                }
                else
                {
                    tvInformacoesRemessa.Nodes.Add(noTree);     
                    tvInformacoesRemessa.Nodes[(tvInformacoesRemessa.Nodes.Count - 1)].ForeColor = Color.DarkGreen;                    
                }                      
            }

            tvInformacoesRemessa.Refresh();

            noTree = null;
        }

        private void btnCriaRemessa_Click(object sender, EventArgs e)
        { new CriacaoRemessa(remessa).ShowDialog(this); }

        private void tvInformacoesRemessa_doubleClick(object sender, EventArgs e)
        {
            string nomeFuncao = "InformacoesRemessa.tvInformacoesRemessa_doubleClick";

            string caminhoArquivo;
            string mensagemRetorno;

            try
            {
                System.Int32 codigoRemessa = Convert.ToInt32(tvInformacoesRemessa.SelectedNode.FullPath.ToString().Split('-')[0]);

                remessa.getRemessa(codigoRemessa);

                CarSystem.Tipos.etapasRemessa etapa = CarSystem.Tipos.Converter.toEtapasRemessa(Convert.ToInt32(remessa[codigoRemessa].codigoEtapa));

                switch (etapa)
                {
                    case CarSystem.Tipos.etapasRemessa.processarBoletos:
                        new geracaoBoletos(remessa).ShowDialog(this);                        
                        break;
                    case CarSystem.Tipos.etapasRemessa.bloqueios:
                        new geracaoRemessa.Formulario.BloqueioBoletos(remessa).ShowDialog(this);
                        break;
                    case CarSystem.Tipos.etapasRemessa.arquivoRoterizacao:
                        remessa.passaEtapa();
                        break;
                    case CarSystem.Tipos.etapasRemessa.graficaRJ:

                        caminhoArquivo = @"C:\Remessas - Arquivos\" + remessa.infoRemessa.nomeRemessa;

                        mensagemRetorno = remessa.arquivoGrafica(caminhoArquivo + "_JURIDICA_PLUS_RJ.TXT", "PLUS", true, true);
                        mensagemRetorno = "\r\n" + remessa.arquivoGrafica(caminhoArquivo + "_JURIDICA_STD_RJ.TXT", "", true, true);
                        mensagemRetorno = "\r\n" + remessa.arquivoGrafica(caminhoArquivo + "_FISICA_PLUS_RJ.TXT", "PLUS", true, false);
                        mensagemRetorno = "\r\n" + remessa.arquivoGrafica(caminhoArquivo + "_FISICA_STD_RJ.TXT", "", true, false);

                        MessageBox.Show(mensagemRetorno);

                        remessa.passaEtapa();
                        break;

                    case CarSystem.Tipos.etapasRemessa.graficaECT:

                        caminhoArquivo = @"C:\Remessas - Arquivos\" + remessa.infoRemessa.nomeRemessa;

                        mensagemRetorno = remessa.arquivoGrafica(caminhoArquivo + "_JURIDICA_PLUS.TXT", "PLUS", false, true);
                        mensagemRetorno = "\r\n" + remessa.arquivoGrafica(caminhoArquivo + "_JURIDICA_STD.TXT", "", false, true);
                        mensagemRetorno = "\r\n" + remessa.arquivoGrafica(caminhoArquivo + "_FISICA_PLUS.TXT", "PLUS", false, false);
                        mensagemRetorno = "\r\n" + remessa.arquivoGrafica(caminhoArquivo + "_FISICA_STD.TXT", "", false, false);

                        MessageBox.Show(mensagemRetorno);

                        remessa.passaEtapa();
                        break;

                    case CarSystem.Tipos.etapasRemessa.graficaD2D:
                        remessa.passaEtapa();
                        break;
                    case CarSystem.Tipos.etapasRemessa.leituraBloqueios:
                        new geracaoRemessa.Formulario.BloqueioBoletos(remessa).ShowDialog(this);
                        break;
                    case CarSystem.Tipos.etapasRemessa.atualizaTabela:
                        new geracaoBoletos(remessa).ShowDialog(this);
                        break;
                    case CarSystem.Tipos.etapasRemessa.limpaTabela:
                        new geracaoBoletos(remessa).ShowDialog(this);
                        break;
                    case CarSystem.Tipos.etapasRemessa.finalizado:
                        break;
                }

                preencheTree();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }

        private void btn_etiqueta_Click(object sender, EventArgs e)
        {
        }

        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEmpresa.Text.ToUpper() == "CARSYSTEM")
                dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;

            if (comboEmpresa.Text.ToUpper() == "SATNET")
                dados.Conexoes.servidor = CarSystem.Tipos.Servidores.SatNetServer;

            dados.Conexoes.close();
            preencheTree();

        }

        private void tvInformacoesRemessa_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void InformacoesRemessa_FormClosed(object sender, FormClosedEventArgs e)
        {

            System.Windows.Forms.Form objForm;

            objForm = (System.Windows.Forms.Form)sender;

            objForm.Dispose();
            
        }

        private void InformacoesRemessa_Click(object sender, EventArgs e)
        {
            preencheTree();
        }


        
    }
}