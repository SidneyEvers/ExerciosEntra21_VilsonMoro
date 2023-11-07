

using ExercMotoHeranca.Models;

namespace ExercMotoHeranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Moto moto = new("Honda", 125);

            Console.WriteLine(moto.ToString());

            MotoCorrida motocorrida = new("Yamaha", 1500, 290);
            Console.WriteLine(motocorrida.ToString());

            MotoPasseio motopasseio = new("Suzuki", 200, 25);
            Console.WriteLine(motopasseio.ToString());
        }
    }
}