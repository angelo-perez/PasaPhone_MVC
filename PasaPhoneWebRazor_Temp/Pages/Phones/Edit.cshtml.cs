using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PasaPhoneWebRazor_Temp.Data;
using PasaPhoneWebRazor_Temp.Models;

namespace PasaPhoneWebRazor_Temp.Pages.Phones
{
    public class EditModel : PageModel
    {
        private readonly PasaPhoneWebRazor_Temp.Data.ApplicationDbContext _context;

        public EditModel(PasaPhoneWebRazor_Temp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phone Phone { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone =  await _context.Phones.FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            Phone = phone;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Phones.Update(Phone);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(Phone.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["success"] = "Phone updated successfully";
            return RedirectToPage("./Index");
        }

        private bool PhoneExists(int id)
        {
            return _context.Phones.Any(e => e.Id == id);
        }
    }
}
