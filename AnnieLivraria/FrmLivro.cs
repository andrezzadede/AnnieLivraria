using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnnieLivraria.Camadas;

namespace AnnieLivraria
{
    public partial class FrmLivro : Form
    {
        public FrmLivro()
        {
            InitializeComponent();
        }

        private void Habilitar(bool status)
        {

            txtNome.Enabled = status;
            txtAutor.Enabled = status;
            txtDatL.Enabled = status;
            txtValor.Enabled = status;

            //botões
            bntCadastrar.Enabled = status;
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnRemover.Enabled = !status;
            btnSair.Enabled = status;
           
        }

        private void limparCampos()
        {
            lblid.Text = "";
            txtNome.Text = "";
            txtAutor.Text = "";
            txtDatL.Text = "";
            txtValor.Text = "";
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparCampos();
            Habilitar(false);
        }

        private void dgvLivro_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLivro.SelectedRows.Count > 0)
            {
                lblid.Text = dgvLivro.SelectedRows[0].Cells["id"].Value.ToString();
                txtNome.Text = dgvLivro.SelectedRows[0].Cells["Nome"].Value.ToString();
                txtAutor.Text = dgvLivro.SelectedRows[0].Cells["Autor"].Value.ToString();
                txtDatL.Text = dgvLivro.SelectedRows[0].Cells["DataLancamento"].Value.ToString();
                txtValor.Text = dgvLivro.SelectedRows[0].Cells["Valor"].Value.ToString();
   

            }
        }

        private void dgvLivro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmLivro_Load(object sender, EventArgs e)
        {
            Camadas.BLL.Livro bllLivro = new Camadas.BLL.Livro();
            dgvLivro.DataSource = bllLivro.Select();
            Habilitar(false);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            limparCampos();
            lblid.Text = "-1";
            Habilitar(true);
            txtNome.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblid.Text != string.Empty)
            {
                Habilitar(true);
                txtNome.Focus();
            }
            else
            {
                string msg = "Não há Registro para edição...";
                MessageBox.Show(msg, "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string msg;
            if (lblid.Text != string.Empty)
            {
                msg = "Confirma Remoção do Livro " + txtNome.Text + "?";
                DialogResult resp;
                resp = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resp == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(lblid.Text);
                    Camadas.BLL.Livro bllLivro = new Camadas.BLL.Livro();
                    Camadas.Model.Livro livro = new Camadas.Model.Livro();
                     livro.id = id;
                    // informar outros campos caso necessite no bll
                    bllLivro.Delete(livro);
                    dgvLivro.DataSource = "";
                    dgvLivro.DataSource = bllLivro.Select();
                }
            }
            else
            {
                msg = "Não há registro para remoção...";
                MessageBox.Show(msg, "Remover", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limparCampos();
            Habilitar(false);
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            Camadas.BLL.Livro bllLivro = new Camadas.BLL.Livro();
            Camadas.Model.Livro livro = new Camadas.Model.Livro();
            int id = Convert.ToInt32(lblid.Text);

            string msg = "";
            if (id == -1) // id=-1 (Inclusão) e id!=-1 (atualização)
                msg = "Confirma Inclusão dos Dados?";
            else msg = "Confirma Atualização dos Dados?";

            DialogResult resp;
            resp = MessageBox.Show(msg, "Gravar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resp == DialogResult.Yes)
            {
                livro.id = id;
                livro.Nome = txtNome.Text;
                livro.Autor = txtAutor.Text;
                //livro.DataLancamento = Convert.ToDateTime(txtDatL.Text);
                livro.Valor = Convert.ToSingle(txtValor.Text);
                

                if (id == -1)  //-1 indica inserir 
                    bllLivro.Insert(livro);
                else bllLivro.Update(livro);
            }
            dgvLivro.DataSource = "";
            dgvLivro.DataSource = bllLivro.Select();  //atualiza a grid
            limparCampos(); //limpa campos
            Habilitar(false);  //desabilita controles
        }
    }
}
