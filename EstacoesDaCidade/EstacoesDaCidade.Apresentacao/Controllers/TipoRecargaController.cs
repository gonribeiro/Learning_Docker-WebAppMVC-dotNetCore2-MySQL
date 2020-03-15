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
    public class TipoRecargaController : Controller
    {
        private readonly ITipoRecargaApp _tipoRecargaApp;

        public TipoRecargaController(ITipoRecargaApp tipoRecargaApp)
        {
            _tipoRecargaApp = tipoRecargaApp;
        }

        // GET: TipoRecarga
        public ActionResult Index()
        {
            return View(_tipoRecargaApp.Listar());
        }

        // GET: TipoRecarga/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_tipoRecargaApp.RecuperarPorId(id));
        }

        // GET: TipoRecarga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoRecarga/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoRecarga tipoRecarga)
        {
            try
            {
                _tipoRecargaApp.Adicionar(tipoRecarga);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoRecarga/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_tipoRecargaApp.RecuperarPorId(id));
        }

        // POST: TipoRecarga/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoRecarga tipoRecarga)
        {
            try
            {
                // TODO: Add update logic here
                _tipoRecargaApp.Atualizar(tipoRecarga);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoRecarga/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_tipoRecargaApp.RecuperarPorId(id));
        }

        // POST: TipoRecarga/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoRecarga tipoRecarga)
        {
            try
            {
                _tipoRecargaApp.Excluir(tipoRecarga);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}