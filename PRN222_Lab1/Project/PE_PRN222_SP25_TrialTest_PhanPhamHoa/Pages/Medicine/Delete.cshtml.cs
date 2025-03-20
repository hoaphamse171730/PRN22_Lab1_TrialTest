using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data_Access.Entities;

namespace PharmaceuticalManagement_PhanPhamHoa.Pages.Medicine
{
    public class DeleteModel : PageModel
    {
        private readonly Data_Access.Entities.MyDbContext _context;

        public DeleteModel(Data_Access.Entities.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineinformation = await _context.MedicineInformations.FirstOrDefaultAsync(m => m.MedicineId == id);

            if (medicineinformation == null)
            {
                return NotFound();
            }
            else
            {
                MedicineInformation = medicineinformation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineinformation = await _context.MedicineInformations.FindAsync(id);
            if (medicineinformation != null)
            {
                MedicineInformation = medicineinformation;
                _context.MedicineInformations.Remove(MedicineInformation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
