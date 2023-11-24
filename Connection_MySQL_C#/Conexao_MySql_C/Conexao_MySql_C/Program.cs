using Conexao_MySql_C.daoContato;
using Conexao_MySql_C.Models;



/*Contato ct = new(1, "Sidney", "sidney@email.com", "(47)99143-7683");

daoContato daocontato = new();

if (daocontato.salvar(ct))
{
    Console.WriteLine("Contato salvo com sucesso");
}*/

List<Contato> contatos;

daoContato daoMySql = new();
contatos = daoMySql.consultar();

foreach (Contato contato in contatos)
{
    Console.WriteLine(contato.ToString());
}




