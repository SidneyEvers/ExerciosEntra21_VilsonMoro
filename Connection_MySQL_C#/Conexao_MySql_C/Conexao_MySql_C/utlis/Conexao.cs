using MySql.Data.MySqlClient;

namespace Conexao_MySql_C.utlis;

internal class Conexao
{
    public static MySqlConnection conectar()
    {
        string connString = "Server=localhost;Database=sidney_db;Uid=root;Pwd=admin";
        MySqlConnection connection = new MySqlConnection(connString);
        return connection;
    }
}
