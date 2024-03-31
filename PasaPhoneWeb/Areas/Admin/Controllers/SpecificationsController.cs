using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PasaPhone.DataAccess.Repository.IRepository;
using PasaPhone.Models;

namespace PasaPhoneWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpecificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Specifications/CreateSpecifications
        public IActionResult CreateSpecifications()
        {
            InitializeSpecificationOptions();
            return View();
        }

        // POST: Specifications/CreateSpecifications
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecifications([Bind("SpecificationId,Phone,Os,Chipset,Memory,Storage,Camera,DisplayResolution,DisplayType,BatteryCapacity,ChargingSpeed,OtherSpecs")] Specification spec)
        {
            // Retrieve the serialized Phone object from TempData and deserialize it
            var phoneData = TempData["PhoneData"] as string;
            var phone = JsonConvert.DeserializeObject<Phone>(phoneData);

            if (phone != null && ModelState.IsValid)
            {
                spec.Phone = phone;
                phone!.DateModified = DateTime.Now;

                _unitOfWork.Phone.Add(phone);
                _unitOfWork.Specification.Add(spec);
                await _unitOfWork.Save();
                TempData["success"] = "Phone listed successfully";
                return RedirectToAction("Index", "Phones");
            }
            return View(spec);
        }

        // GET: Specifications/EditSpecifications/Id
        public async Task<IActionResult> EditSpecifications(int? phoneId)
        {
            if (phoneId == null)
            {
                return NotFound();
            }

            var spec = await _unitOfWork.Specification.Get(s => s.SpecificationId == phoneId);

            if (spec == null)
            {
                return NotFound();
            }

            InitializeSpecificationOptions();
            return View(spec);
        }

        // POST: Specifications/EditSpecifications/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecifications(int phoneId, [Bind("SpecificationId,Phone,Os,Chipset,Memory,Storage,Camera,DisplayResolution,DisplayType,BatteryCapacity,ChargingSpeed,OtherSpecs")] Specification spec)
        {
            if (phoneId != spec.SpecificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var phoneData = TempData["editedPhoneData"] as string;
                    var phone = JsonConvert.DeserializeObject<Phone>(phoneData!);

                    phone!.DateModified = DateTime.Now;

                    _unitOfWork.Phone.Update(phone);
                    _unitOfWork.Specification.Update(spec);
                    await _unitOfWork.Save();
                    TempData["success"] = "Phone updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificationExists(spec.SpecificationId))
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
            return View(spec);
        }

        private bool SpecificationExists(int id)
        {
            return _unitOfWork.Specification.IsItemExists(u => u.SpecificationId == id);
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

    }
}
