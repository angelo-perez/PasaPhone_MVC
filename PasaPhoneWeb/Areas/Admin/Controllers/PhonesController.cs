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
            InitializeSpecificationOptions();
            return View();
        }

        // POST: Phones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhoneAndSpecificationsViewModel vm, IFormFile? file)
        {
            var phone = vm.Phone;
            var spec = vm.Specification;

            if (ModelState.IsValid)
            {
                SavePhoneImage(phone, file);

                spec.Phone = phone;
                phone!.DateModified = DateTime.Now;

                _unitOfWork.Phone.Add(phone);
                _unitOfWork.Specification.Add(spec);
                await _unitOfWork.Save();
                TempData["success"] = "Phone listed successfully";
                return RedirectToAction("Index", "Phones");
            }
            return View(vm);
        }

        // GET: Phones/Edit/Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _unitOfWork.Phone.Get(u => u.Id == id);
            var spec = await _unitOfWork.Specification.Get(s => s.SpecificationId == id);

            if (phone == null || spec == null)
            {
                return NotFound();
            }
            PhoneAndSpecificationsViewModel vm = new PhoneAndSpecificationsViewModel{
                Phone = phone!,
                Specification = spec!
            };

            InitializeSpecificationOptions();
            return View(vm);
        }

        // POST: Phones/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PhoneAndSpecificationsViewModel vm, IFormFile? file)
        {
            var phone = vm.Phone;
            var spec = vm.Specification;

            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SavePhoneImage(phone, file);

                    phone!.DateModified = DateTime.Now;
;
                    _unitOfWork.Phone.Update(phone);
                    _unitOfWork.Specification.Update(spec);
                    await _unitOfWork.Save();
                    TempData["success"] = "Phone updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id) && !SpecificationExists(spec.SpecificationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Phones");
            }
            return View(vm);
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
                DeletePhoneImage(phone.ImageUrl);
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

        private bool SpecificationExists(int id)
        {
            return _unitOfWork.Specification.IsItemExists(u => u.SpecificationId == id);
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

        private void InitializeSpecificationOptions()
        {
            List<string> osList = new List<string>() {
                "Android",
                "iOS",
                "Other"
            };

            List<String> MemorySizeList = new List<string>() {
                "<1GB",
                "1GB",
                "2GB",
                "3GB",
                "4GB",
                "6GB",
                "8GB",
                "12GB",
                "16GB",
                ">16GB"
            };

            List<String> StorageSizeList = new List<string>() {
                "<8GB",
                "8GB",
                "16GB",
                "32GB",
                "64GB",
                "128GB",
                "256GB",
                "512GB",
                "1TB",
                ">1TB"
            };

            IEnumerable<SelectListItem> OsOptions = osList.Select(o =>
                new SelectListItem
                {
                    Text = o,
                    Value = o.ToString()
                }
            );

            IEnumerable<SelectListItem> MemoryOptions = MemorySizeList.Select(m =>
                new SelectListItem
                {
                    Text = m,
                    Value = m.ToString()
                }
            );

            IEnumerable<SelectListItem> StorageOptions = StorageSizeList.Select(s =>
                new SelectListItem
                {
                    Text = s,
                    Value = s.ToString()
                }
            );

            ViewBag.OsOptions = OsOptions;
            ViewBag.MemoryOptions = MemoryOptions;
            ViewBag.StorageOptions = StorageOptions;
        }

        private void SavePhoneImage(Phone phone, IFormFile? file)
        {
            // reference for wwwroot
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                // for unique filename and extension (e.g ".jpg")
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                // for accessing images/phone inside wwwroot
                string phonePath = Path.Combine(wwwRootPath, @"images\phone");

                DeletePhoneImage(phone.ImageUrl); // delete old image (if there's one)

                // for saving image
                using (var filesStream = new FileStream(Path.Combine(phonePath, fileName), FileMode.Create))
                {
                    file.CopyTo(filesStream);
                }

                phone.ImageUrl = @"\images\phone\" + fileName;
            }
        }

        private void DeletePhoneImage(string? imgUrl) {
            if (!string.IsNullOrEmpty(imgUrl)) // checks if there's an old image
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var oldImgPath = Path.Combine(wwwRootPath, imgUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
            }
        }

    }

}
