using AgendaMvc.Controllers.Dados;
using AgendaMvc.interfaces;
using AgendaMvc.Models;
using MySqlConnector;
using System.Data;

namespace AgendaMvc.Dao
{
    public class DaoContato : ICrud<Contato>
    {
        public bool alterar(Contato contato)
        {
            MySqlConnection con = db.Conectar();
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "update tb_contato set nome = @nome, email = @email, telefone = @telefone where id = @id";

                command.Parameters.AddWithValue("@id", contato.Id);
                command.Parameters.AddWithValue("@nome", contato.Nome);
                command.Parameters.AddWithValue("@email", contato.Email);
                command.Parameters.AddWithValue("@telefone", contato.Telefone);
                return command.ExecuteNonQuery() > 0;
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            
        }

        public Contato consultar(int id)
        {
            MySqlConnection con = db.Conectar();
            MySqlCommand command = con.CreateCommand();

            con.Open();
            command.CommandText = "select id, nome, email, telefone from tb_contato where id = @id";

            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = command.ExecuteReader();
            Contato ct = new Contato();
            while (dr.Read())
            {
                ct.Id = Convert.ToInt32(dr["id"]);
                ct.Nome = Convert.ToString(dr["nome"]);
                ct.Email = Convert.ToString(dr["email"]);
                ct.Telefone = Convert.ToString(dr["telefone"]);                
            }  
            return ct;            
        }

        public List<Contato> consultar()
        {
            List<Contato> contatos = new();

            MySqlConnection con = db.Conectar();
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "select * from tb_contato";
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Contato ct = new Contato();
                    ct.Id = Convert.ToInt32(dr["id"]);
                    ct.Nome = Convert.ToString(dr["nome"]);
                    ct.Email = Convert.ToString(dr["email"]);
                    ct.Telefone = Convert.ToString(dr["telefone"]);
                    contatos.Add(ct);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return contatos;
        }

        public Contato Deletar(int id)
        {
            MySqlConnection con = db.Conectar();
            MySqlCommand command = con.CreateCommand();

            con.Open();
            command.CommandText = "select id, nome, email, telefone from tb_contato where id = @id";

            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = command.ExecuteReader();
            Contato ct = new Contato();
            while (dr.Read())
            {
                ct.Id = Convert.ToInt32(dr["id"]);
                ct.Nome = Convert.ToString(dr["nome"]);
                ct.Email = Convert.ToString(dr["email"]);
                ct.Telefone = Convert.ToString(dr["telefone"]);
            }
            return ct;
        }
        public void excluir(int id)
        {
            MySqlConnection con = db.Conectar();
            MySqlCommand command = con.CreateCommand();

            con.Open();
            command.CommandText = "delete from tb_contato where id = @id";

            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();

        }
        public bool salvar(Contato contato)
        {
            MySqlConnection con = db.Conectar();
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "insert into tb_contato(id, nome, email, telefone)values(@id,@nome, @email, @telefone)";
                command.Parameters.Add("id", MySqlDbType.VarString).Value = contato.Id;
                command.Parameters.Add("nome", MySqlDbType.VarString).Value = contato.Nome;
                command.Parameters.Add("email", MySqlDbType.VarString).Value = contato.Email;
                command.Parameters.Add("telefone", MySqlDbType.VarString).Value = contato.Telefone;
                command.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }
    }
}
