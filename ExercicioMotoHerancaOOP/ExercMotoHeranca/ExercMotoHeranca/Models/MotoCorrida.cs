
namespace ExercMotoHeranca.Models;

internal class MotoCorrida : Moto
{
	public MotoCorrida(string marca, int cilindrada, int maxspeed) : base(marca, cilindrada)
	{
		MaxSpeed = maxspeed;
	}


	public int MaxSpeed { get; set; }

	public string ToString()
	{
		return $"{base.ToString()} {MaxSpeed}";
	}
}
