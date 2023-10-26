using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tarea9.Data;

namespace Tarea9.Pages.crudEmpleado
{
    public class IndexModel : PageModel
    {
        private readonly Tarea9.Data.ApplicationDbContext _context;

        public IndexModel(Tarea9.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empleados != null)
            {
                Empleado = await _context.Empleados.ToListAsync();
            }
        }
    }
}
