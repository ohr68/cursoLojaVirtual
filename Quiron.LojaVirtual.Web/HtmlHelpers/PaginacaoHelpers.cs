using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Text;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.HTMLHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int,string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder();

            for (int i = 1; i < paginacao.TotalPaginas; i++)
            {
                TagBuilder tag = new TagBuilder("a"); //primeira tag a ser criada 
                tag.MergeAttribute("href",paginaUrl(i)); //cria os valores e atribui ao href
                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }

            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}