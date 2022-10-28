using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace boteco
{
    class Funcionario
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string cpf { get; set; }
        public string cc { get; set; }
        public string pix { get; set; }
        public string genero { get; set; }
        public string data_nascimento { get; set; }
        public string funcao { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Boteco\DbBoteco.mdf;Integrated Security=True");

        public List<Funcionario> listafuncionario()
        {
            List<Funcionario> li = new List<Funcionario>();
            string sql = "SELECT * FROM Funcionario";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Funcionario p = new Funcionario();
                p.Id = (int)dr["Id"];
                p.nome = dr["nome"].ToString();
                p.celular = dr["celular"].ToString();
                p.endereco = dr["endereco"].ToString();
                p.complemento = dr["complemento"].ToString();
                p.cidade = dr["cidade"].ToString();
                p.cep = dr["cep"].ToString();
                p.cpf = dr["cpf"].ToString();
                p.cc = dr["cc"].ToString();
                p.pix = dr["pix"].ToString();
                p.genero = dr["genero"].ToString();
                p.data_nascimento = dr["data_nascimento"].ToString();
                p.funcao = dr["funcao"].ToString();
                li.Add(p);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string celular, string endereco, string complemento, string cidade, string cep, string cpf, string cc, string pix, string genero, string data_nascimento, string funcao)
        {
            string sql = "INSERT INTO Funcionario(nome,celular,endereco,complemento,cidade,cep,cpf,cc,pix,genero,data_nascimento,funcao)VALUES('" + nome + "','" + celular + "','" + endereco + "','" + complemento + "','" + cidade + "','" + cep + "', '"+ cpf +"', '"+cc+"' ,'"+pix+"', '"+genero+"', '"+data_nascimento+"', '"+funcao+"')"; con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id, string nome, string celular, string endereco, string complemento, string cidade, string cep, string cpf, string cc, string pix, string genero, string data_nascimento, string funcao)
        {
            string sql = "UPDATE Funcionario SET nome='" + nome + "','" + celular + "','" + endereco + "','" + complemento + "','" + cidade + "','" + cep + "', '" + pix + "', '" + genero + "', '" + data_nascimento + "', '" + funcao + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Funcionario WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Funcionario WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                nome = dr["nome"].ToString();
                celular = dr["celular"].ToString();
                endereco = dr["endereco"].ToString();
                complemento = dr["complemento"].ToString();
                cidade = dr["cidade"].ToString();
                cep = dr["cep"].ToString();
                cpf = dr["cpf"].ToString();
                cc = dr["cc"].ToString();
                pix = dr["pix"].ToString();
                genero = dr["genero"].ToString();
                data_nascimento = dr["data_nascimento"].ToString();
                funcao = dr["funcao"].ToString();
            }
            dr.Close();
            con.Close();
        }

        public bool RegistroRepetido(string nome, string celular, string email)
        {
            string sql = "SELECT * FROM Funcionario WHERE nome='" + nome + "' AND cpf='" + cpf + "' AND celular='" + celular + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result > 0;
            }
            con.Close();
            return false;
        }
    }
}
