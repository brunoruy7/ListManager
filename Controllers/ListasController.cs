using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListManager.Data;
using ListManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections;

namespace ListManager.Controllers
{
    public class ListasController : Controller

    {
        private  ApplicationDbContext _context;
        public ListasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Listas
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = _context.Users.Find(_context.Getid());
            return View(_context.Lista.Where(s => s.UserID.Equals(user)));
        }

        // GET: Listas/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Lista
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lista == null)
            {
                return NotFound();
            }

            return View(lista);
        }

        // GET: Listas/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Completed,Nome,Tipo,prazo")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                var userId = _context.Getid();
                lista.UserID = _context.Users.Find(userId);

                _context.Add(lista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lista);
        }

        // GET: Listas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Lista.FindAsync(id);
            if (lista == null)
            {
                return NotFound();
            }
            return View(lista);
        }

        // POST: Listas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Completed,Nome,Tipo,prazo")] Lista lista)
        {
            if (id != lista.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaExists(lista.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lista);
        }

        // GET: Listas/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Lista
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lista == null)
            {
                return NotFound();
            }

            return View(lista);
        }

        // POST: Listas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lista = await _context.Lista.FindAsync(id);
            _context.Lista.Remove(lista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaExists(int id)
        {
            return _context.Lista.Any(e => e.ID == id);
        }
    }
}
