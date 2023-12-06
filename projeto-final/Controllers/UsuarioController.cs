﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_final.Models;
using BCrypt.Net;
using NuGet.Protocol.Plugins;

namespace projeto_final.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Contexto _context;

        public UsuarioController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Login(Usuario usuario)
        {
            if (usuario.UsuarioEmail == "")
                return View();
            else
            {
                var resultado = Autenticar(usuario);
                if (resultado)
                {
                    var verificaLogin = _context.Usuario.Where(x => x.UsuarioEmail == usuario.UsuarioEmail).FirstOrDefault();
                    if (verificaLogin == null)
                    {
                        ViewBag.Mensagem = "Usuário ou Senha não existe.";
                        return View();
                    }
                    else
                    {
                        return View("~/Views/Home/Index.cshtml");
                    }
                }
                else
                {
                    ViewBag.Mensagem = "Usuário ou Senha não existe.";
                    return View();
                }

            }
        }


        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return _context.Usuario != null ? 
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'Contexto.Usuario'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioNome,UsuarioEmail,UsuarioSenha")] Usuario usuario)
        {
            // Gere um salt para o bcrypt
            var salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Gere o hash da senha usando bcrypt e o salt
            var senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.UsuarioSenha, salt);

            // Crie uma nova instância do usuário
            var novoUsuario = new Usuario
            {
                UsuarioNome = usuario.UsuarioNome,
                UsuarioEmail = usuario.UsuarioEmail,
                UsuarioSenha = senhaHash
            };
            if (ModelState.IsValid)
            {
                _context.Add(novoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioNome,UsuarioEmail,UsuarioSenha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Contexto.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public bool Autenticar(Usuario usuario)
        {
            var usuarioDB = _context.Usuario.SingleOrDefault(u => u.UsuarioEmail == usuario.UsuarioEmail);
            var senha = usuario.UsuarioSenha;
            // Verifique se a senha fornecida corresponde ao hash no banco de dados
            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(senha, usuarioDB.UsuarioSenha);
            if (senhaCorreta)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

}

