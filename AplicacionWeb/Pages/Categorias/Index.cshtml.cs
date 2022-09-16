using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AplicacionWeb.Datos;
using AplicacionWeb.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWeb.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias { get; set; }
        public async Task OnGet()
        {
            Categorias=await _context.Categoria.ToListAsync();
        }
        public async Task<IActionResult>OnPostBorrar(int id)
        {
            var categoria=await _context.Categoria.FindAsync(id);
            if(categoria==null)
            {
                 return NotFound();
            }
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }

}
