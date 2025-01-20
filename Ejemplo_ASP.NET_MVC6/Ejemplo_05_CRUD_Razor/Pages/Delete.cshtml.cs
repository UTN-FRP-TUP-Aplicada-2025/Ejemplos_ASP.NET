using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ejemplo_05_CRUD_Razor.Models;
using Ejemplo_05_CRUD_Razor.common;

namespace Ejemplo_05_CRUD_Razor.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Ejemplo_05_CRUD_Razor.common.AppDbContext _context;

        public DeleteModel(Ejemplo_05_CRUD_Razor.common.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Respuesta Respuesta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas.FirstOrDefaultAsync(m => m.Id == id);

            if (respuesta == null)
            {
                return NotFound();
            }
            else
            {
                Respuesta = respuesta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta != null)
            {
                Respuesta = respuesta;
                _context.Respuestas.Remove(Respuesta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
