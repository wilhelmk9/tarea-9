﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea9.Data;

namespace Tarea9.Pages.crudPuesto
{
    public class EditModel : PageModel
    {
        private readonly Tarea9.Data.ApplicationDbContext _context;

        public EditModel(Tarea9.Data.ApplicationDbContext context)
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

            var puesto =  await _context.Puestos.FirstOrDefaultAsync(m => m.idPuesto == id);
            if (puesto == null)
            {
                return NotFound();
            }
            Puesto = puesto;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(Puesto.idPuesto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PuestoExists(int id)
        {
          return (_context.Puestos?.Any(e => e.idPuesto == id)).GetValueOrDefault();
        }
    }
}
