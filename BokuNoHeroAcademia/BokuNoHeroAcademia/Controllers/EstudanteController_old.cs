using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BokuNoHeroAcademia.Data;
using BokuNoHeroAcademia.Models;

namespace BokuNoHeroAcademia.Controllers
{
    public class EstudanteController_old : Controller
    {
        private readonly AcademiaContext _context;

        public EstudanteController_old(AcademiaContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.Estudante
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.NomeHeroi.Contains(searchString)
                                       || s.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.NomeHeroi);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.DataMatricula);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.DataMatricula);
                    break;
                default:
                    students = students.OrderBy(s => s.NomeHeroi);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Estudante>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}
