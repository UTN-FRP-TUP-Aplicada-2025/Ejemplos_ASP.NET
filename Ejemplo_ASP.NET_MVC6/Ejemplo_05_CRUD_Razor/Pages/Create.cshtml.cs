using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ejemplo_05_CRUD_Razor.Models;
using Ejemplo_05_CRUD_Razor.common;

namespace Ejemplo_05_CRUD_Razor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Ejemplo_05_CRUD_Razor.common.AppDbContext _context;

        public CreateModel(Ejemplo_05_CRUD_Razor.common.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Respuesta Respuesta { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Respuestas.Add(Respuesta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
