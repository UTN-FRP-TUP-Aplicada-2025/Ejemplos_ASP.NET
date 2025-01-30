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
    public class IndexModel : PageModel
    {
        private readonly Ejemplo_05_CRUD_Razor.common.AppDbContext _context;

        public IndexModel(Ejemplo_05_CRUD_Razor.common.AppDbContext context)
        {
            _context = context;
        }

        public IList<Respuesta> Respuesta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Respuesta = await _context.Respuestas.ToListAsync();
        }
    }
}
