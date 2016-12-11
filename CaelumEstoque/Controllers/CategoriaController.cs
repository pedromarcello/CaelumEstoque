using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                CategoriasDAO dao = new CategoriasDAO();
                IList<CategoriaDoProduto> categoria = dao.Lista();
                ViewBag.Categoria = categoria;
                return View();
            }
            else
            {
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                IList<CategoriaDoProduto> categoria = categoriasDAO.Lista(); 
                ViewBag.Categoria = categoria;
                return View("Form");
            }
            CategoriasDAO cDao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = cDao.Lista();
            ViewBag.Categoria = categorias;
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            CategoriasDAO dao = new CategoriasDAO();
            dao.Adiciona(categoria);
            return RedirectToAction("Index");
        }
    }
}