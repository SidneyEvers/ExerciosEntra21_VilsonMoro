
using System.Reflection.Metadata.Ecma335;

namespace ExercMotoHeranca.Models;

internal class Moto
{
    public Moto()
    {

    }
    public Moto(string marca, int cilindrada)
    {
        Marca = marca;
        Cilindrada = cilindrada;
    }


    public string Marca { get; set; }
    public int Cilindrada { get; set; }

    public string ToString()
    {
        return $"{Marca} {Cilindrada} Cilindradas";
    }
}
