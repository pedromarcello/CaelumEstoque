using CaelumEstoque.DAO;
using CaelumEstoque.Filtros;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto
            [Route ("Produtos" , Name = "ListaProdutos")]
            public ActionResult Index()
            {
                ProdutosDAO dao = new ProdutosDAO();
                IList<Produto> produtos = dao.Lista();
                ViewBag.Produtos = produtos;
                return View(produtos);
            }
        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            ViewBag.Produto = new Produto();
            ViewBag.Categorias = dao.Lista();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
            }
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index");
            }
            else
            {
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                ViewBag.Produto = produto;
                return View("Form");
            }
        }
        [Route("VisualizaProduto/{id}",Name ="VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View();  
        }
    }
}
