namespace DatabaseProject.Entidades;

internal class Locais
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Cidade { get; set; }
    public string  Uf { get; set; }

    public Locais(int id, string nome, string rua, int numero, string cidade, string uf)
    {
        Id = id; 
        Nome = nome;
        Rua = rua;
        Numero = numero;
        Cidade = cidade;
        Uf = uf;
    }
}
