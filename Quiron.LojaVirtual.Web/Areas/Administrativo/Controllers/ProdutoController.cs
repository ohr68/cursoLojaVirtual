﻿using System.Linq;
using System.Web;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidade;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos;
            return View(produtos);
        }

        public ViewResult Alterar(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                //Salvando a imagem no banco de dados
                if (image != null)
                {
                    produto.ImagemMimeType = image.ContentType;
                    produto.Imagem = new byte[image.ContentLength];
                    image.InputStream.Read(produto.Imagem, 0, image.ContentLength);
                }

                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(produto);

                //váriavel temporária
                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso!", produto.Nome);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public ViewResult NovoProduto()
        {
            return View("Alterar", new Produto());
        }

        //[HttpPost]
        //public ActionResult Excluir(int produtoId)
        //{
        //    _repositorio = new ProdutosRepositorio();
        //    Produto prod = _repositorio.Excluir(produtoId);

        //    if (prod != null)
        //    {
        //        TempData["mensagem"] = string.Format("{0} foi excluído com sucesso!", prod.Nome);
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Excluir(int produtoId)
        {
            string mensagem = string.Empty;
            _repositorio = new ProdutosRepositorio();
            Produto prod = _repositorio.Excluir(produtoId);

            if (prod != null)
            {
                mensagem = string.Format("{0} foi excluído com sucesso!", prod.Nome);
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }

        public FileContentResult ObterImagem(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto prod = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                //Retorna a imagem do produto 
                return File(prod.Imagem, prod.ImagemMimeType);
            }

            return null;
        }
    }
}