using ExercicioLinkedList.Models;
using System.Security.Cryptography.X509Certificates;

namespace ExercicioLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //exercicio1();
            exercicio2();
            exercicio3();
            Console.ReadKey();

           

        }

        static void exercicio1() {

            //Criar uma coleção  com chave do tipo string recebendo o nome de uma pessoa e no valor armazenar um objeto do tipo pessoa.

            Pessoa pessoa = new("Evers");
            pessoa.AdicionarNaLista("Sidney", pessoa);
            pessoa.MostrarNaLista();
        }

        static void exercicio2()
        {
            //Criar uma coleção que armazena uma lista de produtos. Não deve permitir informar produtos duplicados.

            Produtos produto = new("Banana");
            Produtos novoProduto = new("Banana");

            produto.AdicionarProduto(produto);
            novoProduto.AdicionarProduto(novoProduto);

            produto.MostrarProdutos();
        }

        static void exercicio3()
        {
            //Criar uma coleção que permita informar a categoria de um produto como chave e armazenar uma lista de
            //produtos da respectiva categoria.

            List<Produtos> produtos = new();
            
            
            CategoriaProduto bebidas = new(1, "bebidas");



        }


    }


        
}