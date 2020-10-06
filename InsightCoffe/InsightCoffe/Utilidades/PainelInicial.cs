﻿using InsightCoffe.Entity;
using InsightCoffe.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsightCoffe.Utilidades
{
    public partial class PainelInicial : Form
    {
        private int childFormNumber = 0;

        public List<Produto> produtos = new List<Produto>();

        private Form1 Form1;
        public PainelInicial(Form1 form1, List<Usuarios> usuarios)
        {
            InitializeComponent();
            this.Form1 = form1;

            produtos.Add(new Produto()
            {
                ID = 1,
                Descricao = "Café",
                Quantidade = "100ml",
                Valor = 2
            });
            produtos.Add(new Produto()
            {
                ID = 2,
                Descricao = "Café",
                Quantidade = "180ml",
                Valor = 2.50
            });
            produtos.Add(new Produto()
            {
                ID = 3,
                Descricao = "Café",
                Quantidade = "280ml",
                Valor = 3
            });
            produtos.Add(new Produto()
            {
                ID = 4,
                Descricao = "Café c/ Leite",
                Quantidade = "180ml",
                Valor = 2.75
            });
            produtos.Add(new Produto()
            {
                ID = 5,
                Descricao = "Café c/ Leite",
                Quantidade = "280ml",
                Valor = 3.25
            });
            produtos.Add(new Produto()
            {
                ID = 6,
                Descricao = "Capuccino",
                Quantidade = "80ml",
                Valor = 2.10
            });
            produtos.Add(new Produto()
            {
                ID = 7,
                Descricao = "Capuccino",
                Quantidade = "180ml",
                Valor = 3.50
            });
            produtos.Add(new Produto()
            {
                ID = 8,
                Descricao = "Capuccino",
                Quantidade = "280ml",
                Valor = 5
            });
            produtos.Add(new Produto()
            {
                ID = 9,
                Descricao = "Macchiato",
                Quantidade = "180ml",
                Valor = 4
            });
            produtos.Add(new Produto()
            {
                ID = 10,
                Descricao = "Macchiato",
                Quantidade = "280ml",
                Valor = 5.50
            });
            produtos.Add(new Produto()
            {
                ID = 11,
                Descricao = "Café latte",
                Quantidade = "180ml",
                Valor = 4.25
            });
            produtos.Add(new Produto()
            {
                ID = 12,
                Descricao = "Café latte",
                Quantidade = "280ml",
                Valor = 5.75
            });
            produtos.Add(new Produto()
            {
                ID = 13,
                Descricao = "Mocha",
                Quantidade = "180ml",
                Valor = 4
            });
            produtos.Add(new Produto()
            {
                ID = 14,
                Descricao = "Mocha",
                Quantidade = "280ml",
                Valor = 5
            });
            produtos.Add(new Produto()
            {
                ID = 15,
                Descricao = "Naked",
                Quantidade = "180ml",
                Valor = 4.50
            });
            produtos.Add(new Produto()
            {
                ID = 16,
                Descricao = "Naked",
                Quantidade = "280ml",
                Valor = 5.50
            });
            produtos.Add(new Produto()
            {
                ID = 17,
                Descricao = "Bomba de chocolate",
                Quantidade = "Media",
                Valor = 4.50
            });
            produtos.Add(new Produto()
            {
                ID = 18,
                Descricao = "Donuts",
                Quantidade = "Grande",
                Valor = 3
            });
            produtos.Add(new Produto()
            {
                ID = 19,
                Descricao = "Cookie",
                Quantidade = "Pequeno",
                Valor = 2.50
            });
            produtos.Add(new Produto()
            {
                ID = 20,
                Descricao = "Torta d/ Limão",
                Quantidade = "Pedaço Mediano",
                Valor = 4
            });
            produtos.Add(new Produto()
            {
                ID = 21,
                Descricao = "Torta d/ Chocolate",
                Quantidade = "Pedaço Mediano",
                Valor = 4
            });
            produtos.Add(new Produto()
            {
                ID = 22,
                Descricao = "Esfirras Carne",
                Quantidade = "Media",
                Valor = 3.50
            });
            produtos.Add(new Produto()
            {
                ID = 23,
                Descricao = "Esfirras Frango",
                Quantidade = "Grande",
                Valor = 3.50
            });
            produtos.Add(new Produto()
            {
                ID = 24,
                Descricao = "Coxinha Frango",
                Quantidade = "Media",
                Valor = 3.50
            });
            produtos.Add(new Produto()
            {
                ID = 25,
                Descricao = "Coxinha c/ Catupiry",
                Quantidade = "Media",
                Valor = 3.50
            });
            produtos.Add(new Produto()
            {
                ID = 26,
                Descricao = "Coxinha Carne",
                Quantidade = "Media",
                Valor = 3.50
            });
            produtos.Add(new Produto()
            {
                ID = 27,
                Descricao = "Quibes",
                Quantidade = "Pequenos",
                Valor = 0.75
            });
            produtos.Add(new Produto()
            {
                ID = 28,
                Descricao = "Quibes",
                Quantidade = "Medio",
                Valor = 1.50
            });
            produtos.Add(new Produto()
            {
                ID = 29,
                Descricao = "Quibes",
                Quantidade = "Grande",
                Valor = 2.25
            });
        }
        //---------------------------------Informações personalizadas---------------------------------------
        public string user;
        public string acesso;

        private void PainelInicial_Load(object sender, EventArgs e)
        {
            //-------------------------------------Salvando o acesso-----------------------------------------
            user = Form1.user;
            acesso = Form1.acess;

            //-----------------------------------Codigo de acesso restrito------------------------------------
            lblUsuarioLogado.Text = Form1.user;
            toolStrip_lblusuario.Text = "Usuario logado: " + Form1.user;
            if (Form1.acess != "Total")
            {
                bntProdutos.Visible = false;
            }
        }

        //--------------------------------------Mover formulario--------------------------------------------
        Point DragCursor;
        Point DragForm;
        bool Dragging;
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }
        //-------------------------------------end-Mover formulario---------------------------------------

        //-------------------------------------------Minimizar, Maximizar e Fechar aplicação--------------
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar todo o Sistema, incuindo todas as telas abertas neste momento?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar todo o Sistema, incuindo todas as telas abertas neste momento?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void bntMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            bntMaximizar.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            bntMaximizar.Visible = true;
            btnNormal.Visible = false;
        }

        //Leave
        private void LeaveMinimizar(object sender, EventArgs e)
        {
            btnMinimizar.FlatAppearance.BorderColor = Color.DimGray;
        }
        private void LeaveMaximizar(object sender, EventArgs e)
        {
            bntMaximizar.FlatAppearance.BorderColor = Color.DimGray;
        }
        private void LeaveFechar(object sender, EventArgs e)
        {
            btnFechar.FlatAppearance.BorderColor = Color.DimGray;
        }
        private void LeaveNormal(object sender, EventArgs e)
        {
            btnNormal.FlatAppearance.BorderColor = Color.DimGray;
        }
        //Control
        private void controlFechar(object sender, MouseEventArgs e)
        {
            btnFechar.FlatAppearance.BorderColor = Color.Gray;
        }
        private void controlMaximizar(object sender, MouseEventArgs e)
        {
            bntMaximizar.FlatAppearance.BorderColor = Color.Gray;
        }
        private void controlMinimizar(object sender, MouseEventArgs e)
        {
            btnMinimizar.FlatAppearance.BorderColor = Color.Gray;
        }
        private void controlNormal(object sender, MouseEventArgs e)
        {
            btnNormal.FlatAppearance.BorderColor = Color.Gray;
        }


        //-----------------------------------------------------------------------------------------------

        //---------------------------start Sequencia de EVENTOS abertura das outras Telas-----------------
        private void bntVendas_Click(object sender, EventArgs e)
        {
            Tela_de_Vendas();
        }

        private void bntPagamento_Click_1(object sender, EventArgs e)
        {
            Tela_de_Pagamentos();
        }

        private void bntProdutos_Click(object sender, EventArgs e)
        {
            Tela_de_Produtos();
        }
        //-------------------------End Sequencia de EVENTOS abertura das outras Telas---------------------

        //---------------------------start Sequencia de EVENTOS abertura das outras Telas-----------------
        private void Tela_de_Vendas()
        {
            APSvendas apsPagamento = new APSvendas(this, produtos);
            apsPagamento.MdiParent = this;
            apsPagamento.Show();
        }

        private void Tela_de_Pagamentos()
        {
            APSpagamento apsPagamento = new APSpagamento();
            apsPagamento.MdiParent = this;
            apsPagamento.Show();
        }

        private void Tela_de_Produtos()
        {
            APSprodutos apsProdutos = new APSprodutos(this, produtos);
            apsProdutos.MdiParent = this;
            apsProdutos.Start = this;
            apsProdutos.Show();
        }
        //-------------------------End Sequencia de EVENTOS abertura das outras Telas---------------------

        //-----------------------------start APSprodutos LISTA de PRODUTOS---------------------------------       
        public void Adicionar_produto(double valor, string quantidade, string descricao, int codigo)
        {
            produtos.Add(new Produto()
            {
                ID = codigo,
                Descricao = descricao,
                Quantidade = quantidade,
                Valor = valor
            });
        }

        public void Editar_produto(double valor, string quantidade, string descricao, int codigo)
        {
            foreach (Produto produto in produtos)
            {
                if (codigo == produto.ID)
                {
                    produto.Descricao = descricao;
                    produto.Quantidade = quantidade;
                    produto.Valor = valor;
                }
            }
        }
        //------------------------------end APSprodutos LISTA de PRODUTOS----------------------------------

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }




        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}