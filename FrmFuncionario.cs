using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boteco
{
    public partial class FrmFuncionario : Form
    {
        public FrmFuncionario()
        {
            InitializeComponent();
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            List<Funcionario> funcionarios = funcionario.listafuncionario();
            dgvFuncionario.DataSource = funcionarios;
            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Por favor, digite um ID!");
                this.txtId.Focus();
            }
            else
            {
                int Id = Convert.ToInt32(txtId.Text.Trim());
                Funcionario funcionario = new Funcionario();
                funcionario.Localizar(Id);
                txtNome.Text = funcionario.nome;
                txtCelular.Text = funcionario.celular;
                txtEndereco.Text = funcionario.endereco;
                txtComplemento.Text = funcionario.celular;
                txtCidade.Text = funcionario.data_nascimento;
                txtCep.Text = funcionario.cep;
                txtCpf.Text = funcionario.cpf;
                txtContaCorrente.Text = funcionario.cc;
                txtPix.Text = funcionario.pix;
                txtGenero.Text = funcionario.genero;
                txtDataNascimento.Text = funcionario.data_nascimento;
                txtFuncao.Text = funcionario.funcao;
                btnAtualizar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text == "" && txtFuncao.Text == "" && txtCpf.Text == "")
                {
                    MessageBox.Show("Por favor, preencha o formulário para inserir.");
                    this.txtNome.Focus();
                }
                else
                {
                    Funcionario funcionario = new Funcionario();
                    if (funcionario.RegistroRepetido(txtNome.Text, txtCelular.Text, txtCpf.Text) != false)
                    {
                        MessageBox.Show("Este cliente já está em nossa base de dados!");
                        List<Funcionario> funcionarios = funcionario.listafuncionario();
                        dgvFuncionario.DataSource = funcionarios;
                        txtNome.Text = "";
                        txtCelular.Text = "";
                        txtEndereco.Text = "";
                        txtComplemento.Text = "";
                        txtCidade.Text = "";
                        txtCep.Text = "";
                        txtCpf.Text = "";
                        txtContaCorrente.Text = "";
                        txtPix.Text = "";
                        txtGenero.Text = "";
                        txtDataNascimento.Text = "";
                        txtFuncao.Text = "";
                        this.txtNome.Focus();
                    }
                    else
                    {
                        funcionario.Inserir(txtNome.Text, txtCelular.Text, txtEndereco.Text, txtComplemento.Text, txtCidade.Text, txtCep.Text, txtCpf.Text, txtContaCorrente.Text, txtPix.Text, txtGenero.Text, txtDataNascimento.Text, txtFuncao.Text);
                        MessageBox.Show("Cliente cadastrado com sucesso!");
                        List<Funcionario> funcionarios = funcionario.listafuncionario();
                        dgvFuncionario.DataSource = funcionarios;
                        txtNome.Text = "";
                        txtCelular.Text = "";
                        txtCelular.Text = "";
                        txtComplemento.Text = "";
                        txtCidade.Text = "";
                        txtCep.Text = "";
                        txtCpf.Text = "";
                        txtContaCorrente.Text = "";
                        txtPix.Text = "";
                        txtGenero.Text = "";
                        txtDataNascimento.Text = "";
                        txtFuncao.Text = "";
                        this.txtNome.Focus();
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtId.Text.Trim());
                Funcionario funcionario = new Funcionario();
                funcionario.Atualizar(Id, txtNome.Text, txtCelular.Text, txtEndereco.Text, txtComplemento.Text, txtCidade.Text, txtCep.Text, txtCpf.Text, txtContaCorrente.Text, txtPix.Text, txtGenero.Text, txtDataNascimento.Text, txtFuncao.Text);
                MessageBox.Show("Cliente atualizado com sucesso!");
                List<Funcionario> funcionarios = funcionario.listafuncionario();
                dgvFuncionario.DataSource = funcionarios;
                txtId.Text = "";
                txtNome.Text = "";
                txtCelular.Text = "";
                txtCelular.Text = "";
                txtComplemento.Text = "";
                txtCidade.Text = "";
                txtCep.Text = "";
                txtCpf.Text = "";
                txtContaCorrente.Text = "";
                txtPix.Text = "";
                txtGenero.Text = "";
                txtDataNascimento.Text = "";
                txtFuncao.Text = "";
                this.txtNome.Focus();
                btnAtualizar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Insira um ID para atualizar!");
                this.txtId.Focus();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtId.Text.Trim());
                Funcionario funcionario = new Funcionario();
                funcionario.Excluir(Id);
                MessageBox.Show("Cliente excluído com sucesso!");
                List<Funcionario> pessoas = funcionario.listafuncionario();
                dgvFuncionario.DataSource = pessoas;
                txtId.Text = "";
                txtNome.Text = "";
                txtCelular.Text = "";
                txtComplemento.Text = "";
                txtCidade.Text = "";
                txtCep.Text = "";
                txtCpf.Text = "";
                txtContaCorrente.Text = "";
                txtPix.Text = "";
                txtGenero.Text = "";
                txtDataNascimento.Text = "";
                txtFuncao.Text = "";
                this.txtNome.Focus();
                btnAtualizar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Insira um ID para excluir!");
                this.txtId.Focus();
            }
        }

        private void dgvFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvFuncionario.Rows[e.RowIndex];
                row.Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCelular.Text = row.Cells[2].Value.ToString();
                txtEndereco.Text = row.Cells[3].Value.ToString();
                txtComplemento.Text = row.Cells[4].Value.ToString();
                txtCidade.Text = row.Cells[5].Value.ToString();
                txtCep.Text = row.Cells[6].Value.ToString();
                txtCpf.Text = row.Cells[7].Value.ToString();
                txtContaCorrente.Text = row.Cells[8].Value.ToString();
                txtPix.Text = row.Cells[9].Value.ToString();
                txtGenero.Text = row.Cells[10].Value.ToString();
                txtDataNascimento.Text = row.Cells[11].Value.ToString();
                txtFuncao.Text = row.Cells[12].Value.ToString();
            }
            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Deseja realmente sair do aplicativo?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
