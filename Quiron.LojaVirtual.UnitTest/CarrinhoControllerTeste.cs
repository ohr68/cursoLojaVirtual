using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Web.Controllers;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTeste
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            //Arrange - Preparação
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

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1,3);

            CarrinhoController controller = new CarrinhoController();

            //Act - Estímulo
            controller.Adicionar(carrinho, 2, "");

            //Assert - Verificações
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),1);
            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId,1);
        }

        [TestMethod]
        public void Adiciona_Produto_E_RetornaCategoria_Na_Url()
        {
            //Arrange
            Carrinho carrinho = new Carrinho();

            //Act
            CarrinhoController controller = new CarrinhoController();

            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");

            //Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"],"minhaUrl");

        }

        [TestMethod]
        public void Posso_Ver_O_Conteudo_Do_Carrinho()
        {
            //Arrange
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();

            //Act
            CarrinhoViewModel resultado = (CarrinhoViewModel) controller.Index(carrinho, "minhaUrl").ViewData.Model;

            //Assert
            Assert.AreSame(resultado.Carrinho,carrinho);
            Assert.AreEqual(resultado.ReturnUrl,"minhaUrl");
        }
    }
}
