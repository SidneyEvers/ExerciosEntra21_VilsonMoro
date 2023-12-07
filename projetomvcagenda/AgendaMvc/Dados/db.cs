using AgendaMvc.Dao;
using MySqlConnector;

namespace AgendaMvc.Controllers.Dados;

public class db 
{
    public static List<Models.Contato> contatos = new() { new Models.Contato()};

    public static List<Models.Compromisso> compromissos = new() { new Models.Compromisso() };

    public static List<Models.Locais> _locais = new();

    public static MySqlConnection Conectar()
    {
        string connString = "server=localhost;database=agendamvc;user=root;password=admin";
        MySqlConnection connection = new MySqlConnection(connString);
        return connection;
    }
}
