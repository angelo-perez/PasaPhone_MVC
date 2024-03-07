using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PasaPhoneWebRazor_Temp.Data;
using PasaPhoneWebRazor_Temp.Models;

namespace PasaPhoneWebRazor_Temp.Pages.Phones
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Phone> PhoneList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PhoneList = await _context.Phones.ToListAsync();
        }
    }
}
