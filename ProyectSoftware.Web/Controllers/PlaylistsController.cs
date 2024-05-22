using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectSoftware.Web.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly DataContext _context;

        public PlaylistController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Playlist> playlists = await _context.Playlists.ToListAsync();
            return View(playlists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlaylistDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var playlist = new Playlist
            {
                Name = dto.Name,
                Description = dto.Description,
                Cantidad = dto.Cantidad
            };

            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            var dto = new PlaylistDTO
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Description = playlist.Description,
                Cantidad = playlist.Cantidad
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlaylistDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            playlist.Name = dto.Name;
            playlist.Description = dto.Description;
            playlist.Cantidad = dto.Cantidad;

            _context.Playlists.Update(playlist);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
