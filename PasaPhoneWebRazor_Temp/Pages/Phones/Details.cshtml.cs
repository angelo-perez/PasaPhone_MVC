﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly PasaPhoneWebRazor_Temp.Data.ApplicationDbContext _context;

        public DetailsModel(PasaPhoneWebRazor_Temp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Phone Phone { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            else
            {
                Phone = phone;
            }
            return Page();
        }
    }
}
