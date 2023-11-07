
namespace ExercMotoHeranca.Models;

internal class MotoPasseio : Moto
{
	public MotoPasseio(string marca, int cilindrada, int bagageiro) : base(marca, cilindrada)
	{
		Bagageiro = bagageiro;
	}
	public int Bagageiro { get; set; }

	public string ToString()
	{
		return $"{base.ToString()} {Bagageiro} Litros";
	}
}
