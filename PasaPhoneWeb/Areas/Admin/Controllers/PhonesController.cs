using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PasaPhone.DataAccess.Data;
using PasaPhone.DataAccess.Repository.IRepository;
using PasaPhone.Models;
using PasaPhoneWeb.Areas.Admin.ViewModels;

namespace PasaPhoneWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhonesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhonesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Phone.GetAll().ToListAsync());
        }

        // GET: Phones/Details/Id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _unitOfWork.Phone.Get(m => m.Id == id);
            var spec = await _unitOfWork.Specification.Get(s => s.SpecificationId == id);

            if (phone == null)
            {
                return NotFound();
            }

            var viewModel = new PhoneAndSpecificationsViewModel
            {
                Phone = phone,
                Specification = spec
            };

            return View(viewModel);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Condition,Price,Description,Issues,Location,MeetupPreference")] Phone phone, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // Serialize the Phone object to JSON and store it in TempData
                TempData["PhoneData"] = JsonConvert.SerializeObject(phone);
                // Pass webHostEnvironment and file to Specifications Controller
                TempData["webRootPath"] = _webHostEnvironment.WebRootPath;
                TempData["fileName"] = file.FileName;
                TempData["fileExtension"] = Path.GetExtension(file.FileName);

                using var fileStream = file.OpenReadStream();
                using var memoryStream =  new MemoryStream();
                fileStream.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();
                HttpContext.Session.Set("phoneImage", imageBytes);

                return RedirectToAction("CreateSpecifications", "Specifications");
            }
            return View(phone);
        }

        // GET: Phones/Edit/Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _unitOfWork.Phone.Get(u => u.Id == id);

            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // POST: Phones/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Condition,Price,Description,Issues,Location,MeetupPreference")] Phone phone, IFormFile? file)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["editedPhoneData"] = JsonConvert.SerializeObject(phone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EditSpecifications", "Specifications", new {phoneId = phone.Id});
            }
            return View(phone);
        }

        // GET: Phones/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _unitOfWork.Phone.Get(u => u.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _unitOfWork.Phone.Get(u => u.Id == id);
            if (phone != null)
            {
                _unitOfWork.Phone.Remove(phone);
            }

            await _unitOfWork.Save();
            TempData["success"] = "Phone deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        public void Back() { 
        
        }

        private bool PhoneExists(int id)
        {
            return _unitOfWork.Phone.IsItemExists(e => e.Id == id);
        }

        private void InitializePhoneDetailsOptions()
        {
            List<string> conditionList = new List<string>() {
                "New",
                "Used - Like New",
                "Used - Good",
                "Used - Fair"
            };

            IEnumerable<SelectListItem> ConditionOptions = conditionList.Select(c =>
                new SelectListItem
                {
                    Text = c,
                    Value = c.ToString()
                }
            );

            ViewBag.ConditionOptions = ConditionOptions;
        }
    }

}
