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
                IList<CategoriaDoProduto> categorias = categoriasDAO.Lista(); 
                ViewBag.Categoria = categorias;
                return View("Form");
            }
        }
    }
}