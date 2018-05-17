using Aula1.Context;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class FuncionariosController : Controller
    {


        private readonly EFContext _contexts = new EFContext();

        public ActionResult Index()

        {
            return View(_contexts
                .Funcionarios
                .Include(l => l.Loja)
                .OrderBy(f => f.Name));
        }


        #region Create
        public ActionResult Create()
        {
            ViewBag.LojaId = new SelectList(_contexts.Lojas.OrderBy(n => n.Name), "LojaId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            _contexts.Funcionarios.Add(funcionario);
            _contexts.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion


        #region Edit
        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var funcionarios = _contexts.Funcionarios.Find(id.Value);

            if (funcionarios == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.LojaId = new SelectList(_contexts.Lojas.OrderBy(n => n.Name), "LojaId", "Name");
            return View(funcionarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Funcionario funcionarios)
        {
            if (ModelState.IsValid)
            {
                _contexts.Entry(funcionarios).State = EntityState.Modified;
                _contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionarios);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var funcionarios = _contexts.Funcionarios.Find(id.Value);

            if (funcionarios == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(funcionarios);
        }
        #endregion


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Funcionario funcionario = _contexts.Funcionarios.Find(id.Value);

            if (funcionario == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(funcionario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {

                Funcionario funcionario = _contexts.Funcionarios.Find(id);
                _contexts.Funcionarios.Remove(funcionario);
                _contexts.SaveChanges();
                TempData["Message"] = "Ideia " + funcionario.Name.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }

            catch
            {

                return View();
            }

        }
    }
}
