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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void Habilitar(bool status)
        {
            txtNome.Enabled = status;
            txtCPF.Enabled = status;
            txtRG.Enabled = status;
            txtContato.Enabled = status;
            txtEndereco.Enabled = status;
            txtCidade.Enabled = status;
            txtEstado.Enabled = status;

            btnCadastrar.Enabled = status;
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnSair.Enabled = status;
            btnRemover.Enabled = !status;
        }

        private void limparCampo()
        {
            lblID.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            txtContato.Text = "";
            txtEndereco.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Camadas.BLL.Cliente bllCliente = new Camadas.BLL.Cliente();
            dgvClientes.DataSource = bllCliente.Select();
            Habilitar(false);
            
        }

        private void lblld_Click(object sender, EventArgs e)
        {

        }



        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnSair_Click(object sender, EventArgs e)
        {
            limparCampo();
            Habilitar(false);
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                lblID.Text = dgvClientes.SelectedRows[0].Cells["ID"].Value.ToString();
                txtNome.Text = dgvClientes.SelectedRows[0].Cells["Nome"].Value.ToString();
                txtContato.Text = dgvClientes.SelectedRows[0].Cells["Contato"].Value.ToString();
                txtCPF.Text = dgvClientes.SelectedRows[0].Cells["CPF"].Value.ToString();
                txtRG.Text = dgvClientes.SelectedRows[0].Cells["RG"].Value.ToString();
                txtEndereco.Text = dgvClientes.SelectedRows[0].Cells["Endereco"].Value.ToString();
                txtCidade.Text = dgvClientes.SelectedRows[0].Cells["Cidade"].Value.ToString();
                txtEstado.Text = dgvClientes.SelectedRows[0].Cells["Estado"].Value.ToString();

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string msg;
            if (lblID.Text != string.Empty)
            {
                msg = "Confirma Remoção do Cliente " + txtNome.Text + "?";
                DialogResult resp;
                resp = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resp == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(lblID.Text);
                    Camadas.BLL.Cliente bllCliente = new Camadas.BLL.Cliente();
                    Camadas.Model.Cliente cliente = new Camadas.Model.Cliente();
                    cliente.ID = id;
                    // informar outros campos caso necessite no bll
                    bllCliente.Delete(cliente);
                    dgvClientes.DataSource = "";
                    dgvClientes.DataSource = bllCliente.Select();
                }
            }
            else
            {
                msg = "Não há registro para remoção...";
                MessageBox.Show(msg, "Remover", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limparCampo();
            Habilitar(false);
        }

            private void btnEditar_Click(object sender, EventArgs e)
            {
                if (lblID.Text != string.Empty)
                {
                    Habilitar(true);
                    txtNome.Focus();
                }
                else
                {
                    string msg = "Não há registro para edição";
                    MessageBox.Show(msg, "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            private void btnInserir_Click(object sender, EventArgs e)
            {
                limparCampo();
                lblID.Text = "-1";
                Habilitar(true);
                txtNome.Focus();
            }

        private void txtContato_TextChanged(object sender, EventArgs e)
        {
            //txtContato.Text = String.Format("{0:(##)#####-####}", Convert.ToInt64(txtContato.Text));
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Camadas.BLL.Cliente bllCliente = new Camadas.BLL.Cliente();
            Camadas.Model.Cliente cliente = new Camadas.Model.Cliente();
            int id = Convert.ToInt32(lblID.Text);

            string msg = "";
            if (id == -1) // id=-1 (Inclusão) e id!=-1 (atualização)
                msg = "Confirma Inclusão dos Dados?";
            else msg = "Confirma Atualização dos Dados?";

            DialogResult resp;
            resp = MessageBox.Show(msg, "Gravar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resp == DialogResult.Yes)
            {
                cliente.ID = id;
                cliente.Nome = txtNome.Text;
                cliente.CPF = txtCPF.Text;
                cliente.RG = txtRG.Text;
                cliente.Contato = txtContato.Text;
                cliente.Endereco = txtEndereco.Text;
                cliente.Cidade = txtCidade.Text;
                cliente.Estado = txtEstado.Text.ToUpper();
                
                if (id == -1)  //-1 indica inserir 
                    bllCliente.Insert(cliente);
                else bllCliente.Update(cliente);
            }
            dgvClientes.DataSource = "";
            dgvClientes.DataSource = bllCliente.Select();  //atualiza a grid
            limparCampo(); //limpa campos
            Habilitar(false);  //desabilita controles
        }
    }

 }
