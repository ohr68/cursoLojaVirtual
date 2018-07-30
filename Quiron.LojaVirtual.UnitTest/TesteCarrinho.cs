using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinho
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            //Arrange - Criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            //Arrange - criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2,3);

            //Act
            ItemCarrinho[] items = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(items.Length, 2);
            Assert.AreEqual(items[0].Produto, produto1);
            Assert.AreEqual(items[1].Produto, produto2);
        }

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            //Arrange - Criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            //Arrange - criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 9);
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            //Arrange - Criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            //Arrange - criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            carrinho.RemoverItem(produto2);

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count(),0); // 0 => nenhum produto no carrinho
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            //Arrange - Criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1",
                Preco = 100.00M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2",
                Preco = 50.00M
            };

            //Arrange - criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            decimal resultado = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(resultado, 350.00M);
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            //Arrange - Criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1",
                Preco = 100.00M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2",
                Preco = 50.00M
            };

            //Arrange - criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);
            
            //Act
            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);

        }
    }
}
