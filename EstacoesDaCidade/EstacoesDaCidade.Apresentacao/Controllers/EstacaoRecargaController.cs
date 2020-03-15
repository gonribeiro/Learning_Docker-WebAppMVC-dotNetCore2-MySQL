using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacoesDaCidade.Aplicacao.Interfaces;
using EstacoesDaCidade.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstacoesDaCidade.Apresentacao.Controllers
{
    public class EstacaoRecargaController : Controller
    {
        private readonly IEstacaoRecargaApp _estacaoRecargaApp;

        public EstacaoRecargaController(IEstacaoRecargaApp estacaoRecargaApp)
        {
            _estacaoRecargaApp = estacaoRecargaApp;
        }

        // GET: EstacaoRecarga
        public ActionResult Index()
        {
            return View(_estacaoRecargaApp.Listar());
        }

        // GET: EstacaoRecarga/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_estacaoRecargaApp.RecuperarPorId(id));
        }

        // GET: EstacaoRecarga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstacaoRecarga/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstacaoRecarga estacaoRecarga)
        {
            try
            {
                _estacaoRecargaApp.Adicionar(estacaoRecarga);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstacaoRecarga/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_estacaoRecargaApp.RecuperarPorId(id));
        }

        // POST: EstacaoRecarga/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstacaoRecarga estacaoRecarga)
        {
            try
            {
                // TODO: Add update logic here
                _estacaoRecargaApp.Atualizar(estacaoRecarga);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstacaoRecarga/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_estacaoRecargaApp.RecuperarPorId(id));
        }

        // POST: EstacaoRecarga/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EstacaoRecarga estacaoRecargan)
        {
            try
            {
                _estacaoRecargaApp.Excluir(estacaoRecargan);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}