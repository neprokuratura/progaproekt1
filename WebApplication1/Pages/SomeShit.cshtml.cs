using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Models;
namespace WebApplication1.Pages
{
    public class SomeShitModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Chamber c { get; set; }
        public List<Chamber> chambers { get; set; }
        public SomeShitModel(ApplicationContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            chambers = _context.chamber.ToList();
        }
        public IActionResult OnPost()
        {
            _context.chamber.Add(c);
            _context.SaveChanges();
            return RedirectToPage();
        }
        public void OnDialog()
        {
            ;
        }
    }
}
