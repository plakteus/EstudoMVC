using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
        [TestMethod]
        public void TestarSePaginacaoEstaSendoGeradaCorretamente()
        {
            // Arrange
            HtmlHelper html = null;

            Paginacao pagina = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 30
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            // Act   
            MvcHtmlString resultado = html.PageLink(pagina, paginaUrl);

            // Assert
            Assert.AreEqual
                (
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>"
                , resultado.ToString()
                );



        }
    }
}
