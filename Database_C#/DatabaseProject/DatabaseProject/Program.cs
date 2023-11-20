using DatabaseProject.dao;
using DatabaseProject.Entidades;

namespace DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Local();

            //Contato();

            /*void Local()
            {
                Locais office = new Locais(1, "Proway", "Rua 7 de setembro", 1758, "Blumenau", "SC");

                daoLocal daolocal = new daoLocal();

                if (daolocal.SalvarLocal(office))
                {
                    Console.WriteLine("Local salvo com sucesso");
                }

            }*/

            /* void Contato()
             {
                 Contato ct = new Contato(2, "Jessica", "jessica@gmail.com", "(47)9204-0493");


                 DaoContato daoContato = new DaoContato();

                 if (daoContato.salvar(ct))
                 {
                     Console.WriteLine("Contato salvo com sucesso");
                 }
             }*/
            DaoContato daoContato = new DaoContato();
            daoContato.consultar();


            Console.ReadKey();
        }
    }
}