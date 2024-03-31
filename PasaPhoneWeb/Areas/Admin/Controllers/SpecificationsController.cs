using Microsoft.AspNetCore.Mvc;
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

        // GET: Phones/CreateSpecifications
        public IActionResult CreateSpecifications()
        {
            return View();
        }

        // POST: Phones/CreateSpecifications
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
                _unitOfWork.Phone.Add(phone);
                _unitOfWork.Specification.Add(spec);
                await _unitOfWork.Save();
                TempData["success"] = "Phone listed successfully";
                return RedirectToAction("Index", "Phones");
            }
            return View(spec);
        }

        // GET: Phones/EditSpecifications/Id
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
            return View(spec);
        }

        // POST: Phones/EditSpecifications/Id
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

    }
}
