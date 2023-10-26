using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tarea9.Data;

namespace Tarea9.Pages.crudPuesto
{
    public class DeleteModel : PageModel
    {
        private readonly Tarea9.Data.ApplicationDbContext _context;

        public DeleteModel(Tarea9.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Puesto Puesto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puestos.FirstOrDefaultAsync(m => m.idPuesto == id);

            if (puesto == null)
            {
                return NotFound();
            }
            else 
            {
                Puesto = puesto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }
            var puesto = await _context.Puestos.FindAsync(id);

            if (puesto != null)
            {
                Puesto = puesto;
                _context.Puestos.Remove(Puesto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
