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
    public partial class formCliente : Form
    {
        public formCliente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Camadas.DAL.Cliente dalCli = new Camadas.DAL.Cliente();
            dgvClientes.DataSource = dalCli.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Camadas.Model.Cliente cliente = new Camadas.Model.Cliente();
            Camadas.DAL.Cliente dalCli = new Camadas.DAL.Cliente();
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.RG = txtRG.Text;
            cliente.Contato = txtContato.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Estado = txtEstado.Text;

            dalCli.Insert(cliente);
            dgvClientes.DataSource = "";
            dgvClientes.DataSource = dalCli.Select();

            
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Camadas.Model.Cliente cliente = new Camadas.Model.Cliente();
            Camadas.DAL.Cliente dalCli = new Camadas.DAL.Cliente();

            cliente.ID = Convert.ToInt32(txtID.Text);
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.RG = txtRG.Text;
            cliente.Contato = txtContato.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Estado = txtEstado.Text;

            dalCli.Update(cliente);

            dgvClientes.DataSource = "";
            dgvClientes.DataSource = dalCli.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Camadas.Model.Cliente cliente = new Camadas.Model.Cliente();
            Camadas.DAL.Cliente dalCli = new Camadas.DAL.Cliente();

            cliente.ID = Convert.ToInt32(txtID.Text);

            dalCli.Delete(cliente);

            dgvClientes.DataSource = "";
            dgvClientes.DataSource = dalCli.Select();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
