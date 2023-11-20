using DatabaseProject.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseProject.dao;

internal class daoLocal
{
    public bool SalvarLocal(Locais locais)
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
            //cn.CommandText = "insert into tb_locais([nome], [rua], [numero], [cidade], [uf])values(@nome, @rua, @numero,@cidade, @uf)";

            cn.CommandText = "delete from tb_locais where id = 3";



            //envia itens a serem salvos no Database
            cn.Parameters.Add("nome", SqlDbType.VarChar).Value = locais.Nome;
            cn.Parameters.Add("rua", SqlDbType.VarChar).Value = locais.Rua;
            cn.Parameters.Add("numero", SqlDbType.Int).Value = locais.Numero;
            cn.Parameters.Add("cidade", SqlDbType.VarChar).Value = locais.Cidade;
            cn.Parameters.Add("uf", SqlDbType.VarChar).Value = locais.Uf;




            //Abrir conexão

            cn.Connection = con;

            //executa a conexão

            return cn.ExecuteNonQuery() > 0;

        }

    }
}
