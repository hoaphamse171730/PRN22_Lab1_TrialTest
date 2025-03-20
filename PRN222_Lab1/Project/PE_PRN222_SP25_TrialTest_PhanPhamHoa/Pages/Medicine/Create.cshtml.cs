using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data_Access.Entities;

namespace PharmaceuticalManagement_PhanPhamHoa.Pages.Medicine
{
    public class CreateModel : PageModel
    {
        private readonly Data_Access.Entities.MyDbContext _context;

        public CreateModel(Data_Access.Entities.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerId");
            return Page();
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicineInformations.Add(MedicineInformation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
