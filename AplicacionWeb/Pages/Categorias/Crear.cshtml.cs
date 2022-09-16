using AplicacionWeb.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AplicacionWeb.Modelos;

namespace AplicacionWeb.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Categoria Categoria { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Categoria.FechaCreacion = DateTime.Now;
            _context.Add(Categoria);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
