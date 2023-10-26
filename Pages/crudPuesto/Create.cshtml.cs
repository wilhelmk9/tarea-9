﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea9.Data;

namespace Tarea9.Pages.crudPuesto
{
    public class CreateModel : PageModel
    {
        private readonly Tarea9.Data.ApplicationDbContext _context;

        public CreateModel(Tarea9.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Puesto Puesto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Puestos == null || Puesto == null)
            {
                return Page();
            }

            _context.Puestos.Add(Puesto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
