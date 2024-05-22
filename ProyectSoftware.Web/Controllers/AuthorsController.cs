using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.DTOs;
using System;
using System.Threading.Tasks;

namespace ProyectSoftware.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly DataContext _context;

        public AuthorController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.ToListAsync();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var author = new Author
            {
                StageName = dto.StageName,
                Name = dto.Name,
                LastName = dto.LastName
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            var dto = new AuthorDTO
            {
                Id = author.Id,
                StageName = author.StageName,
                Name = author.Name,
                LastName = author.LastName
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuthorDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            author.StageName = dto.StageName;
            author.Name = dto.Name;
            author.LastName = dto.LastName;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            var dto = new AuthorDTO
            {
                Id = author.Id,
                StageName = author.StageName,
                Name = author.Name,
                LastName = author.LastName
            };

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            var dto = new AuthorDTO
            {
                Id = author.Id,
                StageName = author.StageName,
                Name = author.Name,
                LastName = author.LastName
            };

            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);

                if (author == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                // Handle database errors (e.g. foreign key violations)
                // Log the error, notify the user, etc.
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle other types of errors
                // Log the error, notify the user, etc.
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
