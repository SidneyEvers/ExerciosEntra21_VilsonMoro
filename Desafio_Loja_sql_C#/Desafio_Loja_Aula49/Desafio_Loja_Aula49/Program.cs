using Desafio_Loja_Aula49.dao;
using Desafio_Loja_Aula49.Models;
using System.ComponentModel.Design;

namespace Desafio_Loja_Aula49
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuProdutos();
            //MenuCategorias();
            Console.ReadKey();
        }
        static void MenuProdutos()
        {
            Console.WriteLine("Escolha opção (1) para Adicionar, (2) para Listar, (3) para Editar, (4) para Excluir");
            int escolhaMenu = Convert.ToInt32(Console.ReadLine());

            if (escolhaMenu == 1)
            {
                SalvarProduto();
            }
            /*else if (escolhaMenu == 2)
            {
                ListarProduto();
            }
            else if (escolhaMenu == 3)
            {
                EditarProduto();
            }
            else if (escolhaMenu == 4)
            {
                ExcluirProduto();
            }*/
        }
        static void ListarCategoriasparaProdutos()
        {
            daoCategoria daoCategorias = new();

            daoCategorias.listar();
        }
            static void SalvarProduto()
        {
            Produto produto = new();

            Console.WriteLine("Digite o nome do produto");
            string nomeProduto = Console.ReadLine();
            produto.Descricao = nomeProduto;

            ListarCategoriasparaProdutos();

            Console.WriteLine("Digite o Id da Categoria");
            int idCategoriafk = Convert.ToInt32(Console.ReadLine());
            produto.Categoria = idCategoriafk;

            Console.WriteLine("Digite o valor do produto: ");
            float valorProduto = Convert.ToSingle(Console.ReadLine());
            produto.Valor = valorProduto;

            Console.WriteLine("Digite a quantidade de produtos: ");
            int escolhaQtd = Convert.ToInt32(Console.ReadLine());
            produto.Quantidade = escolhaQtd;

            daoProduto daoProduto = new();

            if (daoProduto.salvar(produto))
            {
                Console.WriteLine("Produto adicionado com sucesso!");
            }

            Console.WriteLine("Deseja adiconar mais produtos? - (1) para SIM e (2) para NÃO: ");
            int x2 = Convert.ToInt32(Console.ReadLine());

            if(x2 == 1)
            {
                SalvarProduto();
            }
            else if(x2 == 2)
            {
                MenuProdutos();
            }
        }
        static void MenuCategorias()
        {
            Console.WriteLine("Escolha opção (1) para Adicionar, (2) para Listar, (3) para Consultar, (4) para Excluir");
            int escolhaMenu = Convert.ToInt32(Console.ReadLine());

            if(escolhaMenu == 1)
            {
                SalvarCategorias();
            }
            else if(escolhaMenu == 2)
            {
                ListarCategorias();
            }
            else if(escolhaMenu == 3)
            {
                ListarCategorias();
            }
            else if(escolhaMenu == 4)
            {
                ExcluirCategoria();
            }
        }

        static void SalvarCategorias()
        {
            Categoria categoria = new Categoria();

            Console.WriteLine("Digite um tipo de Categoria que deseja adicionar: ");
            categoria.Descricao = Console.ReadLine();

            daoCategoria daoCategoria = new();

            if (daoCategoria.salvar(categoria))
            {
                Console.WriteLine("Categoria Adicionada!");
            }

            Console.WriteLine("Deseja Adiconar mais uma Categoria? - Digite 1 para SIM, e 2 para SAIR");
            int x1 = Convert.ToInt32(Console.ReadLine());

            if(x1 == 1)
            {
                SalvarCategorias();
            }
            else if(x1 == 2)
            {
                MenuCategorias();
            }
        }
        static void ListarCategorias()
        {
            daoCategoria daoCategorias = new();

            daoCategorias.listar();

            Console.WriteLine("Digite - (1) para Voltar para o Menu ou (2) para Editar alguma categoria: ");
            int escList = Convert.ToInt32(Console.ReadLine());

            if(escList == 1)
            {
                MenuCategorias();
            }
            else if(escList == 2)
            {
                EditarCategoria();
            }
        }
        static void EditarCategoria()
        {
            Console.WriteLine("Digite o Id da categoria que deseja editar: ");
            int escolhaCategoria = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o novo nome de categoria: ");
            string novoNome = Console.ReadLine();

            daoCategoria daoCategoria = new();

            daoCategoria.editar(novoNome, escolhaCategoria);

            ListarCategorias();
        }
        static void ExcluirCategoria()
        {
            Console.WriteLine("Digite o Id da Categoria que deseja excluir: ");
            int excluirId = Convert.ToInt32(Console.ReadLine());

            daoCategoria daoCategoria = new();

            daoCategoria.excluir(excluirId);

            ListarCategorias();

        }
    }
        
}