using DatabaseProject.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseProject.dao;

internal class DaoContato
{
    public bool salvar(Contato contato) 
    {
        using (SqlConnection con = new SqlConnection())
        {
            //criar conexão com Database
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_agenda;
                                    Connect Timeout=30;Encrypt=False;";
            con.Open();

            //Comando DML enviado ao Database
            SqlCommand cn = new SqlCommand();
            cn.CommandType = CommandType.Text;
            //cn.CommandText = "insert into tb_contatos([nome], [email], [telefone])values(@nome, @email, @telefone)";

            //envia itens a serem salvos no Database
            cn.Parameters.Add("nome", SqlDbType.VarChar).Value = contato.Nome;
            cn.Parameters.Add("email", SqlDbType.VarChar).Value = contato.Email;
            cn.Parameters.Add("telefone", SqlDbType.VarChar).Value = contato.Telefone;

            //Abrir conexão

            cn.Connection = con;

            //executa a conexão

            return cn.ExecuteNonQuery() > 0;

        }
        
    }

    public void consultar()
    {
        using (SqlConnection con = new SqlConnection())
        {
            //criar conexão com Database
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_agenda;
                                Connect Timeout=30;Encrypt=False;";
            con.Open();

            //Comando DML enviado ao Database
            SqlCommand cn = new SqlCommand();
            cn.CommandType = CommandType.Text;
            cn.CommandText = "select * from tb_contatos";

            //Abrir conexão

            cn.Connection = con;

            //executa a conexão

            SqlDataReader dr;
            dr = cn.ExecuteReader();

            while (dr.Read())
            {
                Contato ct = new Contato();
                ct.Id = Convert.ToInt32(dr["id"]);
                ct.Nome = Convert.ToString(dr["nome"]);
                ct.Email = Convert.ToString(dr["email"]);
                ct.Telefone = Convert.ToString(dr["telefone"]);

                Console.WriteLine(ct.ToString());
            }

            

        }

        
        
    }
}
