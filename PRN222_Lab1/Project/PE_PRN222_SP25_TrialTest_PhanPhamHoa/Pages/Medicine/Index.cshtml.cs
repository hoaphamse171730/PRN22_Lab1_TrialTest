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
    public class IndexModel : PageModel
    {
        private readonly Data_Access.Entities.MyDbContext _context;

        public IndexModel(Data_Access.Entities.MyDbContext context)
        {
            _context = context;
        }

        public IList<MedicineInformation> MedicineInformation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MedicineInformation = await _context.MedicineInformations
                .Include(m => m.Manufacturer).ToListAsync();
        }
    }
}
