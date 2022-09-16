using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AplicacionWeb.Datos;
using AplicacionWeb.Modelos;

namespace AplicacionWeb.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Categoria Categoria { get; set; }
        public async Task OnGet(int id)
        {
            Categoria = await _context.Categoria.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CategoriaDesdeBD = await _context.Categoria.FindAsync(Categoria.Id);
                CategoriaDesdeBD.Nombre = Categoria.Nombre;
                CategoriaDesdeBD.FechaCreacion = Categoria.FechaCreacion;
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
